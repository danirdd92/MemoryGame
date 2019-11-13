using GameLogic;
using System;

namespace GameUI
{
    static class Program
    {
        public static void Main()
        {
            GameSession gs = new GameSession();
            gs.StartGame();
            Console.WriteLine("Press any key to quit... ");
            Console.ReadKey();
        }
    }
}
