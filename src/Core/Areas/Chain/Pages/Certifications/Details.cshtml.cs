using Data.Persistence;
using Domain;
using LiteDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Core.Areas.Chain.Pages.Certifications
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly ILedgerRepository _ledger;
        
        public DetailsModel(
            ILedgerRepository ledger)
        {
            _ledger = ledger;
        }

        public Certificate Certificate { get; set; }
        public Block Block { get; set; }
        
        public IActionResult OnGet(string hash)
        {
            Block = _ledger.GetByHash(hash);

            if (Block is null || Block.Type != typeof(Certificate).Name)
                return NotFound();

            Certificate = Block.Data.FromJson<Certificate>();
            return Page();
        }
    }
}