using System.Collections.Generic;
using System.Linq;
using Black_Jack_Game;
using Xunit;

namespace ProgramTest
{
    public class DeckTests
    {
        
        [Fact]
        public void TestIfCompleteDeckReturns52Cards()
        {
            int expected = 52;
            Deck deck = new Deck();
            int result = deck.CompleteDeck.Count;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestIfCompletedDeckReturnsCorrect52Card()
        {
            var completeDeck = new List<string>()
            {
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
                "8,Diamonds",
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
                "6,Hearts",
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

            var deckTest = new Deck();

            for (int c = 0; c < 52; c++)
            { 
                var actual = $"{deckTest.CompleteDeck[c].Value},{deckTest.CompleteDeck[c].Suite}";
                Assert.Equal(completeDeck[c], actual);
            }
           
        }
        

        [Fact]
        public void TestIfShuffleRearrangesDeckOfCards()
        {
            Deck newDeck = new Deck();
            List<Card> unshuffledDeck = newDeck.CompleteDeck;
            newDeck.Shuffle();
            List<Card> shuffledDeck = newDeck.CompleteDeck;
            
            Assert.False(unshuffledDeck.Equals(shuffledDeck));
        }

        [Fact]
        public void TestIfDrawCardRemovesTopCard()
        {
            Deck deck = new Deck();
            int expected = 51;
            deck.DrawCard();
            int result = deck.CompleteDeck.Count;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestIfDrawCardRemovesTopCardAndReturnsCardThatDoesNotExistInCompleteDeck()
        {
            Deck deck = new Deck();
            var drawnCard = deck.DrawCard();
            Assert.False(deck.CompleteDeck[0].Equals(drawnCard));
        }
    }
}