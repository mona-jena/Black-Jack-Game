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
            Deck newDeck = new Deck(new ConsoleActions());
            Game newGame = new Game(new ConsoleActions(), new Deck(new ConsoleActions()));
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

            Game game = new Game(consoleActionsMock.Object, new Deck(new ConsoleActions()));
            Deck deck = new Deck(new ConsoleActions());
            var initialDeck = deck.completeDeck.Count;
            game.PlayersTurn(usersHand, deck, initialScore);
            var deckAfterDrawCard = deck.completeDeck.Count;

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

            Game game = new Game(consoleActionsMock.Object, new Deck(new ConsoleActions()));
            Deck deck = new Deck(new ConsoleActions());
            deck.Shuffle();
            var initialTopCard = deck.completeDeck[0];
            game.PlayersTurn(usersHand, deck, initialScore);
            var topCardAfterDrawCard = deck.completeDeck[0];

            Assert.False(initialTopCard.Equals(topCardAfterDrawCard));
        }
        
        
        // [Theory]
        // [InlineData("3 of Hearts", "5 of Clubs", "5 of Diamonds", 13)]
        // [InlineData("Ace of Hearts", "5 of Clubs", "Queen of Diamonds", 16)]
        // public void TestIfCalculateScoreReturnsTotalSumOfPlayersHand(string card1, string card2, string card3, int expected)
        
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

            Game game = new Game(new ConsoleActions(),new Deck(new ConsoleActions()));
            int result = game.CalculateScore(usersHand);
            int expected = 13;
            Assert.Equal(expected, result);
        }
        
        /*[Theory]
        [InlineData("2 of Hearts", "2 of Clubs", 4)]
        [InlineData("6 of Diamonds", "Ace of Hearts", 17)]
        [InlineData("6 of Diamonds", "1 of Hearts", 7)]
        [InlineData("2 of Diamonds", "Ace of Hearts", 13)]
        [InlineData("10 of Diamonds", "Ace of Hearts", 21)]
        [InlineData("Ace of Diamonds", "Ace of Hearts", 12)]
        public void TestIfCalculateScoreReturnsTotalSumOfPlayersHandWithTwoCards(string card1, string card2, int expected)
        {
            List<string> playersHand = new List<string>();
            playersHand.Add(card1);
            playersHand.Add(card2);

            Game game = new Game(new ConsoleActions());
            int result = game.CalculateScore(playersHand);
            Assert.Equal(expected, result);
        }*/
        
        [Fact]
        public void TestIfCalculateScoreReturnsTotalSumOfPlayersHandWith2Cards()
        {
            var usersHand = new List<Card>();
            usersHand.AddRange(new[]
            {
                new Card() {Suite = "Diamonds", Value = "Ace"},
                new Card() {Suite = "Hearts", Value = "Ace"}
            });

            Game game = new Game(new ConsoleActions(),new Deck(new ConsoleActions()));
            int result = game.CalculateScore(usersHand);
            int expected = 12;
            Assert.Equal(expected, result);
        }
        
        /*
        [Theory]
        [InlineData("2 of Hearts", "5 of Clubs", "4 of Diamonds", "10 of Spades", 21)]
        [InlineData("6 of Diamonds", "Ace of Hearts", "5 of Clubs", "7 of Diamonds", 19)]
        [InlineData("6 of Diamonds", "1 of Hearts", "6 of Clubs", "7 of Diamonds", 20)]
        [InlineData("2 of Diamonds", "Ace of Hearts", "King of Clubs", "7 of Diamonds", 20)]
        public void TestIfCalculateScoreReturnsTotalSumOfPlayersHandWithFourCards(string card1, string card2, string card3, string card4, int expected)
        {
            List<Card> playersHand = new List<Card>();
            playersHand.Add(card1);
            playersHand.Add(card2);
            playersHand.Add(card3);
            playersHand.Add(card4);
            
            Game game = new Game(new ConsoleActions());
            int result = game.CalculateScore(playersHand);
            Assert.Equal(expected, result);
        } */
        
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

            Game game = new Game(new ConsoleActions(),new Deck(new ConsoleActions()));
            int result = game.CalculateScore(usersHand);
            int expected = 21;
            Assert.Equal(expected, result);
        }
        
        
        /*
        [Theory]
        [InlineData("2 of Hearts", "2 of Clubs", "4 of Diamonds", "10 of Spades", "Ace of Diamonds", 19)]
        [InlineData("6 of Diamonds", "Ace of Hearts", "5 of Clubs", "7 of Diamonds", "8 of Clubs", 27)]
        [InlineData("6 of Diamonds", "1 of Hearts", "6 of Clubs", "7 of Diamonds", "Ace of Diamonds", 21)]
        [InlineData("2 of Diamonds", "Ace of Hearts", "King of Clubs", "7 of Diamonds", "Ace of Diamonds", 19)]
        public void TestIfCalculateScoreReturnsTotalSumOfPlayersHandWithFiveCards(string card1, string card2, string card3, string card4, string card5, int expected)
        {
            List<string> playersHand = new List<string>();
            playersHand.Add(card1);
            playersHand.Add(card2);
            playersHand.Add(card3);
            playersHand.Add(card4);
            playersHand.Add(card5);
            
            Game game = new Game(new ConsoleActions());
            int result = game.CalculateScore(playersHand);
            Assert.Equal(expected, result);
        }*/
        
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

            Game game = new Game(new ConsoleActions(),new Deck(new ConsoleActions()));
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

            Game game = new Game(new ConsoleActions(), new Deck(new ConsoleActions()));
            Deck deck = new Deck(new ConsoleActions());
            var result = game.DealersTurn(dealersHand, new Deck(new ConsoleActions()), initialScore);
            var expected = 19;
            Assert.Equal(result, expected);
        }
        
        
        [Fact]
        public void TestIfWinOrLossDuringGamePrintsCorrectlyWhenItsDealersTurnAndScoreIs21()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                
                Game game = new Game(new ConsoleActions(), new Deck(new ConsoleActions()));
                Deck deck = new Deck(new ConsoleActions());
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
        
        // CAN'T TEST print statement if ifPlayersTurn = true as cannot change this local class variable 
        // CAN'T TEST if score > 21 as the other print statements get in the way
        
        /*[Fact]
        public void TestIfWinOrLossDuringGamePrintsCorrectlyWhenItsDealersTurnAndScoreIsOver21()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                
                Game game = new Game(new ConsoleActions(), new Deck(new ConsoleActions()));
                Deck deck = new Deck(new ConsoleActions());
                int score = 30;
                var gamersHand = new List<Card>();
                gamersHand.AddRange(new[]
                {
                    new Card() {Suite = "Diamonds", Value = "8"},
                    new Card() {Suite = "Hearts", Value = "Ace"}
                });
                
                game.WinOrLossDuringGame(score, gamersHand);

                string expected = string.Format("Player Wins!{0}", Environment.NewLine);
                Assert.Equal(expected, sw.ToString());
            }
        }*/
        
        
        [Theory]
        [InlineData(15, 20)]
        [InlineData(18, 16)]
        [InlineData(18, 18)]
        public void TestIfIsWinnerPrintsCorrectOutput(int playersScore, int dealersScore)
        {
            
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                
                Game game = new Game(new ConsoleActions(), new Deck(new ConsoleActions()));
                Deck deck = new Deck(new ConsoleActions());
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