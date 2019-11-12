using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic
{
    public class GameSession
    {
        private Player _p1, _p2;
        private int _size;
        private Card[,] _cards;

        public GameSession(string p1 = "Player 1", string p2 = "Player 2")
        {
            Player _p1 = new Player(p1);
            Player _p2 = new Player(p2);

            _p1.IsActive = true;

            InitializeBoard();
        }

        private void InitializeBoard()
        { 
            do
            {
                Console.Write("Choose the size of the game board (Must be even) ");
            } while (!int.TryParse(Console.ReadLine(), out _size) && _size % 2 != 0);

            _cards = Deck.GetCards(_size);
                

            PrintBoard();


        }

        private void PrintBoard()
        {
            Console.Clear();
            int count = 0;

            for (int rows = 0; rows < _size; rows++)
            {
                for (int columns = 0; columns < _size; columns++)
                {
                    Console.Write(String.Format("{0,-5}", _cards[rows,columns].Value));
                }
                Console.WriteLine();
            }
        }
        private void SwapPlayers()
        {
            if (_p1.IsActive)
            {
                _p1.IsActive = false;
                _p2.IsActive = true;
            }
            else
            {
                _p1.IsActive = true;
                _p2.IsActive = false;
            }
        }
    }
}
