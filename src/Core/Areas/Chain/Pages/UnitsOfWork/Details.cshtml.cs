using Data.Persistence;
using Domain;
using LiteDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Core.Areas.Chain.Pages.UnitsOfWork
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

        public UnitOfWork UnitOfWork { get; set; }
        public Block Block { get; set; }
        
        public IActionResult OnGet(string hash)
        {
            Block = _ledger.GetByHash(hash);

            if (Block is null || Block.Type != typeof(UnitOfWork).Name)
                return NotFound();

            UnitOfWork = Block.Data.FromJson<UnitOfWork>();
            return Page();
        }
    }
}