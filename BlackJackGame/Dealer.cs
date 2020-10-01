
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
                var drawnCard = deck.DrawCard();
                _newConsole.WriteLine("\nDealer draws " + drawnCard + "\nand is at " + Score);
                Hand.Add(drawnCard);
                Score = CalculateScore(Hand);
            }
            Game.WinOrLossDuringGame(Score, Hand);
            return Score;
        }        
        
        public override void PrintCurrentState()
        {
            _newConsole.Write("\nDealer is at " + Score + "\nwith the hand ");
            foreach (var i in Hand)
            {
                _newConsole.Write(i.ToString() + " ");
            }
            _newConsole.WriteLine("");
        }
        
    }
}