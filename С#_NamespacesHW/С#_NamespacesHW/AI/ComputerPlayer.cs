using System;
using System.Threading;
using TicTacToeGame.Models;

namespace TicTacToeGame.AI
{
    using TicTacToeGame.Models;

    public class ComputerPlayer : Player
    {
        private readonly Random _rand = new Random();

        public ComputerPlayer(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        public void MakeMove(GameBoard board)
        {
            Console.WriteLine("Компьютер думает...");
            Thread.Sleep(1000);

            int move;
            do
            {
                move = _rand.Next(1, 10);
            } while (!board.IsCellFree(move));

            board.PlaceSymbol(move, Symbol);
        }
    }
}
