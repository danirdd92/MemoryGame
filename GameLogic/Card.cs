using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic
{
    public class Card
    {
        private int _value;
        private bool _isHidden = true;
        private bool _isTaken = false;

        public Card(int value)
        {
            _value = value;
        }
        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public bool IsHidden
        {
            get { return _isHidden; }
            set { _isHidden = value; }
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

            // NOTE: make sure to reset properties to make sure it would show value
            if (this.IsHidden)
                return "X";

            else if (this.IsTaken)
                return "O";
            else
                return this.Value.ToString();
        }

    }
}
