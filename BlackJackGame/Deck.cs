using System;
using System.Collections.Generic;
using System.Linq;

namespace Black_Jack_Game
{
    public class Deck : IDeck
    {
        
        //Deck.Generate Deck of Cards -
        //Deck.Shuffle deck of cards - to randomize
        //Deck.DrawCard() - return top card from shuffled deck of cards

        
        public List<string> GenerateDeck()
        {
        
            List<string> _completeDeck = new List<string>();
            List<string> _suites = new List<string>() {"Clubs", "Diamonds", "Hearts", "Spades"};
            List<string> _values = new List<string>() {"2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "King", "Queen", "Ace"};

            foreach (var suit in _suites)
            {
                foreach (var value in _values)
                {
                    string card = value + " " +  suit;
                    _completeDeck.Add(card);
                }
            }
            Console.WriteLine("\ncompleted deck:");
            foreach (var i in _completeDeck)
            {
                Console.WriteLine(i);
            }
            
            return _completeDeck;
        }

        
        public List<string> Shuffle(List<string> completeDeck)
        {
            List<string> _shuffledDeck = completeDeck.OrderBy(x => Guid.NewGuid()).ToList();
            Console.WriteLine("\nshuffled deck:");
            _shuffledDeck.ForEach(Console.WriteLine);

            return _shuffledDeck;
        }

        
        public string DrawCard(List<string> shuffledDeck)
        {
            String _firstCard = shuffledDeck[0];
            shuffledDeck.RemoveAt(0);
            Console.WriteLine("\ntopcard: " + _firstCard);
            return _firstCard;
        }
        
    }
}