using Data.Persistence;
using Domain;
using LiteDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Domain.Local;
using Microsoft.Extensions.Options;

namespace Core.Areas.Local.Pages.Employees
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly INodeRepository _repository;
        private readonly ILedgerRepository _ledger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly OrganizationOptions _orgOptions;

        public DetailsModel(
            INodeRepository repository,
            ILedgerRepository ledger,
            UserManager<IdentityUser> userManager,
            IOptionsMonitor<OrganizationOptions> orgOptions) 
        {
            _repository = repository;
            _userManager = userManager;
            _ledger = ledger;
            _orgOptions = orgOptions.CurrentValue;
        }

        public LocalEmployee LocalEmployee { get; set; }
        public bool IsCorrectEmployee { get; set; }
        public bool IsAdmin { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            LocalEmployee = _repository.SingleById<LocalEmployee>(id);

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            IsAdmin = await _userManager.IsInRoleAsync(user, "Admin");

            if (!IsAdmin)
            {
                if (user.UserName == LocalEmployee.UserName)
                    IsCorrectEmployee = true;
            }

            if (!IsAdmin && !IsCorrectEmployee)
                return Unauthorized();
            return Page();
        }

        public async Task<IActionResult> OnPostDeployAsync(string id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            IsAdmin = await _userManager.IsInRoleAsync(user, "Admin");

            if (!IsAdmin)
                return Unauthorized();

            LocalEmployee = _repository.SingleById<LocalEmployee>(id);

            var employee = new Employee
            {
                Id                      = LocalEmployee.Id,
                Organization            = _orgOptions.PublicKey,
                PublicKey               = LocalEmployee.PublicKey,
                Designation             = LocalEmployee.Designation,
                StartDate               = LocalEmployee.StartDate,
                EmployeeSignature       = LocalEmployee.VerificationSignature,
                IdentificationSignature = LocalEmployee.IdentificationSignature
            };

            var prevHash = _ledger.GetLastBlockHash();

            var block = new Block
            {
                Id = ObjectId.NewObjectId().ToString(),
                PreviousBlockHash = prevHash,
                Originator = _orgOptions.PublicKey,
                Data = employee.ToJson(),
                Type = typeof(Employee).Name
            };
            block.Sign(_orgOptions.PrivateKey);
            block.SetHash();

            await _ledger.Insert(block);
            LocalEmployee.IsDeployed = true;
            _repository.Update(LocalEmployee);
            return RedirectToPage("/Employees/Details",
                new {hash = block.Hash, area = "Chain"});
        }

        public bool Verify() =>
            LocalEmployee.Verify(
                _orgOptions.PublicKey,
                LocalEmployee.VerificationSignature);
    }
}