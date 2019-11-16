using Data.Persistence;
using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Core.Areas.Chain.Blocks
{
    public class IndexModel : PageModel
    {
        private readonly ILedgerRepository _ledger;

        public IndexModel(ILedgerRepository ledger)
        {
            _ledger = ledger;
        }


        public IEnumerable<Block> Blocks { get; set; }

        public void OnGet()
        {
            Blocks = _ledger.GetAll();
        }
    }
}
