using System;

namespace TicTacToeSubmissionConole
{
    public enum PlayerEnum { X, O }

    public class TicTacToe
    {
        //created a array for the board
        private readonly char[,] _board;

        public TicTacToe()
        {
            //initializing a constructor for a 3x3 board
            _board = new char[3, 3];
        }

        public void Run()
        {
            //initializing the game and creating a game loop to keep the game going until a player wins or the board is full
            PlayerEnum currentPlayer = PlayerEnum.X;
            bool game = false;
            int moves = 0;

            while (!game && moves < 9)
            {
                RenderGame(currentPlayer);

                (int row, int column) = GetValidMove();

                UpdateBoard(row, column, currentPlayer);

                game = CheckForWin(row, column);
                moves++;

                if (!game && moves < 9)
                {
                    currentPlayer = currentPlayer == PlayerEnum.X ? PlayerEnum.O : PlayerEnum.X;
                }
            }

            EndGame(game, currentPlayer);
        }

        private void RenderGame(PlayerEnum currentPlayer)
        {
            //clears the console board and display current player
            Console.Clear();
            RenderBoard();

            Console.SetCursorPosition(2, 19);
            Console.Write($"Player {currentPlayer}");
        }

        private (int row, int column) GetValidMove()
            //ensures the correct moves are entered and in the correct sells
        {
            int row, column;
            do
            {
                row = GetValidInput("Row");
                column = GetValidInput("Column");

                if (_board[row, column] != '\0')
                {
                    Console.SetCursorPosition(2, 22);
                    Console.Write("This cell is already occupied. Try again.");
                    System.Threading.Thread.Sleep(1500);
                    Console.SetCursorPosition(2, 22);
                    Console.Write(new string(' ', Console.WindowWidth - 2));
                }
            }
            while (_board[row, column] != '\0');

            return (row, column);
        }

        private int GetValidInput(string coordinateName)
        {
            int input;
            do
            {
                Console.SetCursorPosition(2, coordinateName == "Row" ? 20 : 21);
                Console.Write($"Please Enter {coordinateName} (0-2): ");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out input) && input >= 0 && input <= 2)
                {
                    return input;
                }
                Console.SetCursorPosition(2, 22);
                Console.Write($"Invalid input. Please enter a number between 0 and 2.");
                System.Threading.Thread.Sleep(1500);
                Console.SetCursorPosition(2, 22);
                Console.Write(new string(' ', Console.WindowWidth - 2));
            }
            while (true);
        }

        private void UpdateBoard(int row, int column, PlayerEnum currentPlayer)
        {
            //Updates the board by placing the players moves
            _board[row, column] = currentPlayer == PlayerEnum.X ? 'X' : 'O';
        }

        private void RenderBoard()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.SetCursorPosition(30, 5);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(_board[i, j] == '\0' ? "-" : _board[i, j].ToString());
                    if (j < 2) Console.Write(" | ");
                }
                Console.WriteLine();
                Console.SetCursorPosition(30, Console.CursorTop);
                if (i < 2) Console.WriteLine("---------");
                Console.SetCursorPosition(30, Console.CursorTop);
            }
        }

        private bool CheckForWin(int row, int column)
        {
            // Checks if the moves make a win or not--rows,columns,diagonals
            if (_board[row, 0] == _board[row, 1] && _board[row, 1] == _board[row, 2] && _board[row, 0] != '\0')
                return true;

            if (_board[0, column] == _board[1, column] && _board[1, column] == _board[2, column] && _board[0, column] != '\0')
                return true;

            if (_board[0, 0] == _board[1, 1] && _board[1, 1] == _board[2, 2] && _board[1, 1] != '\0')
                return true;

            if (_board[0, 2] == _board[1, 1] && _board[1, 1] == _board[2, 0] && _board[1, 1] != '\0')
                return true;

            return false;
        }

        private void EndGame(bool game, PlayerEnum currentPlayer)
        {
            //displays board and checks results
            Console.Clear();
            RenderBoard();

            Console.SetCursorPosition(2, 24);
            if (game)
            {
                Console.WriteLine($"Player {currentPlayer} wins!");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
            Console.SetCursorPosition(2, 26);
            Console.WriteLine("Game Over. Press Enter to exit.");
            Console.ReadLine();
        }
    }
}