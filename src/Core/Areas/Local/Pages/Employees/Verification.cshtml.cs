using Crypto;
using Data.Persistence;
using Domain;
using LiteDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using Domain.Local;

namespace Core.Areas.Local.Pages.Employees
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
            LocalEmployee.GetVerificationMessage(_orgOptions.PublicKey);

        public LocalEmployee LocalEmployee { get; set; }


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
            if (IsCorrectEmployee)
            {
                var isValid =
                    LocalEmployee.Verify(
                        _orgOptions.PublicKey,
                        Input.VerificationSignature);

                var isIdentityValid =
                    SignatureProvider.Verify(
                        LocalEmployee.IdentificationMessage,
                        Input.IdentificationSignature,
                        LocalEmployee.PublicKey);

                if (!isValid || !isIdentityValid)
                {
                    return BadRequest(
                        $"Verification Signature: {isValid}. Identity Signature: {isIdentityValid}. Verification Failed");
                }

                LocalEmployee.IdentificationSignature =
                    Input.IdentificationSignature;

                LocalEmployee.VerificationSignature =
                    Input.VerificationSignature;

                _repository.Update(LocalEmployee);

                return RedirectToPage("./Details", new { id });
            }
            else
            {
                return Unauthorized();
            }
        }

        private void Load(string id)
        {
            var objId = new ObjectId(id);
            LocalEmployee = _repository.SingleById<LocalEmployee>(objId);

            IsCorrectEmployee =
                User.Identity.Name
             == LocalEmployee.UserName;
        }
    }

    public class VerificationInputModel
    {
        [Display(Name = "Verification Signature")]
        public string VerificationSignature { get; set; }

        [Display(Name = "Identification Signature")]
        public string IdentificationSignature { get; set; }
    }
}