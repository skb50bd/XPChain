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

namespace Core.Areas.Local.Pages.Resignations
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
        public LocalResignation Resignation { get; set; }
        public bool IsCorrectEmployee { get; set; }
        public bool IsAdmin { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Resignation = _repository.SingleById<LocalResignation>(id);
            LocalEmployee =
                _repository.SingleOrDefault<LocalEmployee>(
                    e => e.PublicKey == Resignation.EmployeePublicKey);
            
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            IsAdmin = await _userManager.IsInRoleAsync(user, "Admin");

            if (!IsAdmin)
            {
                if (user.UserName == LocalEmployee.UserName)
                {
                    IsCorrectEmployee = true;
                }
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

            Resignation = _repository.SingleById<LocalResignation>(id);

            var resignation = new Resignation
            {
                Id = Resignation.Id,
                Organization = _orgOptions.PublicKey,
                Employee = Resignation.EmployeePublicKey,
                EndDate = Resignation.EndDate,
                Description = Resignation.Description,
                EmployeeSignature = Resignation.EmployeeSignature
            };

            var prevHash = _ledger.GetLastBlockHash();

            var block = new Block
            {
                Id = ObjectId.NewObjectId().ToString(),
                PreviousBlockHash = prevHash,
                Originator = _orgOptions.PublicKey,
                Data = resignation.ToJson(),
                Type = typeof(Resignation).Name
            };
            block.Sign(_orgOptions.PrivateKey);
            block.SetHash();

            await _ledger.Insert(block);
            Resignation.IsDeployed = true;
            _repository.Update(Resignation);
            return RedirectToPage("/Resignations/Details",
                new { hash = block.Hash, area = "Chain" });
        }
    }
}