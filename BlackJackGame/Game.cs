using System;
using System.Collections.Generic;

namespace Black_Jack_Game
{

    public class Game
    {
        private IDeck _newDeck;
        IConsole _newConsole;
        private bool ifPlayersTurn = false;
        private static bool ifGameOver = false;
        
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            
            deck.Shuffle();

            Game game = new Game(new ConsoleActions(), new Deck());
            
            List<Card> playersHand = game.DrawFirstTwoCards(deck);
            int playersScore = game.CalculateScore(playersHand);
            playersHand.ForEach(Console.WriteLine);
            Console.WriteLine("score: " + playersScore + "\n");

            List<Card> dealersHand = game.DrawFirstTwoCards(deck);
            int dealersScore = game.CalculateScore(dealersHand);
            dealersHand.ForEach(Console.WriteLine);
            Console.WriteLine("score: " + dealersScore + "\n");
            
            playersScore = game.PlayersTurn(playersHand, deck, playersScore);

            if (ifGameOver == false){
                dealersScore = game.DealersTurn(dealersHand, deck, dealersScore);
            }

            if (ifGameOver == false)
            {
                game.IsWinner(playersScore, dealersScore);
            }
        }
        
        
        public Game(IConsole console, IDeck deck)
        {
            _newConsole = console;
            _newDeck = deck;
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
            ifPlayersTurn = true;
            _newConsole.WriteLine("Player's Turn:");
            foreach (var i in playersHand)
            {
                _newConsole.WriteLine(i.ToString());
            }
            _newConsole.WriteLine("score: " + score + "\n");
            
            WinOrLossDuringGame(score, playersHand);
            
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
            
            WinOrLossDuringGame(score, playersHand);

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
            ifPlayersTurn = false;
            _newConsole.WriteLine("Dealer's Turn:");
            foreach (var i in dealersHand)
            {
                _newConsole.WriteLine(i.ToString());
            }
            _newConsole.WriteLine("score: " + score + "\n");
            
            WinOrLossDuringGame(score, dealersHand);
            
            while (score < 17 && (ifGameOver == false))
            {
                dealersHand.Add(deck.DrawCard());
                foreach (var i in dealersHand)
                {
                    _newConsole.WriteLine(i.ToString());
                }
                score = CalculateScore(dealersHand);
                _newConsole.WriteLine("score: " + score + "\n");
            }

            WinOrLossDuringGame(score, dealersHand);

            return score;
        }


        public void WinOrLossDuringGame(int score, List<Card> gamersHand)
        {
            if (score == 21)
            {
                var result = ifPlayersTurn ? "Black Jack! You beat the dealer!" : "Black Jack! Dealer wins!";
                ifGameOver = true;
                _newConsole.WriteLine(result);
            }
            else if (score > 21)
            {
                Console.WriteLine("You are at currently at Bust with the hand: \n");
                foreach (var i in gamersHand)
                {
                    Console.WriteLine(i.ToString());
                }

                var result = ifPlayersTurn ? "\nDealer Wins!" : "\nPlayer Wins!";
                ifGameOver = true;
                _newConsole.WriteLine(result);
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