using QQbot.DataAccess.Entities;
using QQbot.Enums;
using System;
using System.Collections.Generic;

namespace QQbot.DataAccess.Data
{
	public static class HardCodedPlayerData
	{
		public static IEnumerable<Player> GetPlayers()
		{
			List<Player> players = new List<Player>
			{ 
				new Player()
				{
					Name = "Slam",
					Discord = 240413827718578177
				},
				new Player()
				{
					Name = "Yoko",
					Discord = 175325337196953600
				},

				new Player()
				{
					Name = "Candyboy",
					Discord = 287275232236929026
				},

				new Player()
				{
					Name = "Godly",
					Discord = 232147476008796161
				},

				new Player()
				{
					Name = "Santana",
					Discord = 416266623847235584
				},

				new Player()
				{
					Name = "Purif",
					Discord = 208987498368598016
				},

				new Player()
				{
					Name = "Chrona",
					Discord = 361620009815900170
				},

				new Player()
				{
					Name = "Lisek",
					Discord = 382998762533945344
				},

				new Player()
				{
					Name = "Oln",
					Discord = 277194459576532992
				},

				new Player()
				{
					Name = "Rainy",
					Discord = 288009866080157697
				},

				new Player()
				{
					Name = "Butters",
					Discord = 465126942656561152
				},

				new Player()
				{
					Name = "Takida",
					Discord = 241149128216674305
				},

				new Player()
				{
					Name = "Jo",
					Discord = 99492885015048192
				},

				new Player()
				{
					Name = "Bounty",
					Discord = 221445321530540032
				},

				new Player()
				{
					Name = "Cracks",
					Discord = 430796233783640066
				},

				new Player()
				{
					Name = "Jonas",
					Discord = 242126086983516160
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
