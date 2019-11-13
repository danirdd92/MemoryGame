using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic
{
    internal class Player
    {
        private int _score = 0;
        private bool _isAcive = false;

        public Player(string name)
        {
            Name = name;
        }
        public string Name { get; }

        public bool IsActive
        {
            get { return _isAcive; }
            set { _isAcive = value; }
        }

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }



    }
}
