using System.Collections.Generic;
using System.Linq;
using Black_Jack_Game;
using Xunit;
using Moq;

namespace ProgramTest
{
    public class GameTests
    {
        [Fact]
        public void TestIfPlayersTurnTakesUserInputAndDrawsCard()
        {
            Deck deck = new Deck() { };

            List<string> shuffledDeck = new List<string>()
            {
                "5 of Diamonds",
                "10 of Clubs",
                "3 of Clubs",
                "4 of Clubs",
                "5 of Clubs",
                "6 of Clubs",
                "7 of Clubs",
                "8 of Clubs",
                "9 of Clubs",
                "Kind of Diamonds",
                "Jack of Clubs",
                "Queen of Clubs",
                "Kind of Clubs",
                "Ace of Clubs",
                "2 of Diamonds",
                "3 of Diamonds",
                "4 of Diamonds",
                "6 of Diamonds",
                "7 of Diamonds",
                "8 of Diamonds",
                "9 of Diamonds",
                "10 of Diamonds",
                "Jack of Diamonds",
                "Queen of Diamonds",
                "8 of Hearts",
                "Ace of Diamonds",
                "2 of Hearts",
                "3 of Hearts",
                "4 of Hearts",
                "5 of Hearts",
                "6 of Hearts",
                "7 of Hearts",
                "5 of Spades",
                "9 of Hearts",
                "10 of Hearts",
                "Jack of Hearts",
                "2 of Clubs",
                "Queen of Hearts",
                "Kind of Hearts",
                "Ace of Hearts",
                "2 of Spades",
                "3 of Spades",
                "4 of Spades",
                "Jack of Spades",
                "6 of Spades",
                "7 of Spades",
                "8 of Spades",
                "9 of Spades",
                "10 of Spades",
                "Queen of Spades",
                "Kind of Spades",
                "Ace of Spades"
            };

            List<string> playersHand = new List<string>() {"3 of Hearts", "5 of Clubs"};
            var consoleActionsMock = new Mock<IConsole>();
            consoleActionsMock.SetupSequence(s => s.ReadLine())
                .Returns("1")
                .Returns("0");

            int expected = 3;
            Game game = new Game(consoleActionsMock.Object);
            int result = game.PlayersTurn(playersHand, deck, shuffledDeck).Count;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestIfPlayersTurnReturnsTopCardFromDrawCardMethod()
        {
            Deck deck = new Deck() { };

            List<string> shuffledDeck = new List<string>()
            {
                "5 of Diamonds",
                "10 of Clubs",
                "3 of Clubs",
                "4 of Clubs",
                "5 of Clubs",
                "6 of Clubs",
                "7 of Clubs",
                "8 of Clubs",
                "9 of Clubs",
                "Kind of Diamonds",
                "Jack of Clubs",
                "Queen of Clubs",
                "Kind of Clubs",
                "Ace of Clubs",
                "2 of Diamonds",
                "3 of Diamonds",
                "4 of Diamonds",
                "6 of Diamonds",
                "7 of Diamonds",
                "8 of Diamonds",
                "9 of Diamonds",
                "10 of Diamonds",
                "Jack of Diamonds",
                "Queen of Diamonds",
                "8 of Hearts",
                "Ace of Diamonds",
                "2 of Hearts",
                "3 of Hearts",
                "4 of Hearts",
                "5 of Hearts",
                "6 of Hearts",
                "7 of Hearts",
                "5 of Spades",
                "9 of Hearts",
                "10 of Hearts",
                "Jack of Hearts",
                "2 of Clubs",
                "Queen of Hearts",
                "Kind of Hearts",
                "Ace of Hearts",
                "2 of Spades",
                "3 of Spades",
                "4 of Spades",
                "Jack of Spades",
                "6 of Spades",
                "7 of Spades",
                "8 of Spades",
                "9 of Spades",
                "10 of Spades",
                "Queen of Spades",
                "Kind of Spades",
                "Ace of Spades"
            };

            List<string> playersHand = new List<string>() {"3 of Hearts", "5 of Clubs"};
            var consoleActionsMock = new Mock<IConsole>();
            consoleActionsMock.SetupSequence(s => s.ReadLine())
                .Returns("1")
                .Returns("0");

            var deckMock = new Mock<IDeck>();
            deckMock.Setup((s => s.DrawCard(shuffledDeck)))
                .Returns("5 of Diamonds");

            List<string> expected = new List<string>() {"3 of Hearts", "5 of Clubs", "5 of Diamonds"};
            Game game = new Game(consoleActionsMock.Object);
            List<string> result = game.PlayersTurn(playersHand, deck, shuffledDeck);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("3 of Hearts", "5 of Clubs", "5 of Diamonds", 13)]
        [InlineData("Ace of Hearts", "5 of Clubs", "Queen of Diamonds", 32)]
        public void TestIfCalculateSumReturnsTotalSumOfPlayersHand(string card1, string card2, string card3, int expected)
        {
            List<string> playersHand = new List<string>();
            playersHand.Add(card1);
            playersHand.Add(card2);
            playersHand.Add(card3);
            
            Game game = new Game(new ConsoleActions());
            int result = game.CalculateScore(playersHand);
            Assert.Equal(expected, result);
        }
        
    }
}