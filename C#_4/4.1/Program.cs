using System;
using System.Linq;
using System.Threading;

namespace TicTacToeApp
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Крестики-Нолики";
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== КРЕСТИКИ - НОЛИКИ ===");
            Console.WriteLine("Выберите режим:");
            Console.WriteLine("1 - Играть против компьютера");
            Console.WriteLine("2 - Играть с другим человеком");
            Console.Write("Ваш выбор: ");

            int choice = int.Parse(Console.ReadLine());
            bool vsComputer = (choice == 1);

            Game game = new Game(vsComputer);
            game.Start();
        }
    }

    class Game
    {
        private char[,] board = new char[3, 3];
        private char currentPlayer;
        private char human = 'X';
        private char computer = 'O';
        private bool vsComputer;
        private Random rand = new Random();

        public Game(bool vsComputer)
        {
            this.vsComputer = vsComputer;
            InitBoard();
        }

        private void InitBoard()
        {
            char cell = '1';
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    board[i, j] = cell++;
        }

        public void Start()
        {
            // случайно выбираем, кто ходит первым
            currentPlayer = rand.Next(2) == 0 ? 'X' : 'O';
            Console.WriteLine($"\nПервым ходит: {(currentPlayer == 'X' ? "Игрок 1" : (vsComputer ? "Компьютер" : "Игрок 2"))}\n");

            bool gameOver = false;

            while (!gameOver)
            {
                DrawBoard();

                if (vsComputer && currentPlayer == computer)
                {
                    ComputerMove();
                }
                else
                {
                    PlayerMove(currentPlayer);
                }

                if (CheckWin(currentPlayer))
                {
                    DrawBoard();
                    Console.WriteLine($"\nПобедил {(vsComputer && currentPlayer == computer ? "Компьютер" : $"игрок ({currentPlayer})")}!");
                    gameOver = true;
                }
                else if (IsDraw())
                {
                    DrawBoard();
                    Console.WriteLine("\nНичья!");
                    gameOver = true;
                }
                else
                {
                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                }
            }
        }

        private void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine("-------------");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j] + " | ");
                }
                Console.WriteLine("\n-------------");
            }
        }

        private void PlayerMove(char player)
        {
            int move;
            bool validMove = false;

            do
            {
                Console.Write($"\nХод игрока ({player}): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out move) && move >= 1 && move <= 9)
                {
                    int row = (move - 1) / 3;
                    int col = (move - 1) % 3;

                    if (board[row, col] != 'X' && board[row, col] != 'O')
                    {
                        board[row, col] = player;
                        validMove = true;
                    }
                    else
                    {
                        Console.WriteLine("Эта клетка уже занята. Попробуйте снова.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Введите число от 1 до 9.");
                }
            } while (!validMove);
        }

        private void ComputerMove()
        {
            Console.WriteLine("Ход компьютера...");
            Thread.Sleep(1000);

            int move;
            int row, col;

            // случайный выбор пустой клетки
            do
            {
                move = rand.Next(1, 10);
                row = (move - 1) / 3;
                col = (move - 1) % 3;
            } while (board[row, col] == 'X' || board[row, col] == 'O');

            board[row, col] = computer;
        }

        private bool CheckWin(char player)
        {
            for (int i = 0; i < 3; i++)
            {
                //строки и столбцы
                if ((board[i, 0] == player && board[i, 1] == player && board[i, 2] == player) ||
                    (board[0, i] == player && board[1, i] == player && board[2, i] == player))
                    return true;
            }

            // диагонали
            if ((board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) ||
                (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player))
                return true;

            return false;
        }

        private bool IsDraw()
        {
            return board.Cast<char>().All(c => c == 'X' || c == 'O');
        }
    }
}
