using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URL_Shortener.Core.Entities;

namespace URL_Shortener.EF.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContext) : base(dbContext)
        {
            
        }

        public DbSet<ShortenedLinks> ShortenedLinks { get; set; }
    }
}
