using Data.Persistence;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Core.Areas.Chain.Pages.Organizations
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly ILedgerRepository _ledger;

        public DetailsModel(
            ILedgerRepository ledger)
        {
            _ledger = ledger;
        }

        public Organization Organization { get; set; }
        public Block Block { get; set; }

        public IActionResult OnGet(string hash)
        {
            Block = _ledger.GetByHash(hash);
            Organization = Block.Data.FromJson<Organization>();
            return Page();
        }
    }
}