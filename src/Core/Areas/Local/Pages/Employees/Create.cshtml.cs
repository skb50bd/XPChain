using Data.Persistence;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Core.Areas.Local.Pages.Employees
{
    [Authorize(Roles = "Admin")]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var user = new IdentityUser
            {
                UserName = Input.Username,
                Email = Input.Email,
                EmailConfirmed = true
            };
            const string password = "User#123";

            var res = await _userManager.CreateAsync(user, password);
            if (res.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Employee");
                var emp = new LocalEmployee
                {
                    UserName             = user.UserName,
                    Name                 = Input.Name,
                    Email                = Input.Email,
                    Phone                = Input.Phone,
                    Address              = Input.Address,
                    Designation          = Input.Designation,
                    BirthDate            = Input.BirthDate,
                    StartDate            = Input.StartDate,
                    PublicKey            = Input.PublicKey,
                    IdentificationNumber = Input.IdentificationNumber
                };
                _repository.Insert(emp);
                return RedirectToPage("./Index");
            }

            return BadRequest(res.Errors);
        }

        [BindProperty]
        public InputModel Input { get; set; }
    }
    
    public class InputModel
    {
        public string Username { get; set; }

        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        public string Address { get; set; }
        public string Designation { get; set; }

        [Display(Name = "Public Key")]
        public string PublicKey { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "ID#")]
        public string IdentificationNumber { get; set; }
    }
}