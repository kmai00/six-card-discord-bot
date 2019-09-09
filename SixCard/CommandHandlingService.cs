using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace SixCard
{
    public class CommandHandlingService : ModuleBase<SocketCommandContext>
    {
        private readonly CommandService _Commands;
        private readonly DiscordSocketClient _Discord;
        private IServiceProvider _Services;

        public CommandHandlingService(IServiceProvider services)
        {
            _Commands = services.GetRequiredService<CommandService>();
            _Discord = services.GetRequiredService<DiscordSocketClient>();
            _Services = services;

            //Command Hook
            _Commands.CommandExecuted += CommandExecutedAsync;
            _Discord.MessageReceived += MessageReceivedAsync;
        }

        public async Task InitializeAsync()
        {
            await _Commands.AddModulesAsync(Assembly.GetEntryAssembly(), _Services);
        }

        public async Task MessageReceivedAsync(SocketMessage rawMessage)
        {
            //Ignore system messages or messages from other bots
            if (!(rawMessage is SocketUserMessage message)) return;
            if (message.Source != MessageSource.User) return;

            message.

            var argPos = 0;
            if (!message.HasMentionPrefix(_Discord.CurrentUser, ref argPos)) return;

            var context = new SocketCommandContext(_Discord, message);

            await _Commands.ExecuteAsync(context, argPos, _Services);
        }

        public async Task CommandExecutedAsync(Optional<CommandInfo> command, ICommandContext context, IResult result)
        {
            if (!command.IsSpecified) return;

            if (result.IsSuccess) return;

            //Alert error
            await context.Channel.SendMessageAsync($"error: {result}");
        }
    }
}
