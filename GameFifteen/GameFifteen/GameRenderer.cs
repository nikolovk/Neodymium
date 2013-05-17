namespace GameFifteen
{
    using System;

    /// <summary>
    /// Public class used for all console outputs messages and drawings.
    /// </summary>
    public  class GameRenderer
    {
        public GameRenderer()
        {
        }

        /// <summary>
        /// Prints welcome message and instructions on console
        /// </summary>
        public void RenderWelcomeMessage()
        {
             Console.WriteLine("Welcome to the game “15”. Please try to arrange the numbers sequentially.\n" +
            "Use 'top' to view the top scoreboard, 'restart' to start a new game and \n'exit' to quit the game.");
        }

        /// <summary>
        /// Prints object on console via overrided ToString method
        /// </summary>
        /// <param name="obj">Object/field to be drawn on console.</param>        
        public void RenderObject(object obj)
        {
            Console.WriteLine(obj.ToString());
        }

        /// <summary>
        /// Clears console from any symbols.
        /// </summary>
        public void Clear()
        {
            Console.Clear();
        }

        /// <summary>
        /// Prints "Invalid command" message on console, when input command is invalid.
        /// </summary>
        public void RenderInvalidCommandMessage()
        {
            Console.WriteLine("Invalid command!");
        }

        /// <summary>
        /// Prints goodbye message on console.
        /// </summary>
        public void RenderGoodbyeMessage()
        {
            Console.WriteLine("Goodbye! Thank you for playing!");
        }

        /// <summary>
        /// Prints win message on console, when game is won.
        /// </summary>
        /// <param name="moveCounter">Number of moves played until matrix is arranged.</param>   
        public void RenderWinMessage(int moveCounter)
        {
            Console.WriteLine("Congratulations! You won the game in {0} moves.", moveCounter);
        }

        /// <summary>
        /// Prints input command messege on console.
        /// </summary>
        public void RenderCommandMessage()
        {
            Console.Write("Enter a number to move or command: ");
        }
    }
}
