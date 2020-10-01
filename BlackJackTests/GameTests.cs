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
                
                Game.WinOrLossDuringGame(score, gamersHand);

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
                
            Game.WinOrLossDuringGame(score, gamersHand);
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