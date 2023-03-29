using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private FootballTeam team;
        FootballPlayer player;
        private List<FootballPlayer> players;
        private string name;
        private int capacity;

        [SetUp]
        public void Setup()
        {
            name = "Marek-Dupnica";
            capacity = 21;
            team = new FootballTeam(name, capacity);
            players = new List<FootballPlayer>();
            player = new("Gosho", 19, "Forward");
        }

        [Test]
        public void ConstructorMakeNewTeamCorrectly()
        {
            Assert.AreEqual("Marek-Dupnica", team.Name);
            Assert.AreEqual(21, team.Capacity);
            Assert.AreEqual(0, team.Players.Count);
        }

        [Test]
        public void IfNameIsNullOrEmptyShouldThrowException()
        {
            name = string.Empty;

            Assert.Throws<ArgumentException>(() => team = new FootballTeam(name, capacity));
            Assert.Throws<ArgumentException>(() => team = new FootballTeam(null, capacity));
        }

        [Test]
        public void IfCapacityIsSmallerThan15ShouldThrowException()
        {
            capacity = 14;

            Assert.Throws<ArgumentException>(() => team = new FootballTeam(name, capacity));
        }

        [Test]
        public void CantAddNewPlayerWhenPlayersAreEqualOrHigherThanCapacity()
        {
            for (int i = 0; i < 22; i++)
            {
                team.AddNewPlayer(player);
            }

            Assert.AreEqual("No more positions available!", team.AddNewPlayer(player));
        }

        [Test]
        public void AddNewPlayerToTeam()
        {
            Assert.AreEqual($"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}", team.AddNewPlayer(player));
            Assert.AreEqual(1, team.Players.Count);
        }

        [Test]
        public void PickPlayerShouldReturnPLayer()
        {
            team.AddNewPlayer(player);

            Assert.AreEqual(player, team.PickPlayer("Gosho"));
        }

        [Test]
        public void PickPlayerShouldReturnNull()
        {
            Assert.AreEqual(null, team.PickPlayer("Gosho"));
        }

        [Test]
        public void PlayerScoreReturnHowGoalsHasForThisSeason()
        {
            team.AddNewPlayer(player);

            Assert.AreEqual($"{player.Name} scored and now has {player.ScoredGoals + 1} for this season!", team.PlayerScore(19));
        }
    }
}