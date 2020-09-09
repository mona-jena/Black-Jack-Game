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
            Deck deck = new Deck(){};
            
            List<string> shuffledDeck = new List<string>(){};
  
            List<string> playersHand = new List<string>(){"Hearts3", "ClubsKind"};
            var consoleActionsMock = new Mock<IConsole>();
            consoleActionsMock.Setup(s => s.ReadLine())
                .Returns("Diamond5");
            
            List<string> expected = new List<string>(){"Hearts3", "ClubsKind", "Diamond5"};
            Game game = new Game(consoleActionsMock.Object);
            List<string> result = game.PlayersTurn(playersHand, deck, shuffledDeck);
            Assert.Equal(expected, result);
            //dhfhfh
        }
    }
}