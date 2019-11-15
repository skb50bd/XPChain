using Data.Persistence;
using Domain;
using LiteDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace Core.Areas.Chain.Pages.Projects
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ILedgerRepository _ledger;
        private readonly OrganizationOptions _orgOptions;

        public CreateModel(
            ILedgerRepository ledger,
            IOptionsMonitor<OrganizationOptions> orgOptionsMonitor)
        {
            _orgOptions = orgOptionsMonitor.CurrentValue;
            _ledger = ledger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var project = new Project
            {
                Id = ObjectId.NewObjectId(),
                Title = Input.Title,
                Organization = _orgOptions.PublicKey,
                TotalXp = Input.TotalXp,
                Description = Input.Description
            };

            var previousHash = _ledger.GetLastBlockHash();
            var block = new Block
            {
                Id = ObjectId.NewObjectId(),
                Data = project.ToJson(),
                Type = typeof(Project).Name,
                Originator = project.Organization,
                PreviousBlockHash = previousHash
            };
            block.Sign(_orgOptions.PrivateKey)
                 .SetHash();

            _ledger.Insert(block);

            return RedirectToPage("./Details", new { hash = block.Hash });
        }
    }

    public class InputModel
    {
        [Display(Name = "Project Title")]
        public string Title { get; set; }

        [Display(Name = "Total Experience Points")]
        public decimal TotalXp { get; set; }

        public string Description { get; set; }
    }
}