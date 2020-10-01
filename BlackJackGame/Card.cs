using System.Collections.Generic;

namespace Black_Jack_Game
{
    public class Card
    {
        public static List<string> suites = new List<string>() {"Clubs", "Diamonds", "Hearts", "Spades"};

        public static List<string> values = new List<string>()
            {"2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace"};

        public string Suite { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return $"[{Value}, {Suite}]";
        }

    }
}
