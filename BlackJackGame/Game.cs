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
            
            Player player = new Player();
            
            List<Card> playersHand = player.DrawFirstTwoCards(deck);
            player.CurrentState();
            game.ifPlayersTurn = true;
            player.PlayersTurn(deck);
            //end of player's turn
            

            List<Card> dealersHand = game.DrawFirstTwoCards(deck);
            int dealersScore = game.CalculateScore(dealersHand);
            Console.WriteLine("Dealer's Cards:");
            dealersHand.ForEach(Console.WriteLine);
            Console.WriteLine("score: " + dealersScore + "\n");
            

            if (ifGameOver == false){
                dealersScore = game.DealersTurn(dealersHand, deck, dealersScore);
            }

            if (ifGameOver == false)
            {
                game.IsWinner(player.Score, dealersScore);
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
            /*_newConsole.Write("You are currently at " + score + "\nwith the hand ");
            foreach (var i in playersHand)
            {
                _newConsole.Write(i.ToString() + " ");
            }
            _newConsole.WriteLine("");*/

            WinOrLossDuringGame(score, playersHand);
            
            string playersOption = "1";
            while (playersOption == "1" && score < 21)
            {
                _newConsole.Write("\nHit or stay? (Hit = 1, Stay = 0) ");
                playersOption = _newConsole.ReadLine();
                if(playersOption == "1")
                {
                    playersHand.Add(deck.DrawCard());
                    score = CalculateScore(playersHand);
                    _newConsole.Write("\nYou are currently at " + score + "\nwith the hand ");
                    foreach (var i in playersHand)
                    {
                        _newConsole.Write(i.ToString() + " ");
                    }
                    _newConsole.WriteLine("");
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
            _newConsole.Write("\nDealer is at " + score + "\nwith the hand ");
            foreach (var i in dealersHand)
            {
                _newConsole.Write(i.ToString() + " ");
            }
            _newConsole.WriteLine("");

            WinOrLossDuringGame(score, dealersHand);
            
            while (score < 17 && (ifGameOver == false))
            {
                dealersHand.Add(deck.DrawCard());
                score = CalculateScore(dealersHand);
                _newConsole.Write("\nDealer is at " + score + "\nwith the hand ");
                foreach (var i in dealersHand)
                {
                    _newConsole.Write(i.ToString() + " ");
                }
                _newConsole.WriteLine("");
            }

            WinOrLossDuringGame(score, dealersHand);

            return score;
        }


        public static void WinOrLossDuringGame(int score, List<Card> gamersHand)
        {
            if (score == 21)
            {
                var result = ifPlayersTurn ? "\nBlack Jack! You beat the dealer!" : "Black Jack! Dealer wins!";
                ifGameOver = true;
                _newConsole.WriteLine(result);
            }
            else if (score > 21)
            {
                var result = ifPlayersTurn ? "\nYou are at currently at Bust with the hand " : "\nDealer is currently at Bust with the hand ";
                ifGameOver = true;
                _newConsole.WriteLine(result);
                foreach (var i in gamersHand)
                {
                    _newConsole.Write(i.ToString() + " ");
                }
                _newConsole.WriteLine("");

                var result2 = ifPlayersTurn ? "\nDealer Wins!" : "\nPlayer Wins!";
                ifGameOver = true;
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