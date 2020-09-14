using System;
using System.Collections.Generic;

namespace Black_Jack_Game
{
    public interface IDeck
    {
        public string DrawCard(List<string> shuffledDeck);
    }
    

}