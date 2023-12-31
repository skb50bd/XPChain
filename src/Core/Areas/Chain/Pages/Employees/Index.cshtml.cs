﻿using Data.Persistence;
using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace Core.Areas.Chain.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly ILedgerRepository _repository;

        public IndexModel(ILedgerRepository repository)
        {
            _repository = repository;
        }


        public IDictionary<string, Employee> Employees { get; set; }

        public void OnGet()
        {
            var blocks = _repository.GetAll();
            var dict = blocks.Where(b => b.Type == typeof(Employee).Name)
                             .Select(b => new KeyValuePair<string, Employee>(
                                      b.Hash, 
                                      b.Data.FromJson<Employee>()));
            Employees = new Dictionary<string, Employee>(dict);
        }
    }
}