namespace GameFifteen
{
    using System;

    /// <summary>
    /// Class that prepares a new game and support existing one.
    /// </summary>
    public class GameEngine
    {
        private const int Size = 4;
        private GameField field;
        private ScoreBoard scoreBoard;
        private GameRenderer renderer;
        private bool toPlay = true;

        /// <summary>
        ///Initializes a new instance of the <see cref="GameEngine"/> class. Sets base parameters for new game, scoreboard and field.
        /// </summary>
        public GameEngine()
        {
            this.scoreBoard = new ScoreBoard();
            this.field = new GameField(Size);
            renderer = new GameRenderer();
        }

        /// <summary>
        /// Support existing game. Parsing commands and checking if matrix is arranged.
        /// <summary>
        public void PlayGame()
        {
            this.InitializeGame();

            while (this.toPlay)
            {
                this.renderer.RenderCommandMessage();
                
                string inputString = Console.ReadLine();
                this.ParseInput(inputString);
                
                this.CheckIfMatrixArranged();
            }
        }

        private void InitializeGame()
        {
            this.renderer.RenderWelcomeMessage();
            this.renderer.RenderObject(this.field);
        }

        private void CheckIfMatrixArranged()
        {
            if (this.field.IsCurrentMatrixArranged())
            {
                this.renderer.RenderWinMessage(this.field.MoveCounter);

                string nickname = Console.ReadLine();
                this.AddNewScore(nickname);
                
                this.renderer.RenderObject(this.scoreBoard);
                this.InitializeGame();
            }
        }

        private void ParseInput(string inputString)
        {
            int number = 0;
            
            bool isValidNumber = int.TryParse(inputString, out number);
            bool isNumberInRange = 1 <= number && number < Size * Size;

            if (isValidNumber && isNumberInRange)
            {
                this.field.MakeMove(number);
                
                this.renderer.Clear();
                this.renderer.RenderObject(this.field);
            }
            else if (inputString == "restart")
            {
                this.InitializeGame();
            }
            else if (inputString == "top")
            {
                this.renderer.RenderObject(this.scoreBoard);
            }
            else if (inputString == "exit")
            {
                this.renderer.RenderGoodbyeMessage();
                this.toPlay = false;
            }
            else
            {
                this.renderer.RenderInvalidCommandMessage();
            }
        }

        private void AddNewScore(string nickname)
        {
            this.scoreBoard.AddToScoreBoard(nickname, this.field.MoveCounter);
        }
    }
}
