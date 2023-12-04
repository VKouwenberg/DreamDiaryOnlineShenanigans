using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesDreams.Data;
using RazorPagesMovie.Models;

namespace RazorPagesDreams.Pages.Dreams
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesDreams.Data.RazorPagesDreamsContext _context;

        public EditModel(RazorPagesDreams.Data.RazorPagesDreamsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dream Dream { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Dream == null)
            {
                return NotFound();
            }

            var dream =  await _context.Dream.FirstOrDefaultAsync(m => m.Id == id);
            if (dream == null)
            {
                return NotFound();
            }
            Dream = dream;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Dream).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DreamExists(Dream.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DreamExists(int id)
        {
          return (_context.Dream?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
