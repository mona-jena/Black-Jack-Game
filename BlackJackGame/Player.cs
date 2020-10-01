using System;
using System.Collections.Generic;

namespace Black_Jack_Game
{
    public class Player
    {
        private IConsole _newConsole;

        public List<Card> PlayersHand { get; set; } = new List<Card>();
        public int Score { get; set; }  // should Score be a property?

        public Player(IConsole console)
        {
            _newConsole = console;
        }

        public int PlayersTurn(IDeck deck)
        {
            
            string playersOption = "1";
            while (playersOption == "1" && Score < 21)
            {
                _newConsole.Write("\nHit or stay? (Hit = 1, Stay = 0) ");
                playersOption = _newConsole.ReadLine();
                if(playersOption == "1")
                {
                    PlayersHand.Add(deck.DrawCard());
                    Score = CalculateScore(PlayersHand);
                    CurrentState();
                }
                else
                {
                    break;
                }
            }
            
            Game.WinOrLossDuringGame(Score, PlayersHand);
            return Score;
        }
        
        public void DrawFirstTwoCards(IDeck deck)
        {
            PlayersHand.Add(deck.DrawCard());
            PlayersHand.Add(deck.DrawCard());
            
            Score = CalculateScore(PlayersHand);
            Game.WinOrLossDuringGame(Score, PlayersHand);
        }
        

        
        public int CalculateScore(List<Card> playersHand)
        {
            Score = 0;
            int numberOfAces = 0;

            foreach (var card in playersHand)
            {
                switch (card.Value)
                {
                    case ("Jack"):
                        Score += 10;
                        break;
                    case ("King"):
                        Score += 10;
                        break;
                    case ("Queen"):
                        Score += 10;
                        break;
                    case ("Ace"):
                        numberOfAces++;
                        break;
                    default:
                        Score += int.Parse(card.Value);
                        break;
                }
            }

            if (numberOfAces == 0)
            {
                return Score;
            }

            Score += (numberOfAces - 1);

            if (Score < 11)
            {
                Score += 11;
            }
            else
            {
                Score += 1;
            }

            return Score;
        }

        public void CurrentState()
        {
            _newConsole.Write("You are currently at " + Score + "\nwith the hand ");
            foreach (var i in PlayersHand)
            {
                _newConsole.Write(i.ToString() + " ");
            }
            _newConsole.WriteLine("");
        }
    }

}