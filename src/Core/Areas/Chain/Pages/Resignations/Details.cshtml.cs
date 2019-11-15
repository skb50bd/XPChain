using Data.Persistence;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Core.Areas.Chain.Pages.Resignations
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

        public Resignation Resignation { get; set; }
        public Block Block { get; set; }

        public IActionResult OnGet(string hash)
        {
            Block = _ledger.GetByHash(hash);

            if (Block is null || Block.Type != typeof(Resignation).Name)
                return NotFound();

            Resignation = Block.Data.FromJson<Resignation>();
            return Page();
        }
    }
}