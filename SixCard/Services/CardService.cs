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
                for (int i = 0; i < DefaultValues.NumberOfCardsPerSuit; i++)
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

        public Card GetCardFromInput(string input)
        {
            if (input.Length > 3)
            {
                throw new Exception($"Input: '{input}' is not valid.\n" +
                    $"Please enter the two character short hand such as 'AH' for Ace Hearts.");
            }

            string valueInput;
            char suitInput;
            if (input.Length == 2)
            {
                valueInput = input[0].ToString();
                suitInput = input[1];
            }
            else
            {
                valueInput = input.Substring(0, 2);
                suitInput = input[2];
            }

            var isNumericValue = int.TryParse(valueInput, out var valueInt);
            if (
                (valueInt < DefaultValues.LowestNumericCardValue || valueInt > DefaultValues.HighestNumericalCardValue) && isNumericValue ||
                !isNumericValue && !DefaultValues.NonNumericalValueDisplays.Contains(valueInput)
                )
            {
                throw new Exception($"Input: '{input}' is not valid.\n" +
                    $"'{valueInput}' is not a valid card value.");
            }

            int cardValue;
            if (isNumericValue)
            {
                cardValue = valueInt;
            }
            else
            {
                if (valueInput == DefaultValues.JackDisplay)
                {
                    cardValue = DefaultValues.Jack;
                }
                else if (valueInput == DefaultValues.QueenDisplay)
                {
                    cardValue = DefaultValues.Queen;
                }
                else if (valueInput == DefaultValues.KingDisplay)
                {
                    cardValue = DefaultValues.King;
                }
                else
                {
                    cardValue = DefaultValues.Ace;
                }
            }

            if (!DefaultValues.SuitValues.Contains(suitInput))
            {
                throw new Exception($"Input: '{input}' is not valid.\n" +
                    $"'{suitInput}' is not a valid card suit.");
            }

            Suits suitValue = 0;
            switch (suitInput)
            {
                case DefaultValues.Clubs:
                    suitValue = Suits.CLUBS;
                    break;
                case DefaultValues.Diamonds:
                    suitValue = Suits.DIAMONDS;
                    break;
                case DefaultValues.Hearts:
                    suitValue = Suits.HEARTS;
                    break;
                case DefaultValues.Spades:
                    suitValue = Suits.SPADES;
                    break;
            }

            return new Card(cardValue, suitValue);
        }

        //Todo determine if I want to override the > operator
        public bool CanCurrentCardBeatOtherCard(Card currentCard, Card otherCard)
        {
            if (currentCard.Equals(otherCard))
            {
                throw new Exception("The two cards are the same");
            }

            if (currentCard.Suit != otherCard.Suit)
            {
                return false;
            }

            return currentCard.Value > otherCard.Value;
        }

    }
}
