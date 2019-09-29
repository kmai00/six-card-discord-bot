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

            var result = _Sut.ChooseRandomStartPlayer();
            Assert.IsTrue(result.IsLeading);
            Assert.IsTrue(GameStateService.Players.Where(p => !p.IsLeading).ToList().Count == 1);
        }

        [Test]
        public void SetStartingPlayer()
        {
            var player_1 = new Player
            {
                Id = 1,
                IsLeading = true
            };
            var player_2 = new Player
            {
                Id = 2,
                IsLeading = true
            };
            var player_3 = new Player
            {
                Id = 2,
                IsLeading = true
            };

            _Sut.AddPlayer(player_1);
            _Sut.AddPlayer(player_2);
            _Sut.AddPlayer(player_3);
            Assert.IsTrue(GameStateService.Players.All(p => p.IsLeading));

            _Sut.SetStartingPlayer(player_1);
            Assert.IsTrue(GameStateService.Players.Where(p => p.IsLeading).ToList().Count == 1);
            Assert.AreEqual(player_1.Id, GameStateService.Players.Single(p => p.IsLeading).Id);
            Assert.IsTrue(GameStateService.Players.Where(p => !p.IsLeading).ToList().Count == 2);
        }
    }
}
