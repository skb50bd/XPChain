using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Persistence;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Core.Areas.Chain.Pages.Certifications
{
    public class IndexModel : PageModel
    {
        private readonly ILedgerRepository _ledger;

        public IndexModel(ILedgerRepository ledger)
        {
            _ledger = ledger;
        }

        public IDictionary<string, Certificate> Certificate { get; set; }

        public void OnGet()
        {
            var blocks = _ledger.GetAll();
            var dict = blocks.Where(b => b.Type == typeof(Certificate).Name)
                             .Select(b =>
                                  new KeyValuePair<string, Certificate>(
                                      b.Hash,
                                      b.Data.FromJson<Certificate>()));
            Certificate = new Dictionary<string, Certificate>(dict);
        }
    }
}