using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Persistence;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Core.Areas.Chain.Pages.Resignations
{
    public class IndexModel : PageModel
    {
        private readonly ILedgerRepository _ledger;

        public IndexModel(ILedgerRepository ledger)
        {
            _ledger = ledger;
        }

        public IDictionary<string, Resignation> Resignation { get; set; }

        public void OnGet()
        {
            var blocks = _ledger.GetAll();
            var dict = blocks.Where(b => b.Type == typeof(Resignation).Name)
                             .Select(b =>
                                  new KeyValuePair<string, Resignation>(
                                      b.Hash,
                                      b.Data.FromJson<Resignation>()));
            Resignation = new Dictionary<string, Resignation>(dict);
        }
    }
}