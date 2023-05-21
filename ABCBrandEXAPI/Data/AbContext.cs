using ABCBrandEXAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ABCBrandEXAPI.Data
{
    public class AbContext : DbContext
    {
        public AbContext(DbContextOptions<AbContext> options) : base(options) { } // db context for ABC Brand DB

        public DbSet<Carton> Cartons { get; set; } // db table for carton

    }
}
