using MGQSBreakfast.Entities;
using Microsoft.EntityFrameworkCore;

namespace MGQSBreakfast.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Breakfast> Breakfasts { get; set; }
    }
}
