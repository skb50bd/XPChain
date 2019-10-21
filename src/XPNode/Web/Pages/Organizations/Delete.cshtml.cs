﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using XPNode.Domain;

namespace Web.Pages.Organizations
{
    public class DeleteModel : PageModel
    {
        private readonly Web.Data.ApplicationDbContext _context;

        public DeleteModel(Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Organization Organization { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Organization = await _context.Organization.FirstOrDefaultAsync(m => m.Id == id);

            if (Organization == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Organization = await _context.Organization.FindAsync(id);

            if (Organization != null)
            {
                _context.Organization.Remove(Organization);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
