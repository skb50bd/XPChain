using Data.Persistence;
using Domain;
using LiteDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Core.Areas.Local.Pages.UnitsOfWork
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
        public Project Project { get; set; }
        public LocalUnitOfWork UnitOfWork { get; set; }
        public bool IsCorrectEmployee { get; set; }
        public bool IsAdmin { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var objId = new ObjectId(id);
            UnitOfWork = _repository.SingleById<LocalUnitOfWork>(objId);
            LocalEmployee =
                _repository.SingleById<LocalEmployee>(
                    new ObjectId(UnitOfWork.ExecutorId));
            
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            IsAdmin = await _userManager.IsInRoleAsync(user, "Admin");

            if (!IsAdmin)
            {
                if (user.UserName == LocalEmployee.UserName)
                {
                    IsCorrectEmployee = true;
                    LocalEmployee = _repository.SingleOrDefault<LocalEmployee>(
                        e => e.UserName == user.UserName);
                }
            }

            if (!IsAdmin && !IsCorrectEmployee)
                return Unauthorized();

            Project = _ledger.GetById<Project>(UnitOfWork.ProjectId);


            return Page();
        }

        public async Task<IActionResult> OnPostDeployAsync(string id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            IsAdmin = await _userManager.IsInRoleAsync(user, "Admin");

            if (!IsAdmin)
                return Unauthorized();

            var objId = new ObjectId(id);
            LocalEmployee = _repository.SingleById<LocalEmployee>(objId);

            var employee = new Employee
            {
                Id = LocalEmployee.Id,
                Organization = _orgOptions.PublicKey,
                PublicKey = LocalEmployee.PublicKey,
                Designation = LocalEmployee.Designation,
                StartDate = LocalEmployee.StartDate,
                EmployeeSignature = LocalEmployee.VerificationSignature,
                IdentificationSignature = LocalEmployee.IdentificationSignature
            };

            var prevHash = _ledger.GetLastBlockHash();

            var block = new Block
            {
                Id = ObjectId.NewObjectId(),
                PreviousBlockHash = prevHash,
                Originator = _orgOptions.PublicKey,
                Data = employee.ToJson(),
                Type = typeof(Employee).Name
            };
            block.Sign(_orgOptions.PrivateKey);
            block.SetHash();

            _ledger.Insert(block);
            LocalEmployee.IsDeployed = true;
            _repository.Update(LocalEmployee);
            return RedirectToPage("/Employees/Details",
                new { id = block.Id, area = "Chain" });
        }
    }
}