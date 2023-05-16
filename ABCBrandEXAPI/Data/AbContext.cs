using ABCBrandEXAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ABCBrandEXAPI.Data
{
    public class AbContext : DbContext
    {
        public AbContext(DbContextOptions<AbContext> options) : base(options) { }

        public DbSet<Carton> Cartons { get; set; }

    }
}
