using NUnit.Framework;
using SixCard;
using SixCard.Enums;
using System;

namespace Tests
{
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
            _Sut.MakeUnshuffledDeck();

            var result = CardService.Cards;
            Assert.AreEqual(52, result.Count);

            int cardIndex = 0;
            foreach (var suit in (Suits[])Enum.GetValues(typeof(Suits)))
            {
                for (int i = 0; i < 12; i++)
                {
                    Assert.AreEqual(i + 2, result[cardIndex].Value);
                    Assert.AreEqual(suit, result[cardIndex].Suit);
                }
            }
        }

    }
}
