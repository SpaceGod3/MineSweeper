using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] board = {
                {" ","1","2","3","4","5","6","7","8","9"},
                {"1","_","_","_","_","_","_","_","_","_"},
                {"2","_","_","_","_","_","_","_","_","_"},
                {"3","_","_","_","_","_","_","_","_","_"},
                {"4","_","_","_","_","_","_","_","_","_"},
                {"5","_","_","_","_","_","_","_","_","_"},
                {"6","_","_","_","_","_","_","_","_","_"},
                {"7","_","_","_","_","_","_","_","_","_"},
                {"7","_","_","_","_","_","_","_","_","_"},
                {"8","_","_","_","_","_","_","_","_","_"},
                {"9","_","_","_","_","_","_","_","_","_"},
            };
            string[,] mines = {
                {" ","1","2","3","4","5","6","7","8","9"},
                {"1","_","_","_","_","_","_","_","_","_"},
                {"2","_","_","_","_","_","_","_","_","_"},
                {"3","_","_","_","_","_","_","_","_","_"},
                {"4","_","_","_","_","_","_","_","_","_"},
                {"5","_","_","_","_","_","_","_","_","_"},
                {"6","_","_","_","_","_","_","_","_","_"},
                {"7","_","_","_","_","_","_","_","_","_"},
                {"7","_","_","_","_","_","_","_","_","_"},
                {"8","_","_","_","_","_","_","_","_","_"},
                {"9","_","_","_","_","_","_","_","_","_"},
            };
            int rowCount = board.GetUpperBound(0) + 1;
            int columnCount = board.GetUpperBound(1) + 1;

            GetResult(board, rowCount, columnCount);

            Console.WriteLine("Enter the coordinates of your move:");
            Console.Write("Row:");
            int row = Convert.ToInt32(Console.ReadLine());
            Console.Write("Column:");
            int column = Convert.ToInt32(Console.ReadLine());


            int minesCount = 9;
            SetMines(mines, minesCount,row,column);


            GetResult(mines, rowCount, columnCount);
            Console.ReadLine();

            IsBorder(row, column);
        }

        private static void IsBorder(int row, int column)
        {
            
        }

        private static void SetMines(string[,] mines, int minesCount, int row, int colum)
        {
            if (minesCount > 0)
            {
                Random rnd = new Random();
                int m_row = rnd.Next(1, 9);
                int m_column = rnd.Next(1, 9);
                if (m_row == row && m_column == colum)
                {
                    SetMines(mines, minesCount, row, colum);
                }
                if (mines[m_row, m_column] == "*")
                {
                    SetMines(mines, minesCount, row, colum);
                }
                else {
                    mines[m_row, m_column] = "*";
                    SetMines(mines, minesCount - 1, row, colum);
                }

            }
            
            else {
                return;
            }
        }

        private static void GetResult<T>(T[,] board, int rowCount, int columnCount)
        {
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    Console.Write(board[i, j] + "|");

                }
                Console.WriteLine();

            }
        }
    }
}
