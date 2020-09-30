using System;
using System.Collections.Generic;
using System.Linq;

namespace Black_Jack_Game
{
    public class Deck : IDeck
    {
        public List<Card> CompleteDeck { get; set; } = new List<Card>();

        public Deck()
        {
            foreach (var suite in Card.suites)
            {
                foreach (var value in Card.values)
                {
                    Card card = new Card()
                    {
                        Suite = suite,
                        Value = value
                    };
           
                    CompleteDeck.Add(card);
                }
            }
        }

      
        public void Shuffle()
        { 
            CompleteDeck = CompleteDeck.OrderBy(x => Guid.NewGuid()).ToList();
        }

        public Card DrawCard()
        {
            Card firstCard = CompleteDeck[0];
            CompleteDeck.RemoveAt(0);
            return firstCard;
        }
        
    }
}