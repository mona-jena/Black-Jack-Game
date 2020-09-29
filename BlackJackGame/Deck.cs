using System;
using System.Collections.Generic;
using System.Linq;

namespace Black_Jack_Game
{
    public class Deck : IDeck
    {
        IConsole _newConsole;
        public List<Card> completeDeck { get; set; } = new List<Card>();

        public Deck(IConsole console)
        {
            _newConsole = console;

            foreach (var suite in Card.suites)
            {
                foreach (var value in Card.values)
                {
                    Card card = new Card()
                    {
                        Suite = suite,
                        Value = value
                    };
           
                    completeDeck.Add(card);
                }
            }
        }

      
        public void Shuffle()
        { 
            completeDeck = completeDeck.OrderBy(x => Guid.NewGuid()).ToList();
        }

        public Card DrawCard()
        {
            Card firstCard = completeDeck[0];
            completeDeck.RemoveAt(0);
            _newConsole.WriteLine("\ntopcard: " + firstCard + "\n");
            return firstCard;
        }
        
    }
}