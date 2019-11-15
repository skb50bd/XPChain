using Data.Persistence;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Core.Areas.Chain.Pages.Projects
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

        public Project Project { get; set; }
        public Block Block { get; set; }

        public IActionResult OnGet(string hash)
        {
            Block = _ledger.GetByHash(hash);
            Project = Block.Data.FromJson<Project>();
            return Page();
        }
    }
}