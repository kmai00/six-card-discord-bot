using NUnit.Framework;
using SixCard;
using SixCard.Enums;
using SixCard.Services;
using System;

namespace Tests
{
    [TestFixture]
    public class CardServiceTests
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
                for (int i = 0; i < DefaultValues.NumberOfCards; i++)
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
    }
}
