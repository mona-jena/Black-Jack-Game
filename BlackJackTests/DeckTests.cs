using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using Black_Jack_Game;
using Microsoft.VisualBasic;
using Xunit;

namespace ProgramTest
{
    public class DeckTests
    {
        
        [Fact]
        public void TestIfCompleteDeckReturns52Cards()
        {
            int expected = 52;
            Deck deck = new Deck(new ConsoleActions());
            int result = deck.completeDeck.Count;
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
            
            var newDeck = new List<Card>();
            for (int i = 0; i < completeDeck.Count; i++)
            {
                string[] splitCard =  completeDeck[i].Split(",");
                Card card = new Card()
                {
                    Suite = splitCard[1],
                    Value = splitCard[0]
                };
                newDeck.Add(card);
            }
            
            Deck deck = new Deck(new ConsoleActions());
            var result = deck.completeDeck;
            
            Assert.True(newDeck.Equals(result));
        }
        

        [Fact]
        public void TestIfShuffleRearrangesDeckOfCards()
        {
            /*var completeDeck = new List<string>()
            {
                "2, Clubs",
                "3, Clubs",
                "4, Clubs",
                "5, Clubs",
                "6, Clubs",
                "7, Clubs",
                "8, Clubs",
                "9, Clubs",
                "10, Clubs",
                "Jack, Clubs",
                "Queen, Clubs",
                "Kind, Clubs",
                "Ace, Clubs",
                "2, Diamonds",
                "3, Diamonds",
                "4, Diamonds",
                "5, Diamonds",
                "6, Diamonds",
                "7, Diamonds",
                "8, Diamonds",
                "9, Diamonds",
                "10, Diamonds",
                "Jack, Diamonds",
                "Queen, Diamonds",
                "Kind, Diamonds",
                "Ace, Diamonds",
                "2, Hearts",
                "3, Hearts",
                "4, Hearts",
                "5, Hearts",
                "6, Hearts",
                "7, Hearts",
                "8, Hearts",
                "9, Hearts",
                "10, Hearts",
                "Jack, Hearts",
                "Queen, Hearts",
                "Kind, Hearts",
                "Ace, Hearts",
                "2, Spades",
                "3, Spades",
                "4, Spades",
                "5, Spades",
                "6, Spades",
                "7, Spades",
                "8, Spades",
                "9, Spades",
                "10, Spades",
                "Jack, Spades",
                "Queen, Spades",
                "Kind, Spades",
                "Ace, Spades"
            };*/
  
            Deck newDeck = new Deck(new ConsoleActions());
            List<Card> unshuffledDeck = newDeck.completeDeck;
            newDeck.Shuffle();
            List<Card> shuffledDeck = newDeck.completeDeck;
            
            Assert.False(unshuffledDeck.Equals(shuffledDeck));
            /*for(int i = 0; i<completeDeck.Count; i++)
            {
                Assert.False(unshuffledDecki.Equals(shuffledDecki));
            }*/
        }

        [Fact]
        public void TestIfDrawCardRemovesTopCard()
        {
            /*var completeDeck = new List<string>()
            {
                "5, Diamonds",
                "10, Clubs",
                "3, Clubs",
                "4, Clubs",
                "5, Clubs",
                "6, Clubs",
                "7, Clubs",
                "8, Clubs",
                "9, Clubs",
                "Kind, Diamonds",
                "Jack, Clubs",
                "Queen, Clubs",
                "Kind, Clubs",
                "Ace, Clubs",
                "2, Diamonds",
                "3, Diamonds",
                "4, Diamonds",
                "6, Diamonds",
                "7, Diamonds",
                "8, Diamonds",
                "9, Diamonds",
                "10, Diamonds",
                "Jack, Diamonds",
                "Queen, Diamonds",
                "8, Hearts",
                "Ace, Diamonds",
                "2, Hearts",
                "3, Hearts",
                "4, Hearts",
                "5, Hearts",
                "6, Hearts",
                "7, Hearts",
                "5, Spades",
                "9, Hearts",
                "10, Hearts",
                "Jack, Hearts",
                "2, Clubs",
                "Queen, Hearts",
                "Kind, Hearts",
                "Ace, Hearts",
                "2, Spades",
                "3, Spades",
                "4, Spades",
                "Jack, Spades",
                "6, Spades",
                "7, Spades",
                "8, Spades",
                "9, Spades",
                "10, Spades",
                "Queen, Spades",
                "Kind, Spades",
                "Ace, Spades"
            }; 
            var expected = "5, Diamonds";
            Deck newDeck = new Deck(new ConsoleActions());
            var result = newDeck.DrawCard();
            Assert.Equal(expected, result);
            
            //HOW TO TEST A METHOD WHICH TAKES NO PARAM???*/
            
            // int expected = 1;
            // Deck newDeck = new Deck(new ConsoleActions()); 
            // int result = newDeck.DrawCard().Count();
            // Assert.Equal(expected, result);
            
            Deck deck = new Deck(new ConsoleActions());
            int expected = 51;
            deck.DrawCard();
            int result = deck.completeDeck.Count;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestIfDrawCardRemovesTopCardAndReturnsCardThatDoesNotExistInCompleteDeck()
        {
            Deck deck = new Deck(new ConsoleActions());
            var drawnCard = deck.DrawCard();
            Assert.False(deck.completeDeck[0].Equals(drawnCard));
        }
    }
}