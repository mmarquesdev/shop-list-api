using Microsoft.EntityFrameworkCore;
using ShopList.Domain.Entities;

namespace ShopList.Infra.Context
{
    public class ShopListDbContext : DbContext
    {
        public ShopListDbContext(DbContextOptions<ShopListDbContext> options)
            : base(options) { }

        public DbSet<Board>? Boards { get; set; }
        public DbSet<BoardItem>? BoardItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopListDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
