using Microsoft.EntityFrameworkCore;
using QQbot.Api.Entities;
using QQbot.Api.Data;
using System.Collections;

namespace QQbot.Api.Contexts
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Player> Players { get; set; }
		public DbSet<Match> Matches { get; set; }
		public DbSet<Lobby> Lobby { get; set; } // Singular - only one queue ever exists
		public DbSet<Team> Teams { get; set; }
		public DbSet<TeamPlayer> TeamPlayers { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
			//Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Player>().HasIndex(p => p.Name).IsUnique();
			
			modelBuilder.Entity<Player>().HasIndex(p => p.DiscordId).IsUnique();

			modelBuilder.Entity<Player>().HasData(new HardCodedPlayerData().GetPlayers());
		}
	}
}
