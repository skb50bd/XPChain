﻿using Data.Persistence;
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
        private readonly ILedgerRepository _ledger;

        public DetailsModel(
            ILedgerRepository ledger)
        {
            _ledger = ledger;
        }

        public Employee Employee { get; set; }
        public Block Block { get; set; }

        public IActionResult OnGet(string hash)
        {
            Block = _ledger.GetByHash(hash);
            Employee = Block.Data.FromJson<Employee>();
            return Page();
        }
    }
}