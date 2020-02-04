using System;
using Discord.WebSocket;
using SixCard.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace SixCard.Services
{
    public class GameStateService
    {
        //TODO pretty sure sense this is exposing the Players, it will still be modified
        public static List<Card> Deck { get; private set; }
        public static List<Player> Players { get; private set; }

        public static Card WinningCard { get; private set; }

        private static int CurrentPlayerIndex { get; set; }

        public GameStateService()
        {
            Deck = new List<Card>();
            Players = new List<Player>();
            CurrentPlayerIndex = 0;
        }

        public void SetDeck(List<Card> deck)
        {
            Deck = deck;
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public void AddPlayers(List<Player> players)
        {
            Players.AddRange(players);
        }

        public bool HasJoined(string username)
        {
            return Players.Any(p => p.Name == username);
        }

        public Player ChooseRandomStartPlayer()
        {
            ClearStartPlayers();
            var index = new Random().Next(0, Players.Count);
            var startPlayer = Players[index];
            startPlayer.IsLeading = true;

            return startPlayer;
        }

        public void SetStartingPlayer(Player player)
        {
            ClearStartPlayers();
            CurrentPlayerIndex = Players.FindIndex(p => p.Id == player.Id);
            var startingPlayer = Players[CurrentPlayerIndex];
            startingPlayer.IsLeading = true;
        }

        private void ClearStartPlayers()
        {
            foreach (var player in Players)
            {
                player.IsLeading = false;
            }
        }

        // Get the current player's turn
        public Player GetCurrentPlayer()
        {
            return Players[CurrentPlayerIndex];
        }

        public Player NextTurn()
        {
            var nextIndex = CurrentPlayerIndex + 1;
            CurrentPlayerIndex = nextIndex < Players.Count ? nextIndex : 0;

            return Players[CurrentPlayerIndex];
        }

        public void SetWinningCard(Card card)
        {
            WinningCard = card;
        }
    }
}
