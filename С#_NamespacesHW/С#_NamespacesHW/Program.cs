using System;
using TicTacToeGame.Core;
using TicTacToeGame.Models;
using TicTacToeGame.AI;

namespace TicTacToeGame
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Крестики-Нолики";
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== КРЕСТИКИ - НОЛИКИ ===");
            Console.WriteLine("1 - Играть против компьютера");
            Console.WriteLine("2 - Играть с другим игроком");
            Console.Write("Ваш выбор: ");
            string choice = Console.ReadLine();

            bool vsComputer = choice == "1";

            Player player1 = new Player { Name = "Игрок 1", Symbol = 'X' };
            Player player2 = vsComputer
                ? new ComputerPlayer("Компьютер", 'O')
                : new Player { Name = "Игрок 2", Symbol = 'O' };

            GameEngine game = new GameEngine(player1, player2, vsComputer);
            game.Start();
        }
    }
}