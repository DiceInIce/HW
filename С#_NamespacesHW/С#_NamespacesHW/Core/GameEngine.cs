using System;
using TicTacToeGame.Models;
using TicTacToeGame.AI;

namespace TicTacToeGame.Core
{
    public class GameEngine
    {
        private readonly GameBoard _board;
        private readonly Player _player1;
        private readonly Player _player2;
        private Player _currentPlayer;
        private readonly bool _vsComputer;
        private readonly Random _rand = new Random();

        public GameEngine(Player player1, Player player2, bool vsComputer)
        {
            _board = new GameBoard();
            _player1 = player1;
            _player2 = player2;
            _vsComputer = vsComputer;
            _currentPlayer = _rand.Next(2) == 0 ? _player1 : _player2;
        }

        public void Start()
        {
            Console.WriteLine($"\nПервым ходит: {_currentPlayer.Name} ({_currentPlayer.Symbol})");
            bool gameOver = false;

            while (!gameOver)
            {
                _board.Draw();
                Console.WriteLine($"\nХодит {_currentPlayer.Name} ({_currentPlayer.Symbol})");

                if (_vsComputer && _currentPlayer is ComputerPlayer ai)
                {
                    ai.MakeMove(_board);
                }
                else
                {
                    MakePlayerMove(_currentPlayer);
                }

                if (_board.CheckWin(_currentPlayer.Symbol))
                {
                    _board.Draw();
                    Console.WriteLine($"\nПобедил {_currentPlayer.Name}!");
                    gameOver = true;
                }
                else if (_board.IsFull())
                {
                    _board.Draw();
                    Console.WriteLine("\nНичья!");
                    gameOver = true;
                }
                else
                {
                    _currentPlayer = _currentPlayer == _player1 ? _player2 : _player1;
                }
            }
        }

        private void MakePlayerMove(Player player)
        {
            bool valid = false;
            while (!valid)
            {
                Console.Write("Введите номер клетки (1–9): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int move) && move >= 1 && move <= 9)
                {
                    valid = _board.PlaceSymbol(move, player.Symbol);
                    if (!valid)
                        Console.WriteLine("Эта клетка уже занята!");
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                }
            }
        }
    }
}