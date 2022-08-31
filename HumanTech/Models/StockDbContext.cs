using Microsoft.EntityFrameworkCore;

namespace HumanTech.Models
{
    public class StockDbContext : DbContext
    {
        public StockDbContext(DbContextOptions<StockDbContext> options) : base(options) { }

        public DbSet<Stock> Stocks { get; set; }
    }
}
