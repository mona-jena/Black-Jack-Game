using System;
using System.Collections.Generic;

namespace Black_Jack_Game
{

    public class Game
    {
        IConsole _newConsole;

        static void Main(string[] args)
        {
            Deck deck = new Deck(new ConsoleActions());
            
            deck.Shuffle();

            Game game = new Game(new ConsoleActions());
            
            List<string> playersHand = game.DrawFirstTwoCards(deck);
            int playersScore = game.CalculateScore(playersHand);
            playersHand.ForEach(Console.WriteLine);
            Console.WriteLine("score: " + playersScore + "\n");

            List<string> dealersHand = game.DrawFirstTwoCards(deck);
            int dealersScore = game.CalculateScore(dealersHand);
            dealersHand.ForEach(Console.WriteLine);
            Console.WriteLine("score: " + dealersScore + "\n");
            
            playersScore = game.PlayersTurn(playersHand, deck, playersScore);
            
            dealersScore = game.DealersTurn(dealersHand, deck, dealersScore);

            IsWinner(playersScore, dealersScore);
        }
        
        
        public Game(IConsole console)
        {
            _newConsole = console;
        }
        
        
        public List<string> DrawFirstTwoCards(IDeck deck)
        {
            List<string> usersHand = new List<string>();
            usersHand.Add(deck.DrawCard());
            usersHand.Add(deck.DrawCard());

            return usersHand;
        }

        
        public int PlayersTurn(List<string> playersHand, IDeck deck, int score)
        {
            _newConsole.WriteLine("Player's Turn:");
            playersHand.ForEach(_newConsole.WriteLine);
            _newConsole.WriteLine("score: " + score + "\n");
            
            WinOrLossForPlayerDuringGame(score, playersHand);
            
            string playersOption = "1";
            while (playersOption == "1" && score < 21)
            {
                Console.WriteLine("\nHit or stay? (Hit = 1, Stay = 0)");
                playersOption = _newConsole.ReadLine();
                if(playersOption == "1")
                {
                    playersHand.Add(deck.DrawCard());
                    playersHand.ForEach(_newConsole.WriteLine);
                    score = CalculateScore(playersHand);
                    _newConsole.WriteLine("score: " + score + "\n");
                }
                else
                {
                    break;
                }
            }

            WinOrLossForPlayerDuringGame(score, playersHand);

            return score;
        }
        

        public int CalculateScore(List<string> playersHand)
        {
            int score = 0;
            int numberOfAces = 0;

            foreach (var i in playersHand)
            {
                string[] splitCard = i.Split(" ");

                int cardValue = 0;
                
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
        

        public int DealersTurn(List<string> dealersHand, IDeck deck, int score)
        {
            _newConsole.WriteLine("Dealer's Turn:");
            dealersHand.ForEach(_newConsole.WriteLine);
            _newConsole.WriteLine("score: " + score + "\n");
            
            while (score < 17)
            {
                dealersHand.Add(deck.DrawCard());
                dealersHand.ForEach(Console.WriteLine);
                score = CalculateScore(dealersHand);
                Console.WriteLine("score: " + score + "\n");
            }

            WinOrLossForDealerDuringGame(score, dealersHand);

            return score;
        }
        

        public void WinOrLossForPlayerDuringGame(int score, List<string> playersHand)
        {
            if (score == 21)
            {
                Console.WriteLine("Black Jack! You beat the dealer!");
                Environment.Exit(0);
            } 
            else if (score > 21)
            {
                Console.Write("You are at currently at Bust with the hand: \n");
                playersHand.ForEach(Console.WriteLine);
                Console.WriteLine("\nDealer Wins!");
                Environment.Exit(0);
            }
        }
        
        
        public void WinOrLossForDealerDuringGame(int score, List<string> dealersHand)
        {
            if (score == 21)
            {
                Console.WriteLine("Black Jack! Dealer wins!");
                Environment.Exit(0);
            } 
            else if (score > 21)
            {
                Console.WriteLine("You are at currently at Bust with the hand: \n");
                dealersHand.ForEach(Console.WriteLine);
                Console.WriteLine("\nPlayer Wins!");
                Environment.Exit(0);
            }
        }
        
        
        public static void IsWinner(int playersScore, int dealersScore)
        {
            if (playersScore > dealersScore)
            {
                Console.WriteLine("Player Wins!");
            } 
            else if (playersScore < dealersScore)
            {
                Console.WriteLine("Dealer Wins!");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
        }

    }
}