using Data.Persistence;
using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace Core.Areas.Chain.Pages.Projects
{
    public class IndexModel : PageModel
    {
        private readonly ILedgerRepository _repository;

        public IndexModel(ILedgerRepository repository)
        {
            _repository = repository;
        }


        public IDictionary<string, Project> Projects { get; set; }

        public void OnGet()
        {
            var blocks = _repository.GetAll();
            var dict = blocks.Where(b => b.Type == typeof(Project).Name)
                             .Select(b => new KeyValuePair<string, Project>(
                                      b.Hash, 
                                      b.Data.FromJson<Project>()));
            Projects = new Dictionary<string, Project>(dict);
        }
    }
}