using Data.Persistence;
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

namespace Core.Areas.Local.Pages.UnitsOfWork
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly INodeRepository _repository;
        private readonly ILedgerRepository _ledger;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(
            INodeRepository repository,
            UserManager<IdentityUser> userManager,
            ILedgerRepository ledger)
        {
            _repository = repository;
            _userManager = userManager;
            _ledger = ledger;
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
                nameof(LocalEmployee.Id),
                nameof(LocalEmployee.Name));

            var projects =
                _ledger.GetAll()
                       .Where(b => b.Type == typeof(Project).Name)
                       .Select(p => p.Data.FromJson<Project>());

            Projects = new SelectList(
                projects,
                nameof(Project.Id),
                nameof(Project.Title));

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
            IsCorrectEmployee = employee?.Id.ToString() == Input.Executor;

            if (!IsAdmin && !IsCorrectEmployee) return Unauthorized();

            var executor =
                _repository.SingleById<LocalEmployee>(new ObjectId(Input.Executor));
            var uow = new LocalUnitOfWork
            {
                Id = ObjectId.NewObjectId(),
                ProjectId = new ObjectId(Input.Project),
                ExecutorId = executor.Id,
                ExecutorPublicKey = executor.PublicKey,
                Tags = Input.Tags,
                Xp = Input.Xp,
                Description = Input.Description
            };
            _repository.Insert(uow);
            return RedirectToPage("./Details", new { uow.Id });
        }

        public bool IsAdmin { get; set; }
        public bool IsCorrectEmployee { get; set; }

        public SelectList Employees;
        public SelectList Projects;

        [BindProperty]
        public InputModel Input { get; set; }
    }

    public class InputModel
    {
        public string Project { get; set; }
        public string Executor { get; set; }
        public string Tags { get; set; }

        [Display(Name = "Experience Points")]
        public decimal Xp { get; set; }
        public string Description { get; set; }
    }
}