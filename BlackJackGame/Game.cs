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

            List<string> playersHand = game.DealFirstDrawCard(deck, shuffledDeck);
            
            List<string> dealersHand = game.DealFirstDrawCard(deck, shuffledDeck);

            game.PlayersTurn(playersHand, deck, shuffledDeck);
            
        }
        

        public Game(IConsole console)
        {
            _newConsole = console;
        }

        public List<string> DealFirstDrawCard(Deck deck, List<string> shuffledDeck)
        {
            List<string> usersHand = new List<string>();
            
            for (int i = 0; i < 2; i++)
            {
                string dealerCard = deck.DrawCard(shuffledDeck);
                usersHand.Add(dealerCard);
            }

            return usersHand;
        }

        public List<string> PlayersTurn(List<string> playersHand, IDeck deck, List<string> shuffledDeck)
        {
            int score = 0;
            string _playersOption = "1";
            while (_playersOption == "1" && score < 21)
            {
                Console.WriteLine("Hit or stay? (Hit = 1, Stay = 0)");
                _playersOption = _newConsole.ReadLine();
                if(_playersOption == "1")
                {
                    playersHand.Add(deck.DrawCard(shuffledDeck));
                    playersHand.ForEach(Console.WriteLine);
                    score = CalculateScore(playersHand);
                    Console.WriteLine("score: " + score);
                }
                else
                {
                    break;
                }
            }
            return playersHand;
        }
        
        public int CalculateScore(List<string> playersHand)
        {
            int score = 0;
            foreach (var i in playersHand)
            {
                string[] extractedValue = i.Split(" ");

                int cardValue = 0;
                    
                switch (extractedValue[0])
                {
                    case ("Jack"):
                        cardValue = 11;
                        break;
                    case ("King"):
                        cardValue = 12;
                        break;
                    case ("Queen"):
                        cardValue = 13;
                        break;
                    case ("Ace"):
                        cardValue = 14;
                        break;
                    default:
                        cardValue = int.Parse(extractedValue[0]);
                        break;
                }
     
                score += cardValue;
            }
            return score;
        }

    }
}