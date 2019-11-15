using Data.Persistence;
using Domain;
using LiteDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Core.Areas.Local.Pages.Certifications
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
        public LocalCertificate Certificate { get; set; }
        public bool IsCorrectEmployee { get; set; }
        public bool IsAdmin { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var objId = new ObjectId(id);
            Certificate = _repository.SingleById<LocalCertificate>(objId);
            LocalEmployee =
                _repository.SingleOrDefault<LocalEmployee>(
                    e => e.PublicKey == Certificate.ReceiverPublicKey);
            
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

            var objId = new ObjectId(id);
            Certificate = _repository.SingleById<LocalCertificate>(objId);

            var certificate = new Certificate
            {
                Id = Certificate.Id,
                Issuer = _orgOptions.PublicKey,
                Owner = Certificate.ReceiverPublicKey,
                Title = Certificate.Title,
                Description = Certificate.Description,
                OwnerSignature = Certificate.ReceiverSignature
            };

            var prevHash = _ledger.GetLastBlockHash();

            var block = new Block
            {
                Id = ObjectId.NewObjectId(),
                PreviousBlockHash = prevHash,
                Originator = _orgOptions.PublicKey,
                Data = certificate.ToJson(),
                Type = typeof(Certificate).Name
            };
            block.Sign(_orgOptions.PrivateKey);
            block.SetHash();

            _ledger.Insert(block);
            Certificate.IsDeployed = true;
            _repository.Update(Certificate);
            return RedirectToPage("/UnitsOfWork/Details",
                new { id = block.Id, area = "Chain" });
        }
    }
}