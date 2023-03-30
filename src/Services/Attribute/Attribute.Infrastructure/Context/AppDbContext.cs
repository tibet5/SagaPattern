using Microsoft.EntityFrameworkCore;

namespace Attribute.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Attribute.Domain.Entities.AttributeAggregate.Attributes> Attributes { get; set; }
    }
}
