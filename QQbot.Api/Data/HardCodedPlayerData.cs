using QQbot.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QQbot.Api.Data
{
	public static class HardCodedPlayerData
	{
		public static IEnumerable<Player> GetPlayers()
		{
			IEnumerable<Player> players = Enumerable.Empty<Player>();

			players.Append(new Player()
			{
				Name = "Slam",
				DiscordId = 240413827718578177,
				PlaysFront = true,
				PlaysBack = true
			});

			players.Append(new Player()
			{
				Name = "Yoko",
				DiscordId = 175325337196953600,
				PlaysFront = true,
				PlaysMid = true
			});

			players.Append(new Player()
			{
				Name = "Candy",
				DiscordId = 287275232236929026,
				PlaysFront = true,
				PlaysMid = true
			});

			players.Append(new Player()
			{
				Name = "Godly",
				DiscordId = 232147476008796161,
				PlaysMid = true
			});

			players.Append(new Player()
			{
				Name = "Santana",
				DiscordId = 416266623847235584,
				PlaysBack = true
			});

			players.Append(new Player()
			{
				Name = "Purif",
				DiscordId = 208987498368598016,
				PlaysMid = true,
				PlaysBack = true
			});

			players.Append(new Player()
			{
				Name = "Chrona",
				DiscordId = 361620009815900170,
				PlaysFront = true,
				PlaysMid = true
			});

			players.Append(new Player()
			{
				Name = "Lisek",
				DiscordId = 382998762533945344,
				PlaysMid = true,
				PlaysBack = true
			});

			players.Append(new Player()
			{
				Name = "Oln",
				DiscordId = 277194459576532992,
				PlaysBack = true
			});

			players.Append(new Player()
			{
				Name = "Rainy",
				DiscordId = 288009866080157697,
				PlaysBack = true
			});

			players.Append(new Player()
			{
				Name = "Butters",
				DiscordId = 465126942656561152,
				PlaysFront = true,
				PlaysMid = true
			});

			players.Append(new Player()
			{
				Name = "Takida",
				DiscordId = 241149128216674305,
				PlaysFront = true
			});

			players.Append(new Player()
			{
				Name = "Jo",
				DiscordId = 99492885015048192,
				PlaysMid = true
			});

			players.Append(new Player()
			{
				Name = "Bounty",
				DiscordId = 221445321530540032,
				PlaysFront = true,
				PlaysMid = true
			});

			players.Append(new Player()
			{
				Name = "Cracks",
				DiscordId = 430796233783640066,
				PlaysFront = true
			});

			players.Append(new Player()
			{
				Name = "Jonas",
				DiscordId = 242126086983516160,
				PlaysFront = true,
				PlaysMid = true,
				PlaysBack = true
			});

			return players;
		}
	}
}
