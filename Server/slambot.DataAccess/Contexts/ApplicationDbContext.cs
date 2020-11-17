using Microsoft.EntityFrameworkCore;
using slambot.DataAccess.Data;
using slambot.DataAccess.Entities;
using slambot.Common.Enums;
using slambot.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using slambot.Common;

namespace slambot.DataAccess.Contexts
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<AdminAction> AdminActions { get; set; }
		public DbSet<LobbyPlayer> LobbyPlayers { get; set; }
		public DbSet<Match>       Matches      { get; set; }
		public DbSet<Player>      Players      { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Player>(b =>
			{
				b.HasIndex(p => p.Name).IsUnique();
				b.HasIndex(p => p.Discord).IsUnique();
			});

            modelBuilder.Entity<LobbyPlayer>(b =>
            {
                b.HasIndex(lp => lp.PlayerId).IsUnique();
            });

            IEnumerable<Player> players = HardCodedPlayerData.GetPlayers();
			foreach (Player player in players)
			{
				modelBuilder.Entity<Player>().HasData(player);
				modelBuilder.Entity<AdminAction>().HasData(new AdminAction 
				{ 
					Id = player.Id, 
					AdminId = 1, 
					Type = AdminActionType.ActionPlayer, 
					SubjectPlayerId = player.Id 
				});
			}

            if (MatchConfiguration.SeedTestMatches == true)
            {
                Random r = new Random();

                for (int i = 0; i < MatchConfiguration.TestMatchesToSeed + 1; i++)
                {
                    List<int> team1 = new();
                    List<int> team2 = new();

                    // Force player 1 to be in the match

                    //int playerTeam = r.Next(1, 3);
                    //if (playerTeam == 1) team1.Add(1);
                    //else team2.Add(1);


                    // Decide winning team

                    int winningTeamRoll = r.Next(0, 101);
                    TeamNumber winningTeam;
                    if (winningTeamRoll > 50)
                        winningTeam = TeamNumber.Team1;
                    else if (winningTeamRoll < 50)
                        winningTeam = TeamNumber.Team2;
                    else
                        winningTeam = TeamNumber.None;


                    // Fill teams randomly

                    while (team1.Count < 8)
                    {
                        int newPlayer = r.Next(2, players.Count() + 1);
                        if (!team1.Contains(newPlayer))
                            team1.Add(newPlayer);
                    }

                    while (team2.Count < 8)
                    {
                        int newPlayer = r.Next(2, players.Count() + 1);
                        if (!team1.Contains(newPlayer) && !team2.Contains(newPlayer))
                            team2.Add(newPlayer);
                    }


                    // convert to string of IDs

                    team1.Sort();
                    string team1str = Utilities.ListToStr(team1);
                    team2.Sort();
                    string team2str = Utilities.ListToStr(team2);


                    // create row

                    modelBuilder.Entity<Match>().HasData(new Match
                    {
                        Id = i + 1,
                        WinningTeam = winningTeam,
                        Team1 = team1str,
                        Team2 = team2str,
                        Status = Status.Approved
                    });
                }
            
            }
        }
	}
}
