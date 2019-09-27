using Discord;
using Discord.Commands;
using SixCard.Dtos;
using SixCard.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SixCard.Modules
{
    public class SixCardModule : ModuleBase<SocketCommandContext>
    {
        //Dependency injected
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
            //TODO add check for amount of players

            var user = Context.User;
            if (_GameState.HasJoined(user.Username))
            {
                return ReplyAsync($"{user.Username} has already joined...");
            }

            _GameState.AddPlayer(new Player(user));
            return ReplyAsync($"{user.Username} has joined the game!");
        }

        [Command("Start")]
        public Task StartGame()
        {
            var players = GameStateService.Players;
            foreach (var player in players)
            {
                var result = _CardService.Draw(GameStateService.Deck, 6);
                _GameState.SetDeck(result.Item2);
                player.Cards = result.Item1;
                var cards = string.Join("\n", player.Cards);
                player.User.SendMessageAsync($"Your hand is:\n{cards}");
            }
            ReplyAsync("Cards have been delt!");


            var startPlayer = _GameState.ChooseStartPlayer();
            startPlayer.User.SendMessageAsync($"You start the round");

            return ReplyAsync("Game has started");
        }

        [Command("play")]
        public Task Play([Remainder]string input)
        {
            //parse string
            //find that player using Context.user 
            //check if that card even exist in that player hand
            //track is it's the lead
            // iterate to the next player
            return Task.CompletedTask;
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
