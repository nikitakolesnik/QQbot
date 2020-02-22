using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QQbot.Api.Data;
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
		}
	}
}
