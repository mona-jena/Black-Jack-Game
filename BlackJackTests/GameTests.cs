using System;
using System.Collections.Generic;
using System.IO;
using Black_Jack_Game;
using Xunit;
using Moq;

namespace ProgramTest
{
    public class GameTests
    {
        [Fact]
        public void TestIfDrawFirstTwoCardsReturnsTwoCards()
        {
            Deck newDeck = new Deck();
            Game newGame = new Game(new ConsoleActions(), new Deck());
            var result = newGame.DrawFirstTwoCards(newDeck);
            var expected = 2;
            Assert.Equal(result.Count, expected);
        }


        [Fact]
        public void TestIfPlayersTurnTakesUserInputAndReturnsScore()
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

            var deckMock = new Mock<IDeck>();
            deckMock.Setup((s => s.DrawCard()))
                .Returns(new Card() {Suite = "Diamonds", Value = "5"});
            
            Game game = new Game(consoleActionsMock.Object, deckMock.Object);
            var result = game.PlayersTurn(usersHand, deckMock.Object, initialScore);
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
            game.PlayersTurn(usersHand, deck, initialScore);
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
            game.PlayersTurn(usersHand, deck, initialScore);
            var topCardAfterDrawCard = deck.CompleteDeck[0];

            Assert.False(initialTopCard.Equals(topCardAfterDrawCard));
        }
        
        
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

            Game game = new Game(new ConsoleActions(),new Deck());
            int result = game.CalculateScore(usersHand);
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

            Game game = new Game(new ConsoleActions(),new Deck());
            int result = game.CalculateScore(usersHand);
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

            Game game = new Game(new ConsoleActions(),new Deck());
            int result = game.CalculateScore(usersHand);
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

            Game game = new Game(new ConsoleActions(),new Deck());
            int result = game.CalculateScore(usersHand);
            int expected = 19;
            Assert.Equal(expected, result);
        }
        
        
        [Fact]
        public void TestIfDealersTurnStopsDrawingCardsWhenScoreReaches17()
        {
            var dealersHand = new List<Card>();
            dealersHand.AddRange(new[]
            {
                new Card() {Suite = "Diamonds", Value = "8"},
                new Card() {Suite = "Hearts", Value = "Ace"}
            });
            int initialScore = 19;

            Game game = new Game(new ConsoleActions(), new Deck());
            Deck deck = new Deck();
            var result = game.DealersTurn(dealersHand, new Deck(), initialScore);
            var expected = 19;
            Assert.Equal(result, expected);
        }
        
        
        [Fact]
        public void TestIfWinOrLossDuringGamePrintsCorrectlyWhenItsDealersTurnAndScoreIs21()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                
                Game game = new Game(new ConsoleActions(), new Deck());
                Deck deck = new Deck();
                int score = 21;
                var gamersHand = new List<Card>();
                gamersHand.AddRange(new[]
                {
                    new Card() {Suite = "Diamonds", Value = "8"},
                    new Card() {Suite = "Hearts", Value = "Ace"}
                });
                
                game.WinOrLossDuringGame(score, gamersHand);

                string expected = string.Format("Black Jack! Dealer wins!{0}", Environment.NewLine);
                Assert.Equal(expected, sw.ToString());
            }
        }
        

        
        [Fact]
        public void TestIfWinOrLossDuringGamePrintsCorrectlyWhenItsDealersTurnAndScoreIsOver21()
        {
            var consoleActionsMock = new Mock<IConsole>();
            
            Game game = new Game(consoleActionsMock.Object, new Deck());
            Deck deck = new Deck();
            int score = 30; 
            var gamersHand = new List<Card>();
            gamersHand.AddRange(new[]
            {
                new Card() {Suite = "Diamonds", Value = "8"},
                new Card() {Suite = "Hearts", Value = "Ace"}
            });
                
            game.WinOrLossDuringGame(score, gamersHand);
            consoleActionsMock.Verify(consoleMock => consoleMock.WriteLine("\nPlayer Wins!"));
            
        }
        
        
        [Theory]
        [InlineData(15, 20)]
        [InlineData(18, 16)]
        [InlineData(18, 18)]
        public void TestIfIsWinnerPrintsCorrectOutput(int playersScore, int dealersScore)
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                
                Game game = new Game(new ConsoleActions(), new Deck());
                Deck deck = new Deck();
                game.IsWinner(playersScore, dealersScore);

                string expected = "";
                if (playersScore > dealersScore)
                {
                    expected = string.Format("Player Wins!{0}", Environment.NewLine);
                } 
                else if (playersScore < dealersScore)
                {
                    expected = string.Format("Dealer Wins!{0}", Environment.NewLine);
                }
                else
                {
                    expected = string.Format("It's a draw!{0}", Environment.NewLine);
                }
                
                Assert.Equal(expected, sw.ToString());
            }
        }
        
    }
}