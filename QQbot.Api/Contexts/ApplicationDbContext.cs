using Microsoft.EntityFrameworkCore;
using QQbot.Api.Entities;

namespace QQbot.Api.Contexts
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Player> Players { get; set; }
		public DbSet<Match> Matches { get; set; }
		public DbSet<Queue> Queue { get; set; } // Singular - only one queue ever exists
		public DbSet<Team> Teams { get; set; }
		public DbSet<TeamPlayer> TeamPlayers { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
			//Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Player>().HasData(
				new Player()
				{
					Name = "Candyboy",
					PlaysFront = true,
					PlaysMid = true
				},
				new Player()
				{
					Name = "Yoko",
					PlaysFront = true,
					PlaysMid = true
				}
			);
		}
	}
}
