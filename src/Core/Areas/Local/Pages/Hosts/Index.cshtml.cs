using Data.Persistence;
using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Core.Areas.Local.Pages.Hosts
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly INodeRepository _repository;

        public IndexModel(INodeRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Host> Hosts { get; set; }

        public void OnGet()
        {
            Hosts = _repository.GetAll<Host>();
        }
    }
}