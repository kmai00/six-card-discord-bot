using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discord.WebSocket;
using NUnit.Framework;
using SixCard.Dtos;
using SixCard.Services;

namespace Tests
{

    [TestFixture]
    public class GameStateTest
    {
        GameStateService _Sut;

        [SetUp]
        public void Setup()
        {
            _Sut = new GameStateService();
        }

        [Test]
        public void ChooseStartPlayer()
        {
            _Sut.AddPlayer(new Player());
            _Sut.AddPlayer(new Player());
            Assert.IsTrue(GameStateService.Players.All(p => !p.IsLeading));

            var result = _Sut.ChooseStartPlayer();
            Assert.IsTrue(result.IsLeading);
            Assert.IsTrue(GameStateService.Players.Where(p => !p.IsLeading).ToList().Count == 1);
        }
    }
}
