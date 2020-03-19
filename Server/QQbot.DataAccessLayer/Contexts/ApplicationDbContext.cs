using Microsoft.EntityFrameworkCore;
using QQbot.DataAccessLayer.Data;
using QQbot.DataAccessLayer.Entities;

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
			modelBuilder.Entity<Player>().HasIndex(p => p.Name).IsUnique();
			modelBuilder.Entity<Player>().HasIndex(p => p.DiscordId).IsUnique();
			modelBuilder.Entity<LobbyPlayer>().HasIndex(p => p.Player).IsUnique();

			var players = HardCodedPlayerData.GetPlayers();

			foreach (var player in players)
			{
				modelBuilder.Entity<Player>().HasData(player);
			}
		}
	}
}
