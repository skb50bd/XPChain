using Data.Persistence;
using Domain;
using LiteDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Domain.Local;

namespace Core.Areas.Local.Pages.Organizations
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly INodeRepository _repository;
        private readonly ILedgerRepository _ledger;
        private readonly OrganizationOptions _orgOptions;

        public DetailsModel(
            INodeRepository repository,
            ILedgerRepository ledger,
            IOptionsMonitor<OrganizationOptions> orgOptions)
        {
            _repository = repository;
            _ledger = ledger;
            _orgOptions = orgOptions.CurrentValue;
        }

        public LocalOrganization Organization { get; set; }

        public IActionResult OnGet(string id)
        {
            var objId = new ObjectId(id);
            Organization = _repository.SingleById<LocalOrganization>(objId);
            return Page();
        }

        public async Task<IActionResult> OnPostDeploy(string id)
        {
            var objId = new ObjectId(id);
            Organization = _repository.SingleById<LocalOrganization>(objId);

            var organization = new Organization
            {
                Id = Organization.Id,
                Title = Organization.Title,
                PublicKey = Organization.PublicKey,
                Address = Organization.Address,
                Email = Organization.Email,
                Phone = Organization.Phone,
                VerificationSignature = Organization.VerificationSignature
            };

            var prevHash = _ledger.GetLastBlockHash();

            var block = new Block
            {
                Id = ObjectId.NewObjectId(),
                PreviousBlockHash = prevHash,
                Originator = _orgOptions.PublicKey,
                Data = organization.ToJson(),
                Type = typeof(Organization).Name
            };
            block.Sign(_orgOptions.PrivateKey);
            block.SetHash();

            await _ledger.Insert(block);
            Organization.IsDeployed = true;
            _repository.Update(Organization);
            return RedirectToPage("/Organizations/Details",
                new { hash = block.Hash, area = "Chain" });
        }
    }
}