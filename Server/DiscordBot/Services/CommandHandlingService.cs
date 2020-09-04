using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace DiscordBot.Services
{
    public class CommandHandlingService
    {
        private const char _prefix = '~';

        private readonly DiscordSocketClient _client;
        private readonly CommandService _commands;
        private readonly IServiceProvider _provider;

        public CommandHandlingService(DiscordSocketClient client, CommandService commands, IServiceProvider provider)
        {
            _commands = commands;
            _client = client;
            _provider = provider;

            _client.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync(SocketMessage messageParam)
        {
            SocketUserMessage message = messageParam as SocketUserMessage;
            if (message == null)
            {
                return; // Don't process the command if it was a system message
            }
            
            int argPos = 0; // Create a number to track where the prefix ends and the command begins
            if (!(message.HasCharPrefix(_prefix, ref argPos) || message.HasMentionPrefix(_client.CurrentUser, ref argPos)) || message.Author.IsBot)
            {
                return; // Determine if the message is a command based on the prefix and make sure no bots trigger commands
            }

            SocketCommandContext context = new SocketCommandContext(_client, message); // Create a WebSocket-based command context based on the message
            IResult result = await _commands.ExecuteAsync(context, argPos, _provider);
            if (!result.IsSuccess)
            {
                await context.Channel.SendMessageAsync(result.ErrorReason);
            }
        }
    }
}
