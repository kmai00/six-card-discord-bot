﻿using NUnit.Framework;
using SixCard;
using SixCard.Dtos;
using SixCard.Enums;
using SixCard.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class CardServiceTest
    {
        CardService _Sut;

        [SetUp]
        public void Setup()
        {
            _Sut = new CardService();
        }

        [Test]
        public void MakeDeck_CorrectlyMakeStandard52Deck()
        {
            var result = _Sut.MakeUnshuffledDeck();

            Assert.AreEqual(52, result.Count);

            int cardIndex = 0;
            foreach (var suit in (Suits[])Enum.GetValues(typeof(Suits)))
            {
                for (int i = 0; i < DefaultValues.NumberOfCardsPerSuit; i++)
                {
                    Assert.AreEqual(i + 2, result[cardIndex].Value);
                    Assert.AreEqual(suit, result[cardIndex].Suit);
                    cardIndex++;
                }
            }
        }

        [Test]
        public void ShuffleDeck_NotOrderedAtleast()
        {
            // At least one card is different from default
            // I know there a chance that we can get the same deck again, but...come on..this is just for fun

            var unshuffledDeck = _Sut.MakeUnshuffledDeck();
            var shuffledDeck = _Sut.ShuffleDeck(unshuffledDeck);

            var isDifferent = false;
            for (var i = 0; i < 52; i++)
            {
                if (shuffledDeck[i].Value != unshuffledDeck[i].Value)
                {
                    isDifferent = true;
                    break;
                }
            }

            Assert.IsTrue(isDifferent);
        }

        [Test]
        public void Draw_ReturnCorrectCardAndDeck()
        {
            var deck = new List<Card>
            {
                new Card(1, Suits.CLUBS),
                new Card(2, Suits.CLUBS)
            };

            var result = _Sut.Draw(deck);
            var drawnCard = result.Item1;
            var resultingDeck = result.Item2;

            Assert.AreEqual(1, drawnCard.Value);
            Assert.AreEqual(Suits.CLUBS, drawnCard.Suit);
            Assert.AreEqual(1, resultingDeck.Count);
            Assert.AreEqual(2, resultingDeck.First().Value);
            Assert.AreEqual(Suits.CLUBS, resultingDeck.First().Suit);
        }

        [Test]
        public void Draw_MultipleCards()
        {
            var deck = new List<Card>
            {
                new Card(1, Suits.CLUBS),
                new Card(2, Suits.CLUBS)
            };

            var result = _Sut.Draw(deck, 2);
            var drawnCards = result.Item1;
            var resultingDeck = result.Item2;

            Assert.AreEqual(2, drawnCards.Count);
            Assert.IsEmpty(resultingDeck);
        }

        [TestCase(Suits.CLUBS, 1, Suits.DIAMONDS, 1, false)]
        [TestCase(Suits.CLUBS, 1, Suits.CLUBS, 8, false)]
        [TestCase(Suits.CLUBS, 8, Suits.CLUBS, 1, true)]
        public void CanCurrentCardBeatOtherCard(
            Suits currentSuit, int currentValue,
            Suits otherSuit, int otherValue,
            bool expectedResult)
        {
            var currentCard = new Card(currentValue, currentSuit);
            var otherCard = new Card(otherValue, otherSuit);

            var result = _Sut.CanCurrentCardBeatOtherCard(currentCard, otherCard);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void CanCurrentCardBeathOtherCard_ThrowsErrorForSameCard()
        {
            var currentCard = new Card(1, Suits.CLUBS);
            var otherCard = new Card(1, Suits.CLUBS);

            Assert.That(() => _Sut.CanCurrentCardBeatOtherCard(currentCard, otherCard), Throws.Exception.Message.EqualTo("The two cards are the same"));
        }

        [TestCase("1Clubs", "Input: '1Clubs' is not valid.\nPlease enter the two character short hand such as 'AH' for Ace Hearts.")]
        [TestCase("0D", "Input: '0D' is not valid.\n'0' is not a valid card value.")]
        [TestCase("11D", "Input: '11D' is not valid.\n'11' is not a valid card value.")]
        [TestCase("DED", "Input: 'DED' is not valid.\n'DE' is not a valid card value.")]
        [TestCase("AM", "Input: 'AM' is not valid.\n'M' is not a valid card suit.")]
        public void GetCardFromInput_ThrowsException(string input, string expectedErrorMessage)
        {
            Assert.That(() => _Sut.GetCardFromInput(input), Throws.Exception.Message.EqualTo(expectedErrorMessage));
        }

        [Test]
        public void GetCardFromInput_CorrectlyConverts()
        {
            var input = "2D";
            var result = _Sut.GetCardFromInput(input);

            Assert.AreEqual(new Card(2, Suits.DIAMONDS), result);

            input = "JH";
            result = _Sut.GetCardFromInput(input);
            Assert.AreEqual(new Card(11, Suits.HEARTS), result);
        }
    }
}
