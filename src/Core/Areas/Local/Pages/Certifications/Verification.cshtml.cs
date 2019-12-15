using Crypto;
using Data.Persistence;
using Domain;
using LiteDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;
using Domain.Local;

namespace Core.Areas.Local.Pages.Certifications
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
            Certificate.GetVerificationMessage(_orgOptions.PublicKey);

        public LocalEmployee LocalEmployee { get; set; }
        public LocalCertificate Certificate { get; set; }

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

            var certificate =
                _repository.SingleById<LocalCertificate>(new ObjectId(id));
            certificate.ReceiverSignature = Input.VerificationSignature;
            if (certificate.Verify(_orgOptions.PublicKey))
            {
                _repository.Update(certificate);
                return RedirectToPage("./Details", new {id});
            }

            return BadRequest("Invalid Signature");
        }

        private void Load(string id)
        {
            var objId = new ObjectId(id);

            Certificate = _repository.SingleById<LocalCertificate>(objId);

            LocalEmployee = _repository.SingleOrDefault<LocalEmployee>(
                e => e.PublicKey == Certificate.ReceiverPublicKey);

            IsCorrectEmployee =
                User.Identity.Name
             == LocalEmployee.UserName;
        }
    }

    public class VerificationInputModel
    {
        [Display(Name = "Verification Signature")]
        public string VerificationSignature { get; set; }
    }
}