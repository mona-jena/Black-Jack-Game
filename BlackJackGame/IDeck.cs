using System;
using System.Collections.Generic;

namespace Black_Jack_Game
{
    public interface IDeck
    {
        public Card DrawCard();

        public void Shuffle();
    }

}