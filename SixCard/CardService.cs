using SixCard.Dtos;
using SixCard.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixCard
{
    public class CardService
    {
        public CardService()
        {
            Cards = new List<Card>();
        }

        public static List<Card> Cards;

        public void MakeUnshuffledDeck()
        {
            foreach (var suit in (Suits[])Enum.GetValues(typeof(Suits)))
            {
                for (int i = 0; i < 13; i++)
                {
                    Cards.Add(new Card(i + 2, suit));
                }
            }

        }
    }
}
