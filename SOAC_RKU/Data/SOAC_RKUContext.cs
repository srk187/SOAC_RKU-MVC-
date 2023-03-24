using Microsoft.EntityFrameworkCore;
using SOAC_RKU.Models;

namespace SOAC_RKU.Data
{
    public class SOAC_RKUContext: DbContext
    {
        public SOAC_RKUContext(DbContextOptions<SOAC_RKUContext> options) : base(options) 
        { 
            
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Sports> Sports { get; set; }  
        public DbSet<Clubs> Clubs { get; set; }

    }
}
