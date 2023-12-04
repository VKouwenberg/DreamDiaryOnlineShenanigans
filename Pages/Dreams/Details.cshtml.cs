using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesDreams.Data;
using RazorPagesMovie.Models;

namespace RazorPagesDreams.Pages.Dreams
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesDreams.Data.RazorPagesDreamsContext _context;

        public DetailsModel(RazorPagesDreams.Data.RazorPagesDreamsContext context)
        {
            _context = context;
        }

      public Dream Dream { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Dream == null)
            {
                return NotFound();
            }

            var dream = await _context.Dream.FirstOrDefaultAsync(m => m.Id == id);
            if (dream == null)
            {
                return NotFound();
            }
            else 
            {
                Dream = dream;
            }
            return Page();
        }
    }
}
