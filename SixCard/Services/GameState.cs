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

        public GameStateService()
        {
            Deck = new List<Card>();
            Players = new List<Player>();
        }

        public void SetDeck(List<Card> deck)
        {
            Deck = deck;
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public bool HasJoined(string username)
        {
            return Players.Any(p => p.Name == username);
        }

        public Player ChooseStartPlayer()
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
            var startingPlayer = Players.Single(p => p.Id == player.Id);
            startingPlayer.IsLeading = true;
        }

        private void ClearStartPlayers()
        {
            foreach (var player in Players)
            {
                player.IsLeading = false;
            }
        }
    }
}
