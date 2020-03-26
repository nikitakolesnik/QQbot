using Microsoft.EntityFrameworkCore;
using QQbot.DataAccessLayer.Data;
using QQbot.DataAccessLayer.Entities;
using System.Collections.Generic;

namespace QQbot.DataAccessLayer.Contexts
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Player> Players { get; set; }
		public DbSet<Match> Matches { get; set; }
		public DbSet<LobbyPlayer> LobbyPlayers { get; set; }
		public DbSet<Team> Teams { get; set; }
		public DbSet<TeamPlayer> TeamPlayers { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
			//Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Player>(b =>
			{
				b.HasIndex(p => p.Name).IsUnique();
				b.HasIndex(p => p.Discord).IsUnique();
			});

			IEnumerable<Player> players = HardCodedPlayerData.GetPlayers();
			foreach (var player in players)
			{
				modelBuilder.Entity<Player>().HasData(player);
			}
		}
	}
}
