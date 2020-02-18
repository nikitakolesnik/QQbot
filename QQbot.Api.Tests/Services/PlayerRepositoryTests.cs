using Microsoft.VisualStudio.TestTools.UnitTesting;
using QQbot.Api.Data;
using QQbot.Api.Entities;
using QQbot.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQbot.Api.Tests.Services
{
	[TestClass]
	public class PlayerRepositoryTests
	{
		[TestInitialize]
		public void TestInitialize()
		{

		}

		[TestMethod]
		public void ShouldCreatePlayerData()
		{
			var players = HardCodedPlayerData.GetPlayers();

			Assert.AreEqual(players.First().Name, "Slam");
			//Assert.AreEqual(1, 1);
		}

		//[TestMethod]
		//public async Task ShouldReturnPlayerByDiscordId()
		//{
		//	var player = await _repository.GetPlayerByDiscordIdAsync(240413827718578177);

		//	Assert.AreEqual(player.Name, "Slam");
		//}
	}
}
