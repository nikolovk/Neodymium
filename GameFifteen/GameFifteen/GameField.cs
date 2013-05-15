namespace GameFifteen
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GameField
    {
        private int[,] field;

        public int Size { get; private set; }

        public int MoveCounter { get; private set; }

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

        public bool MakeMove(int numberToMove)
        {
            bool isMoved = false;
            int zeroRow;
            int zeroCol;
            int moveRow;
            int moveCol;
            this.FindPosition(0, out zeroRow, out zeroCol);
            this.FindPosition(numberToMove, out moveRow, out moveCol);

            if (zeroRow >= 0 && zeroCol >= 0 && moveRow >= 0 && moveCol >= 0)
            {
                if ((zeroRow == moveRow && Math.Abs(zeroCol - moveCol) == 1) ||
                    (zeroCol == moveCol && Math.Abs(zeroRow - moveRow) == 1))
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
