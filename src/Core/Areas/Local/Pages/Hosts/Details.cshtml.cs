using Data.Persistence;
using Domain;
using LiteDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Core.Areas.Local.Pages.Hosts
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly INodeRepository _repository;

        public DetailsModel(
            INodeRepository repository)
        {
            _repository = repository;
        }

        public Host Host { get; set; }

        public IActionResult OnGet(string id)
        {
            var objId = new ObjectId(id);
            Host = _repository.SingleById<Host>(objId);

            return Page();
        }
    }
}