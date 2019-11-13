using Data.Persistence;
using Domain;
using LiteDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Core.Areas.Chain.Pages.Employees
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly INodeRepository _repository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly OrganizationOptions _orgOptions;

        public DetailsModel(
            INodeRepository repository,
            UserManager<IdentityUser> userManager,
            IOptionsMonitor<OrganizationOptions> orgOptions)
        {
            _repository = repository;
            _userManager = userManager;
            _orgOptions = orgOptions.CurrentValue;
        }

        public LocalEmployee LocalEmployee { get; set; }
        public bool IsCorrectEmployee { get; set; }
        public bool IsAdmin { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var objId = new ObjectId(id);
            LocalEmployee = _repository.SingleById<LocalEmployee>(objId);

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            IsAdmin = await _userManager.IsInRoleAsync(user, "Admin");

            if (!IsAdmin)
            {
                if (user.UserName == LocalEmployee.UserName)
                    IsCorrectEmployee = true;
            }

            if (!IsAdmin && !IsCorrectEmployee)
                return Unauthorized();
            return Page();
        }

        public bool Verify() =>
            LocalEmployee.Verify(
                _orgOptions.PublicKey,
                LocalEmployee.VerificationSignature);
    }
}