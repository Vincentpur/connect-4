using System;

public class Connect4Game
{
    public static void Main(string[] args)
    {
        Connect4Game game = new Connect4Game();

        Console.WriteLine("Welcome to Connect 4!");

        while (!game.IsGameOver)
        {
            Console.WriteLine($"Player {game._currentPlayer}, enter your move (column 0-7): ");
            int col = int.Parse(Console.ReadLine());
            if (!game.PlayMove(col))
            {
                Console.WriteLine("Invalid move, please try again.");
            }
        }

        if (game.Winner > 0)
        if (game.Winner > 0)
        {
            Console.WriteLine($"Player {game.Winner} wins!");
        }
        else
        {
            Console.WriteLine("Game over, it's a tie!");
        }
    }

    private const int Rows = 7;
    private const int Cols = 8;
    private readonly int[,] _board = new int[Rows, Cols];
    private int _currentPlayer = 1;

    public bool IsGameOver { get; private set; }
    public int Winner { get; private set; }

    public int GetCellValue(int row, int col)
    {
        return _board[row, col];
    }

    public bool PlayMove(int col)
    {
        if (IsGameOver)
        {
            return false;
        }

        for (int row = Rows - 1; row >= 0; row--)
        {
            if (_board[row, col] == 0)
            {
                _board[row, col] = _currentPlayer;
                if (CheckForWin(row, col))
                {
                    IsGameOver = true;
                    Winner = _currentPlayer;
                }
                else if (IsBoardFull())
                {
                    IsGameOver = true;
                }
                else
                {
                    _currentPlayer = _currentPlayer == 1 ? 2 : 1;
                }
                return true;
            }
        }
        return false;
    }

    private bool CheckForWin(int row, int col)
    {
        int player = _board[row, col];
        // Check for horizontal win
        for (int c = 0; c <= Cols - 4; c++)
        {
            if (_board[row, c] == player && _board[row, c + 1] == player &&
                _board[row, c + 2] == player && _board[row, c + 3] == player)
            {
                return true;
            }
        }
        // Check for vertical win
        for (int r = 0; r <= Rows - 4; r++)
        {
            if (_board[r, col] == player && _board[r + 1, col] == player &&
                _board[r + 2, col] == player && _board[r + 3, col] == player)
            {
                return true;
            }
        }
        // Check for diagonal win (up-right)
        for (int r = 3; r < Rows; r++)
        {
            for (int c = 0; c <= Cols - 4; c++)
            {
                if (_board[r, c] == player && _board[r - 1, c + 1] == player &&
                    _board[r - 2, c + 2] == player && _board[r - 3, c + 3] == player)
                {
                    return true;
                }
            }
        }
        // Check for diagonal win (up-left)
        for (int r = 3; r < Rows; r++)
        {
            for (int c = 3; c < Cols; c++)
            {
                if (_board[r, c] == player && _board[r - 1, c - 1] == player &&
                    _board[r - 2, c - 2] == player && _board[r - 3, c - 3] == player)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool IsBoardFull()
    {
        for (int col = 0; col < Cols; col++)
        {
            if (_board[0, col] == 0)

            {
                return false;
            }
        }
        return true;
    }

}
