using System;
using System.Collections.Generic;

namespace Black_Jack_Game
{

    public class Game
    {
        private IDeck _newDeck;
        private static IConsole _newConsole;
        private static bool isPlayersTurn = false;
        private static bool isGameOver = false;
        
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
            isPlayersTurn = true;
            player.PlayersTurn(deck);

            if (isGameOver == false){
                dealer.PrintCurrentState();
                isPlayersTurn = false;
                dealer.DealersTurn(deck, isGameOver);
            }

            if (isGameOver == false)
            {
                game.IsWinner(player.Score, dealer.Score);
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
        

        public static void WinOrLossDuringGame(int score, List<Card> gamersHand)
        {
            if (score == 21)
            {
                var result = isPlayersTurn ? "\nBlack Jack! You beat the dealer!" : "Black Jack! Dealer wins!";
                isGameOver = true;
                _newConsole.WriteLine(result);
            }
            else if (score > 21)
            {
                var result = isPlayersTurn ? "\nYou are at currently at Bust with the hand " : "\nDealer is currently at Bust with the hand ";
                isGameOver = true;
                _newConsole.WriteLine(result);
                foreach (var i in gamersHand)
                {
                    _newConsole.Write(i.ToString() + " ");
                }
                _newConsole.WriteLine("");

                var result2 = isPlayersTurn ? "\nDealer Wins!" : "\nPlayer Wins!";
                isGameOver = true;
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