using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace SixCard
{
    public class Startup
    {
        private const string TOKEN = "NjIwMzg5MjYzMzEzNDY5NDQw.XXWEvQ.Yutd04W3Y2-poSjmgM7VD8mLxPY";

        public static void Main(string[] args)
        {
            new Startup().MainAsync().GetAwaiter().GetResult();
        }

        public async Task MainAsync()
        {
            using (var services = ConfigurationServices())
            {
                var client = services.GetRequiredService<DiscordSocketClient>();

                client.Log += LogAsync;
                services.GetRequiredService<CommandService>().Log += LogAsync;

                await client.LoginAsync(TokenType.Bot, TOKEN);
                await client.StartAsync();

                await services.GetRequiredService<CommandHandlingService>().InitializeAsync();

                await Task.Delay(-1);
            }
        }

        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log.ToString());

            return Task.CompletedTask;
        }

        private ServiceProvider ConfigurationServices()
        {
            return new ServiceCollection()
                .AddSingleton<DiscordSocketClient>()
                .AddSingleton<CommandService>()
                .AddSingleton<CommandHandlingService>()
                .AddSingleton<HttpClient>()
                .AddSingleton<CardService>()
                .BuildServiceProvider();
        }
    }
}
