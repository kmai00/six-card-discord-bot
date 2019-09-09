using Discord.Commands;
using System.Threading.Tasks;

namespace SixCard.Modules
{
    public class PublicModule : ModuleBase<SocketCommandContext>
    {
        //Dependcy injected
        public CardService CardService { get; set; }

        [Command("test")]
        [Alias("world")]
        public Task Test()
        {
            return ReplyAsync(CardService.Test());
        }
    }
}
