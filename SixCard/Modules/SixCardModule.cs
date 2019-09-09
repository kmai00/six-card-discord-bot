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
            // Prompt player to see who's in. Make check in to determine possible
            //Use message user as key to manage thatn
            //DM player's hand
            //DM player current status hand
            //Keep track of starting player (index)
            //Rotate players
            //Special rule for final
            //property for who's in or not
            //Player object
            Deck = _CardService.MakeUnshuffledDeck();
            Deck = _CardService.ShuffleDeck(Deck);

            return ReplyAsync("New Deck generated");
        }

        //TODO kmai make a DM that draws for players and check if there is enough to deal


        [Command("Draw")]
        [Summary("Testing Draw Methods")]
        public Task Draw()
        {
            var card = Deck[0];
            Deck.RemoveAt(0);

            return ReplyAsync($"You drew: {card.ToString()} | {Deck.Count} cards remaining");
        }
    }
}
