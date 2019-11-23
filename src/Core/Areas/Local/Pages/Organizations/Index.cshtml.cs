using Data.Persistence;
using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Core.Areas.Local.Pages.Organizations
{
    public class IndexModel : PageModel
    {
        private readonly INodeRepository _repository;

        public IndexModel(INodeRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<LocalOrganization> Organizations { get; set; }

        public void OnGet()
        {
            Organizations = _repository.GetAll<LocalOrganization>();
        }
    }
}