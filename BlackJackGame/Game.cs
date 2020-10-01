using System;
using System.Collections.Generic;

namespace Black_Jack_Game
{

    public class Game
    {
        private IDeck _newDeck;
        private static IConsole _newConsole;
        private static bool _isPlayersTurn = false;
        private static bool _isGameOver = false;
        
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            
            deck.Shuffle();

            Game game = new Game(new ConsoleActions(), new Deck());
            
            Player player = new Player(new ConsoleActions());
            player.DrawFirstTwoCards(deck);
            
            Dealer dealer = new Dealer(new ConsoleActions());
            dealer.DrawFirstTwoCards(deck);
            
            player.PrintCurrentState();
            _isPlayersTurn = true;
            player.PlayersTurn(deck);

            if (_isGameOver == false){
                dealer.PrintCurrentState();
                _isPlayersTurn = false;
                dealer.DealersTurn(deck, _isGameOver);
            }

            if (_isGameOver == false)
            {
                game.IsWinner(player.Score, dealer.Score);
            }
        }
        
        
        public Game(IConsole console, IDeck deck)
        {
            _newConsole = console;
            _newDeck = deck;
        }
        
        

        public static void WinOrLossDuringGame(int score, List<Card> gamersHand)
        {
            if (score == 21)
            {
                var result = _isPlayersTurn ? "\nBlack Jack! You beat the dealer!" : "Black Jack! Dealer wins!";
                _isGameOver = true;
                _newConsole.WriteLine(result);
            }
            else if (score > 21)
            {
                var result = _isPlayersTurn ? "\nYou are at currently at Bust with the hand " : "\nDealer is currently at Bust with the hand ";
                _isGameOver = true;
                _newConsole.WriteLine(result);
                foreach (var i in gamersHand)
                {
                    _newConsole.Write(i.ToString() + " ");
                }
                _newConsole.WriteLine("");

                var result2 = _isPlayersTurn ? "\nDealer Wins!" : "\nPlayer Wins!";
                _isGameOver = true;
                _newConsole.WriteLine(result2);
            }
        }


        public void IsWinner(int playersScore, int dealersScore)
        {
            if (playersScore > dealersScore)
            {
                _newConsole.WriteLine("\nPlayer Wins!");
            } 
            else if (playersScore < dealersScore)
            {
                _newConsole.WriteLine("\nDealer Wins!");
            }
            else
            {
                _newConsole.WriteLine("\nIt's a draw!");
            }
        }

    }
}