using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic
{
    public class Card
    {
        private bool _isHidden = true;
        private bool _isTaken = false;

        public Card(int value)
        {
            Value = value;
        }
        public int Value { get; set; }

        public bool IsHidden
        {
            get { return _isHidden; }
            set
            {
                if (!_isTaken)
                {
                    _isHidden = value;
                }
                 
            }
        }

        public bool IsTaken
        {
            get { return _isTaken; }
            set 
            {
                if (_isTaken)
                {
                    IsTaken = true;
                }
                else
                {
                    _isTaken = value;
                }
              
            }
        }

        public string PrintCard()
        {
            if (this.IsHidden)
                return "X";

            else if (this.IsTaken)
                return "O";
            else
                return this.Value.ToString();
        }

    }
}
