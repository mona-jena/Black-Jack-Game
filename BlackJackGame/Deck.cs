using System;
using System.Collections.Generic;

namespace Black_Jack_Game
{
    public class Deck
    {
        
        //Deck.Generate Deck of Cards -
        //Deck.Shuffle deck of cards - to randomize
        //Deck.DrawCard() - return top card from shuffled deck of cards
        
        public Deck()
        {
            
        }

        public List<string> GenerateDeck()
        {
            List<string> completeDeck = new List<string>();
            List<string> suites = new List<string>() {"Clubs", "Diamonds", "Hearts", "Spades"};
            List<int> values = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9 , 10, 11, 12, 13, 14};

            for (int i = 0; i < suites.Count; i++)
            {
                for (int j = 0; j < values.Count; j++)
                {
                    string card = suites[i] + " of " + values[j].ToString();
                    completeDeck.Add(card);
                }
            }
            completeDeck.ForEach(Console.WriteLine);
  
            return completeDeck;
        }

        public List<string> Shuffle()
        {
            List<string>completeDeck = new List<string>() { };
            return completeDeck;
        }

        public void DrawCard()
        {
            
        }
        
    }
}