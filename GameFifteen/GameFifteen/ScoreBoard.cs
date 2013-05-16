namespace GameFifteen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Creates new scoreboard or maintain existing one. 
    /// </summary>
    public class ScoreBoard
    {
        private List<KeyValuePair<string, int>> scoreBoardList;

        /// <summary>
        /// Creates new empty scoreboard.
        /// </summary>
        public ScoreBoard()
        {
            this.scoreBoardList = new List<KeyValuePair<string, int>>();
        }

        /// <summary>
        /// Adds new entry in scoreboard list.
        /// </summary>
        /// <param name="nickname">Name of player, finished game.</param>
        /// <param name="movesCount">Score of player, finished game.</param>        
        public void AddToScoreBoard(string nickname, int movesCount)
        {
            KeyValuePair<string, int> scorePair =
                new KeyValuePair<string, int>(nickname, movesCount);
            this.scoreBoardList.Add(scorePair);

            this.scoreBoardList.OrderBy(x => x.Value).ThenBy(x => x.Key);

            if (this.scoreBoardList.Count > 5)
            {
                this.RemoveLastScoresFromBoard();
            }
        }

        /// <summary>
        /// Override ToString method, for user frendly scoreboard view.
        /// </summary>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            if (this.scoreBoardList.Count == 0)
            {
                result.Append("The score-board is empty.");
                return result.ToString();
            }

            for (int i = 0; i < this.scoreBoardList.Count; i++)
            {
                result.AppendFormat(
                    "{0}. {1} --> {2} moves", i + 1, this.scoreBoardList[i].Key, this.scoreBoardList[i].Value);
                if (i<this.scoreBoardList.Count -1)
                {
                    result.Append(Environment.NewLine);
                }               
            }

            return result.ToString();
        }

        private void RemoveLastScoresFromBoard()
        {
            while (this.scoreBoardList.Count > 5)
            {
                this.scoreBoardList.RemoveAt(5);
            }
        }
    }
}
