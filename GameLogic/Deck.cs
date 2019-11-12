using GameLogic.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic
{
    public static class Deck
    {
        private static Card[,] _deck;

        public static Card[,] GetCards(int num)
        {
            
            _deck = new Card[num, num];
            int counter = 1;

            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    if (counter < num * num / 2)
                    {
                        _deck[i, j] = new Card(counter++);
                    }
                    else
                    {
                        _deck[i, j] = new Card(counter--);
                    }
                    
                }
            }

            _deck.Shuffle();

            return _deck;
        }

    }
}
