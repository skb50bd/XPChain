using Data.Persistence;
using Domain;
using LiteDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Core.Areas.Chain.Pages.Blocks
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

        public Block Block { get; set; }

        public IActionResult OnGet(string id)
        {
            Block = _ledger.GetById(id);

            if (Block is null)
                return NotFound();

            return Page();
        }
    }
}