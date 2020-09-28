using System;
using System.Collections.Generic;

namespace Black_Jack_Game
{

    public class Game
    {
        IConsole _newConsole;
        private bool ifPlayersTurn = false;
        private bool ifGameOver = false;
        
        static void Main(string[] args)
        {
            Deck deck = new Deck(new ConsoleActions());
            
            deck.Shuffle();

            Game game = new Game(new ConsoleActions());
            
            List<Card> playersHand = game.DrawFirstTwoCards(deck);
            int playersScore = game.CalculateScore(playersHand);
            playersHand.ForEach(Console.WriteLine);
            Console.WriteLine("score: " + playersScore + "\n");

            List<Card> dealersHand = game.DrawFirstTwoCards(deck);
            int dealersScore = game.CalculateScore(dealersHand);
            dealersHand.ForEach(Console.WriteLine);
            Console.WriteLine("score: " + dealersScore + "\n");
            
            playersScore = game.PlayersTurn(playersHand, deck, playersScore);

            dealersScore = game.DealersTurn(dealersHand, deck, dealersScore);

            game.IsWinner(playersScore, dealersScore);
        }
        
        
        public Game(IConsole console)
        {
            _newConsole = console;
        }
        
        
        public List<Card> DrawFirstTwoCards(IDeck deck)
        {
            List<Card> usersHand = new List<Card>();
            usersHand.Add(deck.DrawCard());
            usersHand.Add(deck.DrawCard());

            return usersHand;
        }

        
        public int PlayersTurn(List<Card> playersHand, IDeck deck, int score)
        {
            _newConsole.WriteLine("Player's Turn:");
            foreach (var i in playersHand)
            {
                _newConsole.WriteLine(i.ToString());
            }
            _newConsole.WriteLine("score: " + score + "\n");
            
            WinOrLossForPlayerDuringGame(score, playersHand);
            
            string playersOption = "1";
            while (playersOption == "1" && score < 21)
            {
                _newConsole.WriteLine("\nHit or stay? (Hit = 1, Stay = 0)");
                playersOption = _newConsole.ReadLine();
                if(playersOption == "1")
                {
                    playersHand.Add(deck.DrawCard());
                    foreach (var i in playersHand)
                    {
                        _newConsole.WriteLine(i.ToString());
                    }
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
        

        public int CalculateScore(List<Card> playersHand)
        {
            int score = 0;
            int numberOfAces = 0;

            foreach (var card in playersHand)
            {
                switch (card.Value)
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
                        score += int.Parse(card.Value);
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
        

        public int DealersTurn(List<Card> dealersHand, IDeck deck, int score)
        {
            _newConsole.WriteLine("Dealer's Turn:");
            foreach (var i in dealersHand)
            {
                _newConsole.WriteLine(i.ToString());
            }
            _newConsole.WriteLine("score: " + score + "\n");
            
            WinOrLossForDealerDuringGame(score, dealersHand);
            
            while (score < 17)
            {
                dealersHand.Add(deck.DrawCard());
                foreach (var i in dealersHand)
                {
                    _newConsole.WriteLine(i.ToString());
                }
                score = CalculateScore(dealersHand);
                _newConsole.WriteLine("score: " + score + "\n");
            }

            WinOrLossForDealerDuringGame(score, dealersHand);

            return score;
        }
        

        public void WinOrLossForPlayerDuringGame(int score, List<Card> playersHand)
        {
            if (score == 21)
            {
                _newConsole.WriteLine("Black Jack! You beat the dealer!");
                Environment.Exit(0);
            } 
            else if (score > 21)
            {
                _newConsole.WriteLine("You are at currently at Bust with the hand: \n");
                foreach (var i in playersHand)
                {
                    _newConsole.WriteLine(i.ToString());
                }
                _newConsole.WriteLine("\nDealer Wins!");
                Environment.Exit(0);
            }
        }
        
        
        public void WinOrLossForDealerDuringGame(int score, List<Card> dealersHand)
        {
            if (score == 21)
            {
                _newConsole.WriteLine("Black Jack! Dealer wins!");
                Environment.Exit(0);
            } 
            else if (score > 21)
            {
                _newConsole.WriteLine("You are at currently at Bust with the hand: \n");
                foreach (var i in dealersHand)
                {
                    _newConsole.WriteLine(i.ToString());
                }
                _newConsole.WriteLine("\nPlayer Wins!");
                Environment.Exit(0);
            }
        }
        
        
        public void IsWinner(int playersScore, int dealersScore)
        {
            if (playersScore > dealersScore)
            {
                _newConsole.WriteLine("Player Wins!");
            } 
            else if (playersScore < dealersScore)
            {
                _newConsole.WriteLine("Dealer Wins!");
            }
            else
            {
                _newConsole.WriteLine("It's a draw!");
            }
        }

    }
}