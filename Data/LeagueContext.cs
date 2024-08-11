using Microsoft.EntityFrameworkCore;
using League.Models;

namespace League.Data
{
    public class LeagueContext : DbContext
    {
        public LeagueContext (DbContextOptions<LeagueContext> options)
            : base(options)
        {
        }
        
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Statistic> Statistics {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().ToTable("Player");
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<Statistic>().ToTable("Statistic");
        }
    }
}
