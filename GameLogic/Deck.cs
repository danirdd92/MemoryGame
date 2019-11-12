using GameLogic.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic
{
    public static class Deck
    {
        private static Card[,] _deck;

        public static Card[,] GetShuffledCards(int num)
        {
            
            _deck = new Card[num, num];
            int pairsOfCards = (num * num) / 2;
            int counter = 1;
            bool isUpToMiddle = true;

            for (int x = 0; x < num; x++)
            {
                for (int y = 0; y < num; y++)
                {
                    if (counter < pairsOfCards + 1 && isUpToMiddle)
                    {
                        _deck[x, y] = new Card(counter++);
                        if (_deck[x, y].Value.Equals(pairsOfCards) )
                        {
                            isUpToMiddle = false;
                        }
                    }
                    else
                    {
                        _deck[x, y] = new Card(--counter);
                    }
                    
                }
            }

            _deck.Shuffle();

            return _deck;
        }

    }
}
