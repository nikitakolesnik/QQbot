using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using QQbot.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QQbot.Api.Contexts
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Player> Players { get; set; }
		public DbSet<Match> Matches { get; set; }
		public DbSet<Lobby> Lobbies { get; set; }

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
