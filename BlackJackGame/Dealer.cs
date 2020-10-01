
namespace Black_Jack_Game
{
    public class Dealer : Player
    {
        private IConsole _newConsole;

        public Dealer(IConsole console) : base(console)
        {
            _newConsole = console;
        }
        
        public int DealersTurn(IDeck deck, bool isGameOver)
        {
            Game.WinOrLossDuringGame(Score, Hand);
            
            while (Score < 17 && (isGameOver == false))
            {
                Hand.Add(deck.DrawCard());
                Score = CalculateScore(Hand);
                PrintCurrentState();
            }

            Game.WinOrLossDuringGame(Score, Hand);

            return Score;
        }        
        
        public void PrintCurrentState()
        {
            _newConsole.Write("You are currently at " + Score + "\nwith the hand ");
            foreach (var i in Hand)
            {
                _newConsole.Write(i.ToString() + " ");
            }
            _newConsole.WriteLine("");
        }
        
        
    }
}