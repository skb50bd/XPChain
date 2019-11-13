using Data.Persistence;
using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Core.Areas.Chain.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly ILedgerRepository _repository;

        public IndexModel(ILedgerRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Employee> Employees { get; set; }

        public void OnGet()
        {
            Employees = _repository.GetAll<Employee>();
        }
    }
}