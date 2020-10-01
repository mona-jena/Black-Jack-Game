using System.Collections.Generic;
using Black_Jack_Game;
using Xunit;
using Moq;

namespace ProgramTest
{
    public class PlayerTests
    {
        [Fact]
        public void TestIfPlayersTurnTakesUserInputAndReturnsScore()
        {
            var usersHand = new List<Card>();
            usersHand.AddRange(new[]
            {
                new Card() {Suite = "Diamonds", Value = "8"},
                new Card() {Suite = "Hearts", Value = "6"}
            });
            
            var consoleActionsMock = new Mock<IConsole>();
            consoleActionsMock.SetupSequence(s => s.ReadLine())
                .Returns("1")
                .Returns("0");

            var deckMock = new Mock<IDeck>();
            deckMock.Setup((s => s.DrawCard()))
                .Returns(new Card() {Suite = "Diamonds", Value = "5"});

            Game game = new Game(consoleActionsMock.Object, deckMock.Object);
            Player player = new Player(new ConsoleActions());
            var result = player.PlayersTurn(deckMock.Object);
            var expectedScore = 19;
            Assert.Equal(expectedScore, result);
        }


        [Fact]
        public void TestIfPlayersTurnRemovesTopCardFromDrawCardMethod()
        {
            var usersHand = new List<Card>();
            usersHand.AddRange(new[]
            {
                new Card() {Suite = "Diamonds", Value = "8"},
                new Card() {Suite = "Hearts", Value = "6"}
            });
            int initialScore = 14;

            var consoleActionsMock = new Mock<IConsole>();
            consoleActionsMock.SetupSequence(s => s.ReadLine())
                .Returns("1")
                .Returns("0");

            Game game = new Game(consoleActionsMock.Object, new Deck());
            Deck deck = new Deck();
            var initialDeck = deck.CompleteDeck.Count;
            Player player = new Player(new ConsoleActions());
            player.PlayersTurn(deck);
            var deckAfterDrawCard = deck.CompleteDeck.Count;

            Assert.False(initialDeck.Equals(deckAfterDrawCard));
        }


        //to check if it removed correct card from index 0
        [Fact]
        public void TestIfPlayersTurnReturnsTopCardFromDrawCardMethod()
        {
            var usersHand = new List<Card>();
            usersHand.AddRange(new[]
            {
                new Card() {Suite = "Diamonds", Value = "8"},
                new Card() {Suite = "Hearts", Value = "6"}
            });
            int initialScore = 14;

            var consoleActionsMock = new Mock<IConsole>();
            consoleActionsMock.SetupSequence(s => s.ReadLine())
                .Returns("1")
                .Returns("0");

            Game game = new Game(consoleActionsMock.Object, new Deck());
            Deck deck = new Deck();
            deck.Shuffle();
            var initialTopCard = deck.CompleteDeck[0];
            Player player = new Player(new ConsoleActions());
            player.PlayersTurn(deck);
            var topCardAfterDrawCard = deck.CompleteDeck[0];

            Assert.False(initialTopCard.Equals(topCardAfterDrawCard));
        }

        // REWRITE TEST!!
        /*[Fact]
        public void TestIfDrawFirstTwoCardsReturnsTwoCards()
        {
            Deck newDeck = new Deck();
            Game newGame = new Game(new ConsoleActions(), new Deck());
            Player player = new Player(new ConsoleActions());
            player.DrawFirstTwoCards(newDeck);
            
            Player player = new Player(new ConsoleActions());
            var result = player.DrawFirstTwoCards(newDeck);
            var expected = 2;
            Assert.Equal(result.Count, expected);
        }*/

        [Fact]
        public void TestIfCalculateScoreReturnsTotalSumOfPlayersHandWith3Cards()
        {
            var usersHand = new List<Card>();
            usersHand.AddRange(new[]
            {
                new Card() {Suite = "Diamonds", Value = "Ace"},
                new Card() {Suite = "Hearts", Value = "Ace"},
                new Card() {Suite = "Spades", Value = "Ace"},
            });

            Game game = new Game(new ConsoleActions(), new Deck());
            Player player = new Player(new ConsoleActions());
            int result = player.CalculateScore(usersHand);
            int expected = 13;
            Assert.Equal(expected, result);
        }



        [Fact]
        public void TestIfCalculateScoreReturnsTotalSumOfPlayersHandWith2Cards()
        {
            var usersHand = new List<Card>();
            usersHand.AddRange(new[]
            {
                new Card() {Suite = "Diamonds", Value = "Ace"},
                new Card() {Suite = "Hearts", Value = "Ace"}
            });

            Game game = new Game(new ConsoleActions(), new Deck());
            Player player = new Player(new ConsoleActions());
            int result = player.CalculateScore(usersHand);
            int expected = 12;
            Assert.Equal(expected, result);
        }


        [Fact]
        public void TestIfCalculateScoreReturnsTotalSumOfPlayersHandWith4Cards()
        {
            var usersHand = new List<Card>();
            usersHand.AddRange(new[]
            {
                new Card() {Suite = "Diamonds", Value = "Ace"},
                new Card() {Suite = "Hearts", Value = "5"},
                new Card() {Suite = "Spades", Value = "2"},
                new Card() {Suite = "Diamonds", Value = "3"}
            });

            Game game = new Game(new ConsoleActions(), new Deck());
            Player player = new Player(new ConsoleActions());
            int result = player.CalculateScore(usersHand);
            int expected = 21;
            Assert.Equal(expected, result);
        }


        [Fact]
        public void TestIfCalculateScoreReturnsTotalSumOfPlayersHandWith5Cards()
        {
            var usersHand = new List<Card>();
            usersHand.AddRange(new[]
            {
                new Card() {Suite = "Diamonds", Value = "2"},
                new Card() {Suite = "Hearts", Value = "2"},
                new Card() {Suite = "Spades", Value = "4"},
                new Card() {Suite = "Spades", Value = "10"},
                new Card() {Suite = "Spades", Value = "Ace"},
            });

            Game game = new Game(new ConsoleActions(), new Deck());
            Player player = new Player(new ConsoleActions());
            int result = player.CalculateScore(usersHand);
            int expected = 19;
            Assert.Equal(expected, result);
        }
    }
}