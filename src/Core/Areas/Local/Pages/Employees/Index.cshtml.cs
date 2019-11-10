using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Persistence;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Core.Areas.Local.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly INodeRepository _repository;

        public IndexModel(INodeRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<LocalEmployee> Employees { get; set; }

        public void OnGet()
        {
            Employees = _repository.GetAll<LocalEmployee>();
        }
    }
}