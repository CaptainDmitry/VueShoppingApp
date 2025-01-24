
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ShoopingMarket.Model
{
    public class BDContext: DbContext
    {
        public BDContext()
        {
            Database.EnsureCreated();
        }
        public BDContext(DbContextOptions<BDContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Item> Items { get; set; } = null!;
    }
}
