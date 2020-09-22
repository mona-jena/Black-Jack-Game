using System;
using System.Collections.Generic;
using System.Linq;

namespace Black_Jack_Game
{
    public class Deck : IDeck
    {
        IConsole _newConsole;
        
        //Deck.Generate Deck of Cards -
        //Deck.Shuffle deck of cards - to randomize
        //Deck.DrawCard() - return top card from shuffled deck of cards
        
        List<string> _completeDeck = new List<string>();

        public Deck(IConsole console)
        {
            _newConsole = console;
            List<string> suites = new List<string>() {"Clubs", "Diamonds", "Hearts", "Spades"};
            List<string> values = new List<string>() {"2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "King", "Queen", "Ace"};

            for (int i = 0; i < suites.Count; i++)
            {
                for (int j = 0; j < values.Count; j++)
                {
                    string card = values[j] + " " +  suites[i];
                    _completeDeck.Add(card);
                }
            }
            _newConsole.WriteLine("\ncompleted deck:");
            for (int i = 0; i <_completeDeck.Count; i++)
            {
                _newConsole.WriteLine(_completeDeck[i]);
            }
        }

        public List<string> CompleteDeck => _completeDeck;

        public void Shuffle()
        { 
            _completeDeck = _completeDeck.OrderBy(x => Guid.NewGuid()).ToList();
            _newConsole.WriteLine("\nshuffled deck:");
            _completeDeck.ForEach(_newConsole.WriteLine);
            
        }

        public string DrawCard()
        {
            String firstCard = _completeDeck[0];
            _completeDeck.RemoveAt(0);
            _newConsole.WriteLine("\ntopcard: " + firstCard);
            return firstCard;
        }
        
    }
}