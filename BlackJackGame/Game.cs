﻿using System;
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
            Deck deck = new Deck(new ConsoleActions());
            
            deck.Shuffle();

            Game game = new Game(new ConsoleActions());

            List<string> playersHand = game.DealFirstDrawCard(deck);

            List<string> dealersHand = game.DealFirstDrawCard(deck);

            game.PlayersTurn(playersHand, deck);
            
            //game.DealersTurn(playersHand, deck, shuffledDeck);

        }
        
        
        public Game(IConsole console)
        {
            _newConsole = console;
        }


        public List<string> DealFirstDrawCard(IDeck deck)
        {
            List<string> usersHand = new List<string>();
            usersHand.Add(deck.DrawCard());
            usersHand.Add(deck.DrawCard());

            return usersHand;
        }

        public List<string> PlayersTurn(List<string> playersHand, IDeck deck)
        {
            int score = 0;
            string playersOption = "1";
            while (playersOption == "1" && score < 21)
            {
                Console.WriteLine("Hit or stay? (Hit = 1, Stay = 0)");
                playersOption = _newConsole.ReadLine();
                if(playersOption == "1")
                {
                    playersHand.Add(deck.DrawCard());
                    playersHand.ForEach(_newConsole.WriteLine);
                    score = CalculateScore(playersHand);
                    _newConsole.WriteLine("score: " + score);
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
            int numberOfAces = 0;

            foreach (var i in playersHand)
            {
                string[] splitCard = i.Split(" ");

                switch (splitCard[0])
                {
                    case ("Jack"):
                        score += 10;
                        break;
                    case ("King"):
                        score += 10;
                        break;
                    case ("Queen"):
                        score += 10;
                        break;
                    case ("Ace"):
                        numberOfAces++;
                        break;
                    default:
                        score += int.Parse(splitCard[0]);
                        break;
                }
            }

            if (numberOfAces == 0)
            {
                return score;
            }

            score += (numberOfAces - 1);

            if (score < 11)
            {
                score += 11;
            }
            else
            {
                score += 1;
            }

            return score;
            
        }
    }
}