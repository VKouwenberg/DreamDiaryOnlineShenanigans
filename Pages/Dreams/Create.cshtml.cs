using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesDreams.Data;
using RazorPagesMovie.Models;

namespace RazorPagesDreams.Pages.Dreams
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesDreams.Data.RazorPagesDreamsContext _context;

        public CreateModel(RazorPagesDreams.Data.RazorPagesDreamsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Dream Dream { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Dream == null || Dream == null)
            {
                return Page();
            }

            _context.Dream.Add(Dream);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
