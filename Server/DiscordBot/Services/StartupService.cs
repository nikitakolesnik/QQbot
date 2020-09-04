using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace DiscordBot.Services
{
    public class StartupService
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commands;

        public StartupService(DiscordSocketClient client, CommandService commands)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        public async Task StartAsync()
        {
            await _client.LoginAsync(TokenType.Bot, BotToken.Value);
            await _client.StartAsync();

            await _commands.AddModulesAsync(assembly: Assembly.GetEntryAssembly(),
                                            services: null);
        }
    }
}
