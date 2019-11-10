using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Data.Persistence;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Core.Areas.Local.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly INodeRepository _repository;

        public CreateModel(INodeRepository repository)
        {
            _repository = repository;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var emp = new LocalEmployee
            {
                Name = Input.Name,
                Email = Input.Email,
                Phone = Input.Phone,
                Address = Input.Address,
                Designation = Input.Designation,
                PublicKey = Input.PublicKey,
                BirthDate = Input.BirthDate,
                StartDate = Input.StartDate
            };

            _repository.Insert(emp);

            return RedirectToPage("./Index");
        }

        [BindProperty]
        public InputModel Input { get; set; }
    }
    public class InputModel
    {
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        public string Address { get; set; }
        public string Designation { get; set; }

        [Display(Name = "Public Key")]
        public string PublicKey { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
    }
}