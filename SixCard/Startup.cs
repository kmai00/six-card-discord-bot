using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace SixCard
{
    public class Startup
    {
        private DiscordSocketClient _Client;
        private CommandService _Commands;
        private IServiceProvider _Services;

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public async Task RunBotAsync()
        {
            _Client = new DiscordSocketClient();
            _Commands = new CommandService();

            _Services = new ServiceCollection()
                .AddSingleton(_Client)
                .AddSingleton(_Commands)
                .BuildServiceProvider();
        }
    }
}
