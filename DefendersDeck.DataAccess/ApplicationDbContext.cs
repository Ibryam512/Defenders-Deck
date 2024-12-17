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
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<TowerLevel> TowerLevels { get; set; }
        public DbSet<EnemyLevel> EnemyLevels { get; set; }

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

            modelBuilder.Entity<Difficulty>(entity =>
            {
                entity
                .HasOne(d => d.EnemyLevel)
                .WithOne(e => e.Difficulty)
                .HasForeignKey<EnemyLevel>(e => e.DifficultyId);

                entity
                .HasOne(d => d.TowerLevel)
                .WithOne(t => t.Difficulty)
                .HasForeignKey<TowerLevel>(t => t.DifficultyId);
            });

            CardsSeed.SeedCards(modelBuilder);
        }
    }
}
