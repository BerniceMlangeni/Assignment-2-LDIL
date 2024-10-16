using System;
using TicTacToeSubmissionConole;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Title = "Tic Tac Toe";
                Console.WriteLine("Welcome to Tic Tac Toe!");
                Console.WriteLine("Press any key to start...");
                Console.ReadKey();
               

                var ticTacToe = new TicTacToe();
                ticTacToe.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("Thanks for playing!");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
}