using System.Collections.Generic;
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
            var shuffledDeck = new List<string>()
            {
                "8,Diamonds",
                "6,Hearts",
                "2,Clubs",
                "3,Clubs",
                "4,Clubs",
                "5,Clubs",
                "6,Clubs",
                "7,Clubs",
                "8,Clubs",
                "9,Clubs",
                "10,Clubs",
                "Jack,Clubs",
                "Queen,Clubs",
                "King,Clubs",
                "Ace,Clubs",
                "2,Diamonds",
                "3,Diamonds",
                "4,Diamonds",
                "5,Diamonds",
                "6,Diamonds",
                "7,Diamonds",
                "9,Diamonds",
                "10,Diamonds",
                "Jack,Diamonds",
                "Queen,Diamonds",
                "King,Diamonds",
                "Ace,Diamonds",
                "2,Hearts",
                "3,Hearts",
                "4,Hearts",
                "5,Hearts",
                "7,Hearts",
                "8,Hearts",
                "9,Hearts",
                "10,Hearts",
                "Jack,Hearts",
                "Queen,Hearts",
                "King,Hearts",
                "Ace,Hearts",
                "2,Spades",
                "3,Spades",
                "4,Spades",
                "5,Spades",
                "6,Spades",
                "7,Spades",
                "8,Spades",
                "9,Spades",
                "10,Spades",
                "Jack,Spades",
                "Queen,Spades",
                "King,Spades",
                "Ace,Spades"
            };
            
            /*var newDeck = new List<Card>();
            for (int i = 0; i < shuffledDeck.Count; i++)
            {
                string[] splitCard =  shuffledDeck[i].Split(",");
                Card card = new Card()
                {
                    Suite = splitCard[1],
                    Value = splitCard[0]
                };
                newDeck.Add(card);
            }
            
            
            Game game = new Game(new ConsoleActions());

            var usersHand = new List<Card>();
            Card card1 = new Card()
            {
                Suite = "Diamonds",
                Value = "8"
            };
            usersHand.Add(card1);
            Card card2 = new Card()
            {
                Suite = "Hearts",
                Value = "6"
            };
            usersHand.Add(card2);

            var result = game.DrawFirstTwoCards(new Deck(new ConsoleActions()));
            Assert.Equal(usersHand, result);*/
            
            Deck newDeck = new Deck(new ConsoleActions());
            Game newGame = new Game(new ConsoleActions());
            var result = newGame.DrawFirstTwoCards(newDeck);
            var expected = 2;
            Assert.Equal(result.Count, expected);

        }
        
        
        
        [Fact]
        public void TestIfPlayersTurnTakesUserInputAndReturnsScore()
        {
            var shuffledDeck = new List<string>()
            {
                "[5, Diamonds]",
                "[10, Clubs]",
                "[3, Clubs]",
                "[4, Clubs]",
                "[5, Clubs]",
                "[6, Clubs]",
                "[7, Clubs]",
                "[8, Clubs]",
                "[9, Clubs]",
                "[King, Diamonds]",
                "[Jack, Clubs]",
                "[Queen, Clubs]",
                "[Kind, Clubs]",
                "[Ace, Clubs]",
                "[2, Diamonds]",
                "[3, Diamonds]",
                "[4, Diamonds]",
                "[6, Diamonds]",
                "[7, Diamonds]",
                "[8, Diamonds]",
                "[9, Diamonds]",
                "[10, Diamonds]",
                "[Jack, Diamonds]",
                "[Queen, Diamonds]",
                "[8, Hearts]",
                "[Ace, Diamonds]",
                "[2, Hearts]",
                "[3, Hearts]",
                "[4, Hearts]",
                "[5, Hearts]",
                "[6, Hearts]",
                "[7, Hearts]",
                "[5, Spades]",
                "[9, Hearts]",
                "[10, Hearts]",
                "[Jack, Hearts]",
                "[2, Clubs]",
                "[Queen, Hearts]",
                "[King, Hearts]",
                "[Ace, Hearts]",
                "[2, Spades]",
                "[3, Spades]",
                "[4, Spades]",
                "[Jack, Spades]",
                "[6, Spades]",
                "[7, Spades]",
                "[8, Spades]",
                "[9, Spades]",
                "[10, Spades]",
                "[Queen, Spades]",
                "[King, Spades]",
                "[Ace, Spades]"
            };

            IDeck deck = new Deck(new ConsoleActions());

            List<Card> playersHand = new List<Card>() {"3 of Hearts", "5 of Clubs"};
            var consoleActionsMock = new Mock<IConsole>();
            consoleActionsMock.SetupSequence(s => s.ReadLine())
                .Returns("1")
                .Returns("0");
            int intialScore = 8;

            int expected = 13;
            Game game = new Game(consoleActionsMock.Object);
            int result = game.PlayersTurn(playersHand, deck, intialScore);
            Assert.Equal(expected, result);
            //Assert.True(list1.);
        }

        [Fact]
        public void TestIfPlayersTurnReturnsTopCardFromDrawCardMethod()
        {
            Deck deck = new Deck(new ConsoleActions());

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
                "King of Clubs",
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
                "King of Hearts",
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
                "King of Spades",
                "Ace of Spades"
            };

            List<string> playersHand = new List<string>() {"3 of Hearts", "5 of Clubs"};
            var consoleActionsMock = new Mock<IConsole>();
            consoleActionsMock.SetupSequence(s => s.ReadLine())
                .Returns("1")
                .Returns("0");

            var deckMock = new Mock<IDeck>();
            deckMock.Setup((s => s.DrawCard()))
                .Returns("5 of Diamonds");
            int initialScore = 8;

            List<string> expected = new List<string>() {"3 of Hearts", "5 of Clubs", "5 of Diamonds"};
            Game game = new Game(consoleActionsMock.Object);
            List<Card> result = game.PlayersTurn(playersHand, deckMock.Object, initialScore);
            Assert.Equal(expected, result);
        }
        //check if it removed index 0
        
        [Theory]
        [InlineData("3 of Hearts", "5 of Clubs", "5 of Diamonds", 13)]
        [InlineData("Ace of Hearts", "5 of Clubs", "Queen of Diamonds", 16)]
        public void TestIfCalculateScoreReturnsTotalSumOfPlayersHand(string card1, string card2, string card3, int expected)
        {
            List<string> playersHand = new List<string>();
            playersHand.Add(card1);
            playersHand.Add(card2);
            playersHand.Add(card3);
            
            Game game = new Game(new ConsoleActions());
            int result = game.CalculateScore(playersHand);
            Assert.Equal(expected, result);
        }
        
        
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
        }
        
        
        [Theory]
        [InlineData("2 of Hearts", "2 of Clubs", "4 of Diamonds", "10 of Spades", "Ace of Diamonds", 19)]
        [InlineData("6 of Diamonds", "Ace of Hearts", "5 of Clubs", "7 of Diamonds", "8 of Clubs", 27)]
        [InlineData("6 of Diamonds", "1 of Hearts", "6 of Clubs", "7 of Diamonds", "Ace of Diamonds", 21)]
        [InlineData("2 of Diamonds", "Ace of Hearts", "King of Clubs", "7 of Diamonds", "Ace of Diamonds", 21)]
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
        }
        
        
        [Theory]
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
        }

        
        [Fact]
        public void TestIfDealersTurnStopsDrawingCardsWhenScoreReachesSeventeen()
        {
            Deck deck = new Deck(new ConsoleActions()) { };

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

            List<string> dealersHand = new List<string>() {"8 of Spades", "4 of Diamonds"};
            
            var deckMock = new Mock<IDeck>();
            deckMock.Setup((s => s.DrawCard()))
                .Returns("Queen of Diamonds");
            int score = 12;
            
            List<string> expected = new List<string>() {"8 of Spades", "4 of Diamonds", "Queen of Diamonds"};
            Game game = new Game(new ConsoleActions());
            List<Card> result = game.DealersTurn(dealersHand, deckMock.Object, score);
            Assert.Equal(expected, result);
        }
        
    
        // FIX ABOVE TESTS
        // WRITE TESTS FOR NEW METHODS w/o looking
    }
}