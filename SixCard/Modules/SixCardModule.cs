using Discord.Commands;
using SixCard.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SixCard.Modules
{
    public class SixCardModule : ModuleBase<SocketCommandContext>
    {
        private static List<Card> Deck;
        //Dependcy injected
        public CardService _CardService { get; set; }

        [Command("New")]
        public Task NewGame()
        {
            // Basically make a new deck
            // Deal the deck to x amount of players (TODO figure out how to parse that)
            Deck = _CardService.MakeUnshuffledDeck();
            Deck = _CardService.ShuffleDeck(Deck);

            return ReplyAsync("New Deck generated");
        }

        [Command("Draw")]
        public Task Draw()
        {
            var card = Deck[0];
            Deck.RemoveAt(0);

            return ReplyAsync($"You drew: {card.ToString()} | {Deck.Count} cards remaining");
        }
    }
}
