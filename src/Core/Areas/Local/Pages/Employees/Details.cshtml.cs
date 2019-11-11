using Data.Persistence;
using Domain;
using LiteDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Core.Areas.Local.Pages.Employees
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly INodeRepository _repository;
        private readonly UserManager<IdentityUser> _userManager;

        public DetailsModel(
            INodeRepository repository,
            UserManager<IdentityUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public bool IsEmployee { get; set; }
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
                    IsEmployee = true;
            }

            if (!IsAdmin && !IsEmployee)
                return Unauthorized();
            else return Page();
        }


        [BindProperty]
        public LocalEmployee LocalEmployee { get; set; }
    }
}