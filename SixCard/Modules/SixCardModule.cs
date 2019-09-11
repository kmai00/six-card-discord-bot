using Discord.Commands;
using SixCard.Dtos;
using SixCard.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SixCard.Modules
{
    public class SixCardModule : ModuleBase<SocketCommandContext>
    {
        //Dependcy injected
        public CardService _CardService { get; set; }
        public GameStateService _GameState { get; set; }

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
            var deck = _CardService.MakeUnshuffledDeck();
            var shuffledDeck = _CardService.ShuffleDeck(deck);
            _GameState.SetDeck(shuffledDeck);

            return ReplyAsync("Deck shuffled and ready to go! \n Who's in? (Please reply 'In' to join)");
        }

        //TODO kmai make a DM that draws for players and check if there is enough to deal
        [Command("In")]
        [Summary("Register user to the game")]
        public Task RegisterPlayers()
        {
            var user = Context.User;
            if (_GameState.HasJoined(user.Username))
            {
                return ReplyAsync($"{user.Username} has already joined...");
            }

            _GameState.AddPlayer(user);
            return ReplyAsync($"{user.Username} has joined the game!");
        }

        [Command("Draw")]
        [Summary("Testing Draw Methods")]
        public Task Draw()
        {
            var result = _CardService.Draw(GameStateService.Deck);
            var drawnCard = result.Item1;
            var deck = result.Item2;

            _GameState.SetDeck(deck);

            return ReplyAsync($"You drew: {drawnCard.ToString()} | {deck.Count} cards remaining");
        }
    }
}
