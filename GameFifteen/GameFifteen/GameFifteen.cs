using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace GameFifteen
{
    public class GameFifteen
    {
        static Random rand = new Random();
        public const int MatrixLength = 4;
        static int emptyRow = 3;
        static int emptyCol = 3;
        static int[,] currentMatrix = new int[MatrixLength, MatrixLength] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 },
                                                                          { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
        static int[] directionRow = new int[4] { -1, 0, 1, 0 };
        static int[] directionCol = new int[4] { 0, 1, 0, -1 };
        static OrderedMultiDictionary<int, string> scoreboard = new OrderedMultiDictionary<int, string>(true);

        private static void GenerateRandomMatrix()
        {
            int ramizeMoves = rand.Next(10, 21);
            for (int i = 0; i < ramizeMoves; i++)
            {
                int randomDirection = rand.Next(4);
                int newRow = emptyRow + directionRow[randomDirection];
                int newCol = emptyCol + directionCol[randomDirection];
                if (IsOutOfMAtrix(newRow, newCol))
                {
                    i--;
                    continue;
                }
                else
                {
                    MoveEmptyCell(newRow, newCol);
                }
            }
        }

        private static bool IsOutOfMAtrix(int row, int col)
        {
            if (row >= MatrixLength || row < 0 || col < 0 || col >= MatrixLength)
            {
                return true;
            }

            return false;
        }

        private static void MoveEmptyCell(int newRow, int newCol)
        {
            int swapValue = currentMatrix[newRow, newCol];
            currentMatrix[newRow, newCol] = 16;
            currentMatrix[emptyRow, emptyCol] = swapValue;
            emptyRow = newRow;
            emptyCol = newCol;
        }

        private static void PrintMatrix()
        {
            Console.WriteLine(" -------------");
            for (int i = 0; i < MatrixLength; i++)
            {
                Console.Write("|");
                for (int j = 0; j < MatrixLength; j++)
                {
                    if (currentMatrix[i, j] <= 9)
                    {
                        Console.Write("  {0}", currentMatrix[i, j]);
                    }
                    else
                    {
                        if (currentMatrix[i, j] == 16)
                        {
                            Console.Write("   ");
                        }
                        else
                        {
                            Console.Write(" {0}", currentMatrix[i, j]);
                        }
                    }

                    if (j == MatrixLength - 1)
                    {
                        Console.Write(" |\n");
                    }
                }
            }

            Console.WriteLine(" -------------");
        }

        private static void PrintWelcome()
        {
            Console.WriteLine("Welcome to the game “15”. Please try to arrange the numbers sequentially.\n" +
            "Use 'top' to view the top scoreboard, 'restart' to start a new game and \n'exit' to quit the game.");
        }

        private static bool IsCurrentMatrixArranged()
        {
            for (int i = 0; i < MatrixLength; i++)
            {
                for (int j = 0; j < MatrixLength; j++)
                {
                    if (currentMatrix[i, j] != i * MatrixLength + j + 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static bool IfGoesToBoard(int moves)
        {
            foreach (var score in scoreboard)
            {
                if (moves < score.Key)
                {
                    return true;
                }
            }

            return false; 
        }

        private static void RemoveLastScore()
        {
            if (scoreboard.Last().Value.Count > 0)
            {
                string[] values = new string[scoreboard.Last().Value.Count];
                scoreboard.Last().Value.CopyTo(values, 0);
                scoreboard.Last().Value.Remove(values.Last());
            }
            else
            {
                int[] keys = new int[scoreboard.Count];
                scoreboard.Keys.CopyTo(keys, 0);
                scoreboard.Remove(keys.Last());
            }
        }

        private static void GameWon(int moves)
        {
            Console.WriteLine("Congratulations! You won the game in {0} moves.", moves);
            int scorersCount = 0;
            foreach (var scorer in scoreboard)
            {
                scorersCount += scorer.Value.Count;
            }
            if (scorersCount == 5)
            {
                if (IfGoesToBoard(moves))
                {
                    RemoveLastScore();
                    AddScoreToRankings(moves);
                }
            }
            else
            {
                AddScoreToRankings(moves);
            }
        }

        private static void AddScoreToRankings(int moves)
        {
            Console.Write("Please enter your name for the top scoreboard: ");
            string name = Console.ReadLine();
            scoreboard.Add(moves, name);
        }

        private static void PrintRankings()
        {
            if (scoreboard.Count == 0)
            {
                Console.WriteLine("Scoreboard is empty");
                return;
            }

            Console.WriteLine("Scoreboard:");
            int i = 1;
            foreach (var score in scoreboard)
            {
                foreach (var value in score.Value)
                {
                    Console.WriteLine("{0}. {1} --> {2} moves", i, value, score.Key);
                    i++;
                }
            }

            Console.WriteLine();
        }

        static void Main()
        {
            //do
            //{
            //    GenerateRandomMatrix();
            //} while (IsCurrentMatrixArranged());

            //PrintWelcome();
            //PrintMatrix();
            //MainAlgorithm();
            GameEngine game = new GameEngine();
            game.PlayGame();
        }

        private static void MainAlgorithm()
        {
            int moves = 0;
            Console.Write("Enter a number to move or command: ");
            string inputString = Console.ReadLine();
            while (inputString.CompareTo("exit") != 0)
            {
                ExecuteComand(inputString, ref moves);
                if (IsCurrentMatrixArranged())
                {
                    GameWon(moves);
                    PrintRankings();
                    GenerateRandomMatrix();
                    PrintWelcome();
                    PrintMatrix();
                    moves = 0;
                }

                Console.Write("Enter a number to move: ");
                inputString = Console.ReadLine();
            }

            Console.WriteLine("Good bye!");
        }

        private static void ExecuteComand(string inputString, ref int moves)
        {
            switch (inputString)
            {
                case "restart":
                    {
                        moves = 0;
                        GenerateRandomMatrix();
                        PrintWelcome();
                        PrintMatrix();
                        break;
                    }

                case "top":
                    {
                        PrintRankings();
                        PrintMatrix();
                        break;
                    }

                default:
                    {
                        int number = 0;
                        bool isNumber = int.TryParse(inputString, out number);
                        if (!isNumber)
                        {
                            Console.WriteLine("Invalid comand!");
                            break;
                        }

                        if (number < 16 && number > 0)
                        {
                            int newRow = 0;
                            int newCol = 0;
                            for (int i = 0; i < 4; i++)
                            {
                                newRow = emptyRow + directionRow[i];
                                newCol = emptyCol + directionCol[i];
                                if (IsOutOfMAtrix(newRow, newCol))
                                {
                                    if (i == 3)
                                    {
                                        Console.WriteLine("Invalid move");
                                    }

                                    continue;
                                }

                                if (currentMatrix[newRow, newCol] == number)
                                {
                                    MoveEmptyCell(newRow, newCol);
                                    moves++;
                                    PrintMatrix();
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid move");
                            break;
                        }

                        break;
                    }
            }
        }
    }
}
