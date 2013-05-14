using System;

namespace GameFifteen
{
    public class GameEngine
    {
        private GameField field;
        const int Size = 2;

        public GameEngine()
        {

        }

        private void StartGame()
        {
            this.field = new GameField(Size);
            this.PrintWelcome();
            this.PrintMatrix();
        }

        public void PlayGame()
        {
            StartGame();

            Console.Write("Enter a number to move or command: ");
            string inputString = Console.ReadLine();
            while (inputString != "exit")
            {
                int number = 0;
                bool isNumber = int.TryParse(inputString, out number); 
                if (isNumber && number < Size*Size && number > 0)
                {
                        this.field.MakeMove(number);
                }
                else if (inputString == "restart")
                {
                    this.StartGame();
                }
                else if (inputString == "top")
                {
                    //TODO add ScoreBoard
                }
                else
                {
                    Console.WriteLine("Invalid command!");
                }

                if (this.field.IsCurrentMatrixArranged())
                {
                    //GameWon(moves);
                    //PrintRankings();
                    //GenerateRandomMatrix();
                    //PrintWelcome();
                    //PrintMatrix();
                    //moves = 0;
                    Console.WriteLine("Win");
                }
                Console.WriteLine(this.field.ToString());
                Console.Write("Enter a number to move: ");
                inputString = Console.ReadLine();
            }

            Console.WriteLine("Good bye!");
        }

        private void PrintMatrix()
        {
            Console.WriteLine(this.field.ToString());
        }

        private void PrintWelcome()
        {
            Console.WriteLine("Welcome to the game “15”. Please try to arrange the numbers sequentially.\n" +
            "Use 'top' to view the top scoreboard, 'restart' to start a new game and \n'exit' to quit the game.");
        }
    }
}
