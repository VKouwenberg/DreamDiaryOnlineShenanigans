using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesDreams.Data
{
    public class RazorPagesDreamsContext : DbContext
    {
        public RazorPagesDreamsContext (DbContextOptions<RazorPagesDreamsContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesMovie.Models.Dream> Dream { get; set; } = default!;
    }
}
