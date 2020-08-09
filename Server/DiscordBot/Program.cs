using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace DiscordBot
{
	public class Program
	{
		private DiscordSocketClient _client;

		public static void Main(/*string[] args*/)
			=> new Program().MainAsync().GetAwaiter().GetResult();
		
		public async Task MainAsync()
		{
			_client = new DiscordSocketClient(new DiscordSocketConfig
			{
				LogLevel = LogSeverity.Info
			});

			_client.Log += Log;
			_client.MessageReceived += MessageReceived;

			await _client.LoginAsync(TokenType.Bot, BotToken.Token);
			await _client.StartAsync();

			await Task.Delay(-1); // Block this task until the program is closed.
		}

		private Task Log(LogMessage msg)
		{
			Console.WriteLine(msg.ToString());
			return Task.CompletedTask;
		}

		private async Task MessageReceived(SocketMessage message)
		{
			if (message.Content == "!ping")
			{
				await message.Channel.SendMessageAsync("Pong!");
			}
		}
	}
}
