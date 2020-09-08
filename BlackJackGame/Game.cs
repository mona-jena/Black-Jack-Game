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
    
    class Game
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            List<string> orderedDeck = deck.GenerateDeck();
            List<string> shuffledDeck = deck.Shuffle(orderedDeck);
            
            Game game = new Game();
            
            
            List<string> playersHand = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                string card = deck.DrawCard(shuffledDeck);
                playersHand.Add(card);
            }
            game.PlayersTurn(playersHand);
            
            
            List<string> dealersHand = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                string dealerCard = deck.DrawCard(shuffledDeck);
                dealersHand.Add(dealerCard);
            }
            //game.DealersTurn(dealersHand);
            
            string playersOption = "1";
            while (playersOption == "1")
            {
                Console.WriteLine("Hit or stay? (Hit = 1, Stay = 0)");
                playersOption = Console.ReadLine();
                if(playersOption == "1")
                {
                    playersHand.Add(deck.DrawCard(shuffledDeck));
                   //CALCULATE SCORE
                }
                else
                {
                    break;
                }
            }

            //PlayersTurn(playersHand);
            
            Console.WriteLine(shuffledDeck.Count);
        }

        public void PlayersTurn(List<string> playersHand)
        {
            string playersOption = "1";
            while (playersOption == "1")
            {
                Console.WriteLine("Hit or stay? (Hit = 1, Stay = 0)");
                playersOption = Console.ReadLine();
                if(playersOption == "1")
                {
                    playersHand.Add(deck.DrawCard(shuffledDeck));
                }
                else
                {
                    break;
                }
            }
        }
        
        
    }
}