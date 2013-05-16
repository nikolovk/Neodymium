namespace GameFifteen
{
    using System;

    /// <summary>
    /// Class, that prepairs new game, and support existing one.
    /// </summary>
    public class GameEngine
    {
        private const int Size = 4;
        private GameField field;
        private ScoreBoard scoreBoard;
        private bool toPlay = true;

        /// <summary>
        /// Sets base parameters for new game, new scoreboard and new field.
        /// </summary>
        public GameEngine()
        {
            this.scoreBoard = new ScoreBoard();
            this.field = new GameField(Size);
        }

        /// <summary>
        /// Support existing game. Parsing commands and checking if matrix is arranged.
        /// <summary>
        public void PlayGame()
        {
            this.InitializeGame();

            while (this.toPlay)
            {
                GameRenderer.RenderCommandMessage();
                this.ParseInput();
                this.IsMatrixArranged();
            }
        }

        private void InitializeGame()
        {
            GameRenderer.RenderWelcomeMessage();
            GameRenderer.RenderObject(this.field);
        }

        private void IsMatrixArranged()
        {
            if (this.field.IsCurrentMatrixArranged())
            {
                GameRenderer.RenderWinMessage(this.field.MoveCounter);
                this.AddNewScore();
                GameRenderer.RenderObject(this.scoreBoard);
                this.InitializeGame();
            }
        }

        private void ParseInput()
        {
            string inputString = Console.ReadLine();
            int number = 0;
            
            bool isValidNumber = int.TryParse(inputString, out number);
            bool isNumberInRange = 1 <= number && number < Size * Size;

            if (isValidNumber && isNumberInRange)
            {
                this.field.MakeMove(number);
                
                GameRenderer.Clear();
                GameRenderer.RenderObject(this.field);
            }
            else if (inputString == "restart")
            {
                this.InitializeGame();
            }
            else if (inputString == "top")
            {
                GameRenderer.RenderObject(this.scoreBoard);
            }
            else if (inputString == "exit")
            {
                GameRenderer.RenderGoodbyeMessage();
                this.toPlay = false;
            }
            else
            {
                GameRenderer.RenderInvalidCommandMessage();
            }
        }

        private void AddNewScore()
        {
            string nickname = Console.ReadLine();
            this.scoreBoard.AddToScoreBoard(nickname, this.field.MoveCounter);
        }
    }
}
