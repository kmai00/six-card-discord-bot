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

        public static List<SocketUser> Players { get; private set; }

        public GameStateService()
        {
            Deck = new List<Card>();
            Players = new List<SocketUser>();
        }

        public void SetDeck(List<Card> deck)
        {
            Deck = deck;
        }

        public void AddPlayer(SocketUser player)
        {
            Players.Add(player);
        }

        public bool HasJoined(string username)
        {
            return Players.Any(p => p.Username == username);
        }
    }
}
