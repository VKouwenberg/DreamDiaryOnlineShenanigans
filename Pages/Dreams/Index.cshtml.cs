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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesDreams.Data.RazorPagesDreamsContext _context;

        public IndexModel(RazorPagesDreams.Data.RazorPagesDreamsContext context)
        {
            _context = context;
        }

        public IList<Dream> Dream { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? SleepQualitys { get; set; } //Genres

        [BindProperty(SupportsGet = true)]
        public string? DreamSleepQuality { get; set; } //MovieGenre

        public async Task OnGetAsync()
        {
            //LINQ list of sleep qualities
            IQueryable<string> sleepQualityQuery = from m in _context.Dream
                                                   orderby m.SleepQuality
                                                   select m.SleepQuality;

            var Dreams = from m in _context.Dream
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                Dreams = Dreams.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(DreamSleepQuality)) 
            {
                Dreams = Dreams.Where(x => x.SleepQuality == DreamSleepQuality);
            }

            SleepQualitys = new SelectList(await sleepQualityQuery.Distinct().ToListAsync());
            Dream = await Dreams.ToListAsync();
        }
    }
}
