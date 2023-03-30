using Microsoft.EntityFrameworkCore;

namespace Category.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category.Domain.CategoryAggregate.Category> Category { get; set; }
    }
}
