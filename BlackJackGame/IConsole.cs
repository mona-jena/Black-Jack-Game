using System;

namespace Black_Jack_Game
{
    public interface IConsole
    {
        public string ReadLine();

        public void WriteLine(string message);
    }

}