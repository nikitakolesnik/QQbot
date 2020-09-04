using System;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;

namespace DiscordBot.Modules
{
	// Create a module with no prefix
	public class TestModule : ModuleBase<SocketCommandContext>
	{
		// ~say hello world
		[Command("say")]
		public Task SayAsync([Remainder] string echo)
			=> ReplyAsync(echo); // ReplyAsync is a method on ModuleBase 

		// ~square 20
		[Command("square")]
		public async Task SquareAsync(
			int num)
		{
			await Context.Channel.SendMessageAsync($"{num}^2 = {Math.Pow(num, 2)}");
		}

		// ~info
		[Command("info")]
		public async Task UserInfoAsync(SocketUser user = null)
		{
			var userInfo = user ?? Context.Client.CurrentUser;
			await ReplyAsync($"{userInfo.Username}#{userInfo.Discriminator}");
		}
	}
}
