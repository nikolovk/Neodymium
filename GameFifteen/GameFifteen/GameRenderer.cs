namespace GameFifteen
{
    using System;

    public static class GameRenderer
    {
        public static void RenderWelcomeMessage()
        {
             Console.WriteLine("Welcome to the game “15”. Please try to arrange the numbers sequentially.\n" +
            "Use 'top' to view the top scoreboard, 'restart' to start a new game and \n'exit' to quit the game.");
        }

        public static void RenderObject(object obj)
        {
            Console.WriteLine(obj.ToString());
        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static void RenderInvalidCommandMessage()
        {
            Console.WriteLine("Invalid command!");
        }

        public static void RenderGoodbyeMessage()
        {
            Console.WriteLine("Goodbye! Thank you for playing!");
        }

        public static void RenderWinMessage(int moveCounter)
        {
            Console.WriteLine("Congratulations! You won the game in {0} moves.", moveCounter);
        }

        public static void RenderCommandMessage()
        {
            Console.Write("Enter a number to move or command: ");
        }
    }
}
