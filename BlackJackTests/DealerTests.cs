using System;
using System.Collections.Generic;
using System.IO;
using Black_Jack_Game;
using Xunit;
using Moq;

namespace ProgramTest
{
    public class DealerTests
    {

        [Fact]
        public void TestIfDealersTurnStopsDrawingCardsWhenScoreReaches17()
        {
            var dealersHand = new List<Card>();
            dealersHand.AddRange(new[]
            {
                new Card() {Suite = "Diamonds", Value = "8"},
                new Card() {Suite = "Hearts", Value = "Ace"}
            });
            bool isGameOver = false;

            Game game = new Game(new ConsoleActions(), new Deck());
            Deck deck = new Deck();
            Dealer dealer = new Dealer(new ConsoleActions());
            var result = dealer.DealersTurn(new Deck(), isGameOver);
            var expected = 19;
            Assert.Equal(result, expected);
        }
    }
}