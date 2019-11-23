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
    public class VerificationModel : PageModel
    {
        private readonly INodeRepository _repository;

        public VerificationModel(INodeRepository repository)
        {
            _repository = repository;
        }

        public string VerificationPayload =>
            Organization.GetVerificationMessage();

        public LocalOrganization Organization { get; set; }


        [BindProperty]
        public VerificationInputModel Input { get; set; }

        public IActionResult OnGet(string id)
        {
            Load(id);
            return Page();
        }

        public IActionResult OnPost(string id)
        {
            if (!ModelState.IsValid)
                return Page();

            Load(id);

            Organization.VerificationSignature =
                Input.VerificationSignature;

            var isValid =
                Organization.Verify();

            if (!isValid)
            {
                return BadRequest("Verification Failed");
            }

            _repository.Update(Organization);

            return RedirectToPage("./Details", new { id });
        }

        private void Load(string id)
        {
            var objId = new ObjectId(id);
            Organization = _repository.SingleById<LocalOrganization>(objId);
        }
    }

    public class VerificationInputModel
    {
        [Display(Name = "Verification Signature")]
        public string VerificationSignature { get; set; }
    }
}