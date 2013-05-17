namespace GameFifteen
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Public clas for maintaing the game field. Drawing field, 
    /// calculating positions and check if matrix is arranged.
    /// </summary>
    public class GameField
    {
        private int[,] field;

        public int Size { get; private set; }

        public int MoveCounter { get; private set; }

        /// <summary>
        /// Sets basic field dimensions and triggers mine generating sequence.
        /// </summary>
        /// <param name="size">Sets size of the field.</param>
        public GameField(int size)
        {
            if (size <= 1)
            {
                throw new ArgumentOutOfRangeException("field", "Field should have at least 2 rows and cols!");
            }

                this.field = new int[size, size];
                this.Size = size;
                this.MoveCounter = 0;
                this.GenerateField();
        }

        /// <summary>
        /// Make move calculations and execute move if input data is valid.
        /// </summary>
        /// <param name="numberToMove">Number from field that is chosen to be moved.</param>
        /// <returns>If number is successfully moved or not.</returns>
        public bool MakeMove(int numberToMove)
        {
            bool isMoved = false;
            int zeroRow;
            int zeroCol;
            int moveRow;
            int moveCol;
            
            this.FindPosition(0, out zeroRow, out zeroCol);
            this.FindPosition(numberToMove, out moveRow, out moveCol);

            bool zeroAtRandomPosition = zeroRow >= 0 && zeroCol >= 0;
            bool movedNumberAtRandomPosition = moveRow >= 0 && moveCol >= 0;

            if (zeroAtRandomPosition && movedNumberAtRandomPosition )
            {
                bool elementsNextToEachOther = (zeroRow == moveRow && Math.Abs(zeroCol - moveCol) == 1) ||
                    (zeroCol == moveCol && Math.Abs(zeroRow - moveRow) == 1);

                if (elementsNextToEachOther)
                {
                    this.field[zeroRow, zeroCol] = numberToMove;
                    this.field[moveRow, moveCol] = 0;
                    isMoved = true;
                    this.MoveCounter++;
                }
            }
            else
            {
                throw new ArgumentException("Error in Field");
            }

            return isMoved;
        }

        /// <summary>
        /// Checks if current matrix is arranged or not.
        /// </summary>
        /// <returns>True if matrix arranged and False if matrix is not arranged</returns>
        public bool IsCurrentMatrixArranged()
        {
            for (int row = 0; row < this.Size; row++)
            {
                for (int col = 0; col < this.Size; col++)
                {
                    if (((row + 1) == this.Size) && ((col + 1) == this.Size))
                    {
                        break;
                    }

                    if (this.field[row, col] != row * this.Size + col + 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Ovveride ToString for drawing the matrix field
        /// </summary>
        public override string ToString()
        {
            StringBuilder fieldAsString = new StringBuilder();

            fieldAsString.Append(" -------------");
            fieldAsString.Append(Environment.NewLine);

            for (int row = 0; row < this.field.GetLength(0); row++)
            {
                fieldAsString.Append("|");
                for (int col = 0; col < this.field.GetLength(1); col++)
                {
                    if (this.field[row, col] == 0)
                    {
                        fieldAsString.Append("   ");
                    }
                    else if (this.field[row, col] <= 9)
                    {
                        fieldAsString.Append("  " + this.field[row, col]);
                    }
                    else
                    {
                        fieldAsString.Append(" " + this.field[row, col]);
                    }

                    if (col == this.field.GetLength(0) - 1)
                    {
                        fieldAsString.Append("|");
                        fieldAsString.Append(Environment.NewLine);
                    }
                }
            }

            fieldAsString.Append(" -------------");
            return fieldAsString.ToString();
        }

        /// <summary>
        /// Searches the field for a given number and returns it's current row and column
        /// </summary>
        /// <param name="searchedNumber">The number to be searched for</param>
        /// <param name="numberRow">The variable, where the searched number's current row should be stored</param>
        /// <param name="numberCol">The variable, where the searched number's current column should be stored</param>
        private void FindPosition(int searchedNumber, out int numberRow, out int numberCol)
        {
            numberCol = -1;
            numberRow = -1;
            for (int row = 0; row < this.Size; row++)
            {
                for (int col = 0; col < this.Size; col++)
                {
                    if (this.field[row, col] == searchedNumber)
                    {
                        numberRow = row;
                        numberCol = col;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Generates a field with numbers at random position
        /// </summary>
        private void GenerateField()
        {
            List<int> allNumbers = new List<int>();
            for (int i = 0; i < this.Size * this.Size; i++)
            {
                allNumbers.Add(i);
            }

            Random randomGenerator = new Random();
            for (int row = 0; row < this.Size; row++)
            {
                for (int col = 0; col < this.Size; col++)
                {
                    int randomPlace = randomGenerator.Next(0, allNumbers.Count);
                    this.field[row, col] = allNumbers[randomPlace];
                    allNumbers.RemoveAt(randomPlace);
                }
            }
        }
    }
}
