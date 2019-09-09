using SixCard.Dtos;
using SixCard.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixCard
{
    public class CardService
    {
        public CardService() { }

        public List<Card> MakeUnshuffledDeck()
        {
            var cards = new List<Card>();

            foreach (var suit in (Suits[])Enum.GetValues(typeof(Suits)))
            {
                for (int i = 0; i < DefaultValues.NumberOfCards; i++)
                {
                    cards.Add(new Card(i + 2, suit));
                }
            }

            return cards;
        }
    }
}
