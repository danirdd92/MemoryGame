using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace GameLogic
{
    public class GameSession
    {
        // Bug - For some reason Players are not getting 
        // instantiated properly inside a CTOR so I create them 
        // on the spot inside the field - I know, it's ugly; but it works.

        private Player[] _players = new Player[]
        {
            new Player("Player1"),
            new Player("Player2")
        };

        //private IEnumerable<Player> players = new IEnumerable<Player>

        private int _size;
        private Card[,] _cards;       

        public GameSession()
        {
            _players[0].IsActive = true;

            StartGame();
        }

        private void StartGame()
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
            

            Console.Write($"{_players[p].Name}, choose first card column ");
            int column1 = int.Parse(Console.ReadLine());
            Console.Write($"{_players[p].Name}, choose first card row ");
            int row1 = int.Parse(Console.ReadLine());

            _cards[column1 - 1, row1 - 1].IsHidden = false;

            PrintGameState();

            Console.Write($"{_players[p].Name}, choose second card column ");
            int column2 = int.Parse(Console.ReadLine());
            Console.Write($"{_players[p].Name}, choose second card row) ");
            int row2 = int.Parse(Console.ReadLine());

            _cards[column2 - 1, row2 - 1].IsHidden = false;

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
    }
}
