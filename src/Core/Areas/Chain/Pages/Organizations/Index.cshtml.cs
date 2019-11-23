using Data.Persistence;
using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace Core.Areas.Chain.Pages.Organizations
{
    public class IndexModel : PageModel
    {
        private readonly ILedgerRepository _repository;

        public IndexModel(ILedgerRepository repository)
        {
            _repository = repository;
        }


        public IDictionary<string, Organization> Organizations { get; set; }

        public void OnGet()
        {
            var blocks = _repository.GetAll();
            var dict = blocks.Where(b => b.Type == typeof(Organization).Name)
                             .Select(b => new KeyValuePair<string, Organization>(
                                      b.Hash, 
                                      b.Data.FromJson<Organization>()));
            Organizations = new Dictionary<string, Organization>(dict);
        }
    }
}