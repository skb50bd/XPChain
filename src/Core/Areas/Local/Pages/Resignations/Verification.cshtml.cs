using Data.Persistence;
using Domain;
using LiteDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using Domain.Local;

namespace Core.Areas.Local.Pages.Resignations
{
    [Authorize(Roles = "Employee")]
    public class VerificationModel : PageModel
    {
        private readonly INodeRepository _repository;
        private readonly OrganizationOptions _orgOptions;

        public VerificationModel(
            INodeRepository repository,
            IOptionsMonitor<OrganizationOptions> orgOptions)
        {
            _repository = repository;
            _orgOptions = orgOptions.CurrentValue;
        }

        public bool IsCorrectEmployee { get; set; }
        public string VerificationPayload =>
            Resignation.GetVerificationMessage(_orgOptions.PublicKey);

        public LocalResignation Resignation { get; set; }
        public LocalEmployee Employee { get; set; }

        [BindProperty]
        public VerificationInputModel Input { get; set; }

        public IActionResult OnGet(string id)
        {
            Load(id);

            if (!IsCorrectEmployee)
            {
                return Unauthorized();
            }

            return Page();
        }

        public IActionResult OnPost(string id)
        {
            if (!ModelState.IsValid)
                return Page();

            Load(id);

            if (!IsCorrectEmployee) return Unauthorized();

            var resignation =
                _repository.SingleById<LocalResignation>(id);
            resignation.EmployeeSignature = Input.VerificationSignature;
            if (resignation.Verify(_orgOptions.PublicKey))
            {
                _repository.Update(resignation);
                return RedirectToPage("./Details", new { id });
            }

            return BadRequest("Invalid Signature");
        }

        private void Load(string id)
        {
            Resignation = _repository.SingleById<LocalResignation>(id);

            Employee = _repository.SingleOrDefault<LocalEmployee>(
                e => e.PublicKey == Resignation.EmployeePublicKey);

            IsCorrectEmployee =
                User.Identity.Name
             == Employee.UserName;
        }
    }

    public class VerificationInputModel
    {
        [Display(Name = "Verification Signature")]
        public string VerificationSignature { get; set; }
    }
}