using SixCard.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixCard.Services
{
    public class GameStateService
    {
        public static List<Card> Deck { get; private set; }

        public GameStateService()
        {
            Deck = new List<Card>();
        }

        public void SetDeck(List<Card> deck)
        {
            Deck = deck;
        }
    }
}
