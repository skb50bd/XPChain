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
            UnitOfWork = _repository.SingleById<LocalUnitOfWork>(objId);

            var uow = new UnitOfWork
            {
                Id                = UnitOfWork.Id,
                Organization      = _orgOptions.PublicKey,
                ProjectId         = UnitOfWork.ProjectId,
                Executor          = UnitOfWork.ExecutorPublicKey,
                Tags              = UnitOfWork.Tags,
                Description       = UnitOfWork.Description,
                EmployeeSignature = UnitOfWork.EmployeeSignature,
                Xp                = UnitOfWork.Xp
            };

            var prevHash = _ledger.GetLastBlockHash();

            var block = new Block
            {
                Id = ObjectId.NewObjectId(),
                PreviousBlockHash = prevHash,
                Originator = _orgOptions.PublicKey,
                Data = uow.ToJson(),
                Type = typeof(UnitOfWork).Name
            };
            block.Sign(_orgOptions.PrivateKey);
            block.SetHash();

            _ledger.Insert(block);
            UnitOfWork.IsDeployed = true;
            _repository.Update(UnitOfWork);
            return RedirectToPage("/UnitsOfWork/Details",
                new { hash = block.Hash, area = "Chain" });
        }
    }
}