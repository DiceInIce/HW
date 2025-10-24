using System;

namespace TicTacToeGame.Models
{
    public class GameBoard
    {
        private readonly char[,] _board = new char[3, 3];

        public GameBoard()
        {
            char c = '1';
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    _board[i, j] = c++;
        }

        public void Draw()
        {
            Console.Clear();
            Console.WriteLine("-------------");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(_board[i, j] + " | ");
                }
                Console.WriteLine("\n-------------");
            }
        }

        public bool PlaceSymbol(int move, char symbol)
        {
            int row = (move - 1) / 3;
            int col = (move - 1) % 3;
            if (_board[row, col] == 'X' || _board[row, col] == 'O')
                return false;
            _board[row, col] = symbol;
            return true;
        }

        public bool CheckWin(char symbol)
        {
            for (int i = 0; i < 3; i++)
            {
                if ((_board[i, 0] == symbol && _board[i, 1] == symbol && _board[i, 2] == symbol) ||
                    (_board[0, i] == symbol && _board[1, i] == symbol && _board[2, i] == symbol))
                    return true;
            }

            return (_board[0, 0] == symbol && _board[1, 1] == symbol && _board[2, 2] == symbol) ||
                   (_board[0, 2] == symbol && _board[1, 1] == symbol && _board[2, 0] == symbol);
        }

        public bool IsFull()
        {
            foreach (char c in _board)
            {
                if (c != 'X' && c != 'O')
                    return false;
            }
            return true;
        }

        public bool IsCellFree(int move)
        {
            int row = (move - 1) / 3;
            int col = (move - 1) % 3;
            return _board[row, col] != 'X' && _board[row, col] != 'O';
        }
    }
}
