using System.ComponentModel.DataAnnotations;
using Data.Persistence;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Core.Areas.Local.Pages.Hosts
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

            var host = new Host
            {
                Address = Input.Address,
                Port = Input.Port,
                PublicKey = Input.PublicKey,
                IsVerified = false
            };

            _repository.Insert(host);
            return RedirectToPage("./Index");
        }

        [BindProperty]
        public InputModel Input { get; set; }
    }

    public class InputModel
    {
        public string Address { get; set; }
        public int Port { get; set; }

        [Display(Name = "Public Key")]
        public string PublicKey { get; set; }
    }
}