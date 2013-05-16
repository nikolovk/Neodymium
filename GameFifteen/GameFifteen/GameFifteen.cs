namespace GameFifteen
{
    using System;

    /// <summary>
    /// Main method. triggers the GameEngine class.
    /// </summary>
    public class GameFifteen
    {
        static void Main()
        {
            GameEngine game = new GameEngine();
            game.PlayGame();
        }
    }
}
