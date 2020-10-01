using System;
using System.Collections.Generic;

namespace Black_Jack_Game
{
    public class Player
    {
        IConsole _newConsole;

        public List<Card> PlayersHand { get; set; } = new List<Card>();
        public int Score { get; set; }  // should Score be a property?
        

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
        
        public List<Card> DrawFirstTwoCards(IDeck deck)
        {
            List<Card> usersHand = new List<Card>();
            usersHand.Add(deck.DrawCard());
            usersHand.Add(deck.DrawCard());
            
            int score = CalculateScore(usersHand);
            Game.WinOrLossDuringGame(score, usersHand);
            
            return usersHand;
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