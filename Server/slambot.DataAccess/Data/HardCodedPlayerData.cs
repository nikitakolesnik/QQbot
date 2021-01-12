using slambot.Common.Enums;
using slambot.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace slambot.DataAccess.Data
{
	public static class HardCodedPlayerData
	{
		public static int PlayerCount()
		{
			return GetPlayers().Count();
		}

		public static IEnumerable<Player> GetPlayers()
		{
			List<Player> players = new()
			{
				new()
				{
					Name = "Slam",
					Discord = 240413827718578177
				},
				new()
				{
					Name = "Yoko",
					Discord = 175325337196953600
				},

				new()
				{
					Name = "Candyboy",
					Discord = 287275232236929026
				},

				new()
				{
					Name = "Godly",
					Discord = 232147476008796161
				},

				new()
				{
					Name = "Santana",
					Discord = 416266623847235584
				},

				new()
				{
					Name = "Purif",
					Discord = 208987498368598016
				},

				new()
				{
					Name = "Chrona",
					Discord = 361620009815900170
				},

				new()
				{
					Name = "Lisek",
					Discord = 382998762533945344
				},

				new()
				{
					Name = "Oln",
					Discord = 277194459576532992
				},

				new()
				{
					Name = "Rainy",
					Discord = 288009866080157697
				},

				new()
				{
					Name = "Butters",
					Discord = 465126942656561152
				},

				new()
				{
					Name = "Takida",
					Discord = 241149128216674305
				},

				new()
				{
					Name = "Jo",
					Discord = 99492885015048192
				},

				new()
				{
					Name = "Bounty",
					Discord = 221445321530540032
				},

				new()
				{
					Name = "Cracks",
					Discord = 430796233783640066
				},

				new()
				{
					Name = "Jonas",
					Discord = 242126086983516160
				},

				new()
				{
					Name = "Jim",
					Discord = 581965183669501952
				},

				new()
				{
					Name = "Holye",
					Discord = 273617664457310210
				},

				new()
				{
					Name = "Maga",
					Discord = 310713367683923968
				},

				new()
				{
					Name = "Calvin",
					Discord = 235062551724032000
				},

				new()
				{
					Name = "Kam",
					Discord = 179021286645694464
				},

				new()
				{
					Name = "Lynie",
					Discord = 170238151732887552
				},

				new()
				{
					Name = "Zynkh",
					Discord = 614187828531691739
				},

				new()
				{
					Name = "Luke",
					Discord = 478594642602885121
				}
			};

			int count = 1;
			foreach (var player in players)
			{
				player.Id = count++;
				player.Status = Status.Approved;
			}

			return players;
		}
	}
}
