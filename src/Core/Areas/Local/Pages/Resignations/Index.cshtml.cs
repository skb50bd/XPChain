using Data.Persistence;
using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Core.Areas.Local.Pages.Resignations
{
    public class IndexModel : PageModel
    {
        private readonly INodeRepository _repository;
        public IndexModel(INodeRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<LocalResignation> Resignations { get; set; }

        public void OnGet()
        {
            Resignations = _repository.GetAll<LocalResignation>();
        }
    }
}