using SixCard.Dtos;
using SixCard.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SixCard.Services
{
    public class CardService
    {
        public CardService() { }

        public List<Card> MakeUnshuffledDeck()
        {
            var deck = new List<Card>();

            foreach (var suit in (Suits[])Enum.GetValues(typeof(Suits)))
            {
                for (int i = 0; i < DefaultValues.NumberOfCards; i++)
                {
                    deck.Add(new Card(i + 2, suit));
                }
            }

            return deck;
        }

        public List<Card> ShuffleDeck(List<Card> deck)
        {
            return deck.Select(c => new Card(c)).OrderBy(c => Guid.NewGuid()).ToList();
        }

        public Tuple<List<Card>, List<Card>> Draw(List<Card> deck, int drawAmount)
        {
            var copyDeck = deck.Select(c => new Card(c)).ToList();

            return new Tuple<List<Card>, List<Card>>(
                copyDeck.Take(drawAmount).ToList(),
                copyDeck.Skip(drawAmount).ToList());
        }

        public Tuple<Card, List<Card>> Draw(List<Card> deck)
        {
            var result = Draw(deck, 1);
            return new Tuple<Card, List<Card>>(result.Item1.First(), result.Item2);
        }

    }
}
