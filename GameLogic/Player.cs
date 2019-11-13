using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic
{
    internal class Player
    {
        public string Name { get; }

        public bool IsActive { get; set; }

        public int Score { get; set; } 

        public Player(string name)
        {
            Name = name;
            IsActive = false;
            Score = 0;
        }
    }
}
