using Data.Persistence;
using Domain;
using LiteDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Core.Areas.Local.Pages.Organizations
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly INodeRepository _repository;

        public CreateModel(
            INodeRepository repository)
        {
            _repository = repository;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var org = new LocalOrganization
            {
                Id = ObjectId.NewObjectId(),
                Title = Input.Title,
                Address = Input.Address,
                Email = Input.Email,
                Phone = Input.Phone,
                PublicKey = Input.PublicKey
            };

            _repository.Insert(org);
            return RedirectToPage("./Index");
        }

        [BindProperty]
        public InputModel Input { get; set; }
    }

    public class InputModel
    {
        public string Title { get; set; }
        public string Address { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Display(Name = "Public Key")]
        public string PublicKey { get; set; }
    }
}