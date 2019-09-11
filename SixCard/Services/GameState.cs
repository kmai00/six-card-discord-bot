using Discord.WebSocket;
using SixCard.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SixCard.Services
{
    public class GameStateService
    {
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

        public void AddPlayer(SocketUser player)
        {
            Players.Add(new Player(player));
        }

        public bool HasJoined(string username)
        {
            return Players.Any(p => p.Name == username);
        }
    }
}
