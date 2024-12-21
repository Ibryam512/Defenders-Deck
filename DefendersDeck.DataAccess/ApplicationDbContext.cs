using DefendersDeck.DataAccess.Seeds;
using DefendersDeck.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DefendersDeck.DataAccess
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Card> Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Card>(entity =>
            {
                entity
                .HasMany(c => c.Users)
                .WithMany(u => u.Cards);

                entity
                .HasMany(c => c.Games)
                .WithMany(g => g.Cards);
            });

            CardsSeed.SeedCards(modelBuilder);
        }
    }
}
