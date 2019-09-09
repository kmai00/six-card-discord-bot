using SixCard.Dtos;
using SixCard.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixCard
{
    public class CardService
    {
        public static List<Card> Cards;

        public void MakeDeck()
        {
            foreach (var suit in (Suits[])Enum.GetValues(typeof(Suits)))
            {
                for (int i = 0; i < 12; i++)
                {
                    Cards.Add(new Card(i, suit));
                }
            }
        }
    }
}
