using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Persistence;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Core.Areas.Chain.Pages.UnitsOfWork
{
    public class IndexModel : PageModel
    {
        private readonly ILedgerRepository _ledger;

        public IndexModel(ILedgerRepository ledger)
        {
            _ledger = ledger;
        }

        public IDictionary<string, UnitOfWork> UnitsOfWork { get; set; }

        public void OnGet()
        {
            var blocks = _ledger.GetAll();
            var dict = blocks.Where(b => b.Type == typeof(UnitOfWork).Name)
                             .Select(b =>
                                  new KeyValuePair<string, UnitOfWork>(
                                      b.Hash,
                                      b.Data.FromJson<UnitOfWork>()));
            UnitsOfWork = new Dictionary<string, UnitOfWork>(dict);
        }
    }
}