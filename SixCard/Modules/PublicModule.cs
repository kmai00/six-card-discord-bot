using Discord.Commands;
using System.Threading.Tasks;

namespace SixCard.Modules
{
    public class PublicModule : ModuleBase<SocketCommandContext>
    {
        private static int Counter;

        [Command("!help")]
        public Task Help()
        {
            //TODO kmai use text file to handle the instructions
            return ReplyAsync("This bot will run a full game of 6 Cards. This bot was created by Kevin Mai.");
        }

        [Command("test")]
        [Alias("world")]
        public Task Test()
        {
            return ReplyAsync("Hello World");
        }

        [Command("Counter")]
        public Task IncreaseCounter()
        {
            Counter++;
            return ReplyAsync($"Counter: {Counter}");
        }

        [Command("echo")]
        public Task Echo([Remainder]string input)
        {
            return ReplyAsync(input);
        }

    }
}
