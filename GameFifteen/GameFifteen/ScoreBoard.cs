﻿namespace GameFifteen
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ScoreBoard
    {
        private List<KeyValuePair<string, int>> scoreBoardList;

        public ScoreBoard()
        {
            this.scoreBoardList = new List<KeyValuePair<string, int>>();
        }

        public void AddToScoreBoard(string nickname, int movesCount)
        {
            KeyValuePair<string, int> scorePair =
                new KeyValuePair<string, int>(nickname, movesCount);

            this.scoreBoardList.OrderBy(x => x.Value).ThenBy(x => x.Key);

            if (this.scoreBoardList.Count > 5)
            {
                this.RemoveLastScoresFromBoard();
            }
        }

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
                    "{0}. {1} --> {2} moves", i, this.scoreBoardList[i].Key, this.scoreBoardList[i].Value);
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
