using System;
using System.Collections.Generic;

namespace Black_Jack_Game
{
    
    //Deck.Generate Deck of Cards -
    //Deck.Shuffle deck of cards - to randomize
    //Deck.DrawCard() - return top card from shuffled deck of cards
    //playerHands = DrawCard(newGame) from shuffled deck of cards
    //dealerHand= draw cards for dealer - get 2 cards from shuffled deck of cards
            
    //get players input - hit or stay
    //if its a hit: draw 1 card and add to playerHands
    // PrintSum(playerHands)
    //else: stop

    //dealers turn:
    //while (sum < 17):
    //DrawCard()
    //add card to dealerHand
    //PrintSum(dealerHand) for dealer
            
    //Winner() - compare player and dealer sum

    public class Game
    {
        IConsole _newConsole;
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            List<string> orderedDeck = deck.GenerateDeck();
            List<string> shuffledDeck = deck.Shuffle(orderedDeck);

            Game game = new Game(new ConsoleActions());
            
            
            List<string> playersHand = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                string card = deck.DrawCard(shuffledDeck);
                playersHand.Add(card);
            }
            game.PlayersTurn(playersHand, deck, shuffledDeck);
            
            
            List<string> dealersHand = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                string dealerCard = deck.DrawCard(shuffledDeck);
                dealersHand.Add(dealerCard);
            }
            //game.DealersTurn(playersHand, deck, shuffledDeck);
            
            Console.WriteLine(shuffledDeck.Count);
        }
        
        

        public Game(IConsole console)
        {
            _newConsole = console;
        }

        public List<string> PlayersTurn(List<string> playersHand, Deck deck, List<string> shuffledDeck)
        {
            string _playersOption = "1";
            while (_playersOption == "1")
            {
                Console.WriteLine("Hit or stay? (Hit = 1, Stay = 0)");
                _playersOption = Console.ReadLine();
                if(_playersOption == "1")
                {
                    playersHand.Add(deck.DrawCard(shuffledDeck));
                    playersHand.ForEach(Console.WriteLine);
                }
                else
                {
                    break;
                }
            }

            return playersHand;
        }
        
        
    }
}