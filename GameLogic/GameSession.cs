using System;
using System.Threading;

namespace GameLogic
{
    public class GameSession
    {
        private readonly Player[] _players;
        private int _size;
        private Card[,] _cards;

        public GameSession()
        {
            _players = new Player[]
        {
            new Player("Player1"),
            new Player("Player2")
        };
            _players[0].IsActive = true;
        }

        public void StartGame()
        {
            do
            {
                Console.Write("Choose the size of the game board (Must be even) ");
            } while (!int.TryParse(Console.ReadLine(), out _size) || _size % 2 != 0);

            _cards = Deck.GetShuffledCards(_size);

            StartGameLoop();
        }

        private void PrintGameState()
        {
            Console.Clear();

            PrintPlayerStates();

            Console.WriteLine();

            for (int columns = 0; columns < _size; columns++)
            {
                for (int rows = 0; rows < _size; rows++)
                {
                    Console.Write(String.Format("{0, 5}", _cards[rows, columns].PrintCard()));
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private void SwapPlayers()
        {
            if (_players[0].IsActive)
            {
                _players[0].IsActive = false;
                _players[1].IsActive = true;
            }
            else
            {
                _players[0].IsActive = true;
                _players[1].IsActive = false;
            }
        }

        private void PrintPlayerStates()
        {
            Console.WriteLine($"{_players[0].Name}: {_players[0].Score}\t\t{_players[1].Name}: {_players[1].Score}");
            Console.WriteLine(new string('-', 40));
        }

        private void MakeTurn()
        {
            int p = GetActivePlayer(_players);

            GetCoordinates(out int column1, out int row1,
                out int column2, out int row2);

            PrintGameState();

            Thread.Sleep(2000);

            if (_cards[column1 - 1, row1 - 1].Value == _cards[column2 - 1, row2 - 1].Value
                && _cards[column1 - 1, row1 - 1].IsTaken == false)
            {
                _cards[column1 - 1, row1 - 1].IsTaken = true;
                _cards[column2 - 1, row2 - 1].IsTaken = true;
                _players[p].Score++;
            }
            else
            {
                _cards[column1 - 1, row1 - 1].IsHidden = true;
                _cards[column2 - 1, row2 - 1].IsHidden = true;
                SwapPlayers();
            }
        }

        private void StartGameLoop()
        {

            while (_players[0].Score != (_size * _size) / 2
                && _players[1].Score != (_size * _size) / 2)
            {
                PrintGameState();
                MakeTurn();
            }
            int i = GetActivePlayer(_players);
            Console.WriteLine($"CONGRATULATIONS!!! {_players[i].Name} Wins!!!!");
        }

        private static int GetActivePlayer(Player[] players)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].IsActive)
                {
                    return i;
                }
            }
            throw new Exception("Unexcpect error has occoured.");
        }

        private void GetCoordinates(out int column1, out int row1,
            out int column2, out int row2)
        {
            int p = GetActivePlayer(_players);

            Console.Write($"{_players[p].Name}, choose first card column ");
            column1 = GetValidInput();
            Console.Write($"{_players[p].Name}, choose first card row ");
            row1 = GetValidInput();

            _cards[column1 - 1, row1 - 1].IsHidden = false;

            PrintGameState();

            Console.Write($"{_players[p].Name}, choose second card column ");
            column2 = GetValidInput();
            Console.Write($"{_players[p].Name}, choose second card row) ");
            row2 = GetValidInput();

            _cards[column2 - 1, row2 - 1].IsHidden = false;
        }

        private int GetValidInput()
        {
            int num;
            bool isBadInput = true;
            do
            {
                int.TryParse(Console.ReadLine(), out num);
                if (num > 0 && num <= _size)
                {
                    isBadInput = false;
                }
                else
                {
                    Console.Write($"Bad Input, pick a number between 1 to {_size}: ");
                }
            } while (isBadInput);

            return num;
        }
    }
}
