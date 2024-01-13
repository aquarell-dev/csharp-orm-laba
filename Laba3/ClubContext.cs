using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Laba3
{
    public class ClubContext : DbContext
    {
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                .HasOne(t => t.Clubs)
                .WithMany(c => c.Teams)
                .HasForeignKey(t => t.clubId);

            modelBuilder.Entity<Owner>()
                .HasMany(o => o.Clubs)
                .WithMany(c => c.Owners);
        }

        public ClubContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(ConfigurationManager.AppSettings["ConnectionString"]);
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }
    }
}