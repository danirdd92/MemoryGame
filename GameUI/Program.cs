using GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;

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
