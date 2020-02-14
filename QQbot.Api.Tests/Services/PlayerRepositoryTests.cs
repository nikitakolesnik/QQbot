using Microsoft.VisualStudio.TestTools.UnitTesting;
using QQbot.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QQbot.Api.Tests.Services
{
	[TestClass]
	public class PlayerRepositoryTests
	{
		private IPlayerRepository _repository;

		[TestInitialize]
		public async Task TestInitialize(IPlayerRepository repository)
		{
			_repository = repository;
		}

		[TestMethod]
		public async Task ShouldReturnPlayerByName()
		{

		}

		[TestMethod]
		public async Task ShouldReturnPlayerById()
		{

		}

		[TestMethod]
		public async Task ShouldReturnPlayerByDiscordId()
		{

		}
	}
}
