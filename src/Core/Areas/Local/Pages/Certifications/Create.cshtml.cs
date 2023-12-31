﻿using Data.Persistence;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;

namespace Core.Areas.Local.Pages.Certifications
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly INodeRepository _repository;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(
            INodeRepository repository,
            UserManager<IdentityUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            IEnumerable<LocalEmployee> localEmployees;
            var user = await _userManager.GetUserAsync(User);
            IsAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            if (IsAdmin)
            {
                localEmployees = _repository.GetAll<LocalEmployee>().Where(e => e.IsDeployed);
            }
            else
            {
                localEmployees = new List<LocalEmployee> {
                    _repository.SingleOrDefault<LocalEmployee>(
                        e => e.UserName == User.Identity.Name && e.IsDeployed)
                };
            }

            Employees = new SelectList(
                localEmployees,
                nameof(LocalEmployee.PublicKey),
                nameof(LocalEmployee.Name));

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var user = await _userManager.GetUserAsync(User);
            IsAdmin = await _userManager.IsInRoleAsync(user, "Admin");

            var employee =
                _repository.SingleOrDefault<LocalEmployee>(
                    e => e.UserName == user.UserName);
            IsCorrectEmployee = employee?.PublicKey == Input.Receiver;

            if (!IsAdmin && !IsCorrectEmployee) return Unauthorized();

            var certificate = new LocalCertificate
            {
                Id = ObjectId.NewObjectId().ToString(),
                Title = Input.Title,
                ReceiverPublicKey = Input.Receiver,
                Description = Input.Description
            };
            _repository.Insert(certificate);
            return RedirectToPage("./Details", new { certificate.Id });
        }

        public bool IsAdmin { get; set; }
        public bool IsCorrectEmployee { get; set; }

        public SelectList Employees;

        [BindProperty]
        public InputModel Input { get; set; }
    }

    public class InputModel
    {
        public string Title { get; set; }
        public string Receiver { get; set; }
        public string Description { get; set; }
    }
}