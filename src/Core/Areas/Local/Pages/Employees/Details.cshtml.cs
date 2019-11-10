using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Data.Persistence;
using Domain;
using LiteDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Core.Areas.Local.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly INodeRepository _repository;

        public DetailsModel(INodeRepository repository)
        {
            _repository = repository;
        }

        public void OnGet(string id)
        {
            var objId = new ObjectId(id);
            LocalEmployee = _repository.SingleById<LocalEmployee>(objId);
        }


        [BindProperty]
        public LocalEmployee LocalEmployee { get; set; }
    }
}