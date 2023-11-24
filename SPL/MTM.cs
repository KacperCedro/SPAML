using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace MatrixTimesMatrix
{
    public static class MTM
    {
        /// <summary>
        /// this method gets number of columns in matrix
        /// </summary>
        /// <param name="matrix">two dimentional array (double[,])</param>
        /// <returns>number of columns in matrix (int)</returns>
        public static int GetNumberOfColumns(double[,] matrix)
        {
            int numberOfColumns = matrix.GetLength(1); ;
            return numberOfColumns;
        }
        /// <summary>
        /// this method gets number of rows in matrix
        /// </summary>
        /// <param name="matrix">two dimentional array (double[,])</param>
        /// <returns>number of rows in matrix (int)</returns>
        public static int GetNumberOfRows(double[,] matrix)
        {
            int numberOfRows = matrix.GetLength(0); ;
            return numberOfRows;
        }
        /// <summary>
        /// this method checks if multipication is possible
        /// </summary>
        /// <param name="matrix1">first two dimentional array (double[,])</param>
        /// <param name="matrix2">second two dimentional array (double[,])</param>
        /// <returns>isPossible (bool)</returns>
        public static bool CheckForPossibleMultiplication(double[,] matrix1, double[,] matrix2)
        {
            bool isPossible = false;
            if (GetNumberOfColumns(matrix1) == GetNumberOfRows(matrix2))
            {
                isPossible = true;
            }
            return isPossible;
        }
        /// <summary>
        /// this method checks if addition and substraction are possible
        /// </summary>
        /// <param name="matrix1">
        /// first two dimentional array (double[,])
        /// </param>
        /// <param name="matrix2">second two dimentional array (double[,])</param>
        /// <returns>isPossible (bool)</returns>
        public static bool CheckForPossibleAdditionOrSubstraction(double[,] matrix1, double[,] matrix2)
        {
            bool isPossible = false;
            if ((GetNumberOfColumns(matrix1) == GetNumberOfColumns(matrix2)) && (GetNumberOfRows(matrix1) == GetNumberOfRows(matrix2)))
            {
                isPossible = true;
            }
            return isPossible;
        }
        /// <summary>
        /// this method multiplies 2 matrices 
        /// </summary>
        /// <param name="matrix1">first two dimentional array (double[,])</param>
        /// <param name="matrix2">second two dimentional array (double[,])</param>
        /// <returns>result matrix (double[,])</returns>
        /// <exception cref="Exception">
        /// if <c>CheckForPossibleMultiplication</c> for these 2 matrices is false,
        /// it throws "invalid matrix size" - it means you should check your matrices numbers of columns and rows 
        /// </exception>
        public static double[,] Multiply(double[,] matrix1, double[,] matrix2)
        {
            double[,] result;
            if (CheckForPossibleMultiplication(matrix1, matrix2))
            {
                result = new double[GetNumberOfRows(matrix1), GetNumberOfColumns(matrix2)];

                for (int row = 0; row < GetNumberOfRows(matrix1); row++)
                {
                    for (int column = 0; column < GetNumberOfColumns(matrix2); column++)
                    {
                        result[row, column] = 0;
                        for (int n = 0; n < GetNumberOfRows(matrix2); n++)
                        {
                            result[row, column] += (matrix1[row, n] * matrix2[n, column]);
                        }
                    }
                }

                return result;
            }
            else
            {
                throw new Exception("invalid matrix size");
            }
        }
        /// <summary>
        /// this method multiplies matrix by scalar
        /// </summary>
        /// <param name="matrix">two dimentional array (double[,])</param>
        /// <param name="number">scalar variable (double)</param>
        /// <returns>result matrix (double[,])</returns>
        public static double[,] Multiply(double[,] matrix, double number)
        {
            double[,] result = new double[GetNumberOfRows(matrix), GetNumberOfColumns(matrix)];
            for (int row = 0; row < GetNumberOfRows(matrix); row++)
            {
                for (int column = 0; column < GetNumberOfColumns(matrix); column++)
                {
                    result[row, column] = matrix[row, column] * number;
                }
            }
            return result;
        }
        /// <summary>
        /// this method add two matrices together
        /// </summary>
        /// <param name="matrix1">first two dimentional array (double[,])</param>
        /// <param name="matrix2">second two dimentional array (double[,])</param>
        /// <returns>result matrix (double[,])</returns>
        /// <exception cref="Exception">
        /// if <c>CheckForPossibleAdditionOrSubstraction</c> for these 2 matrices is false,
        /// it throws "invalid matrix size" - it means you should check your matrices numbers of columns and rows 
        /// </exception>
        public static double[,] Add(double[,] matrix1, double[,] matrix2)
        {
            double[,] result;
            if (CheckForPossibleAdditionOrSubstraction(matrix1, matrix2))
            {
                result = new double[GetNumberOfRows(matrix1), GetNumberOfColumns(matrix1)];
                for (int row = 0; row < GetNumberOfRows(matrix1); row++)
                {
                    for (int column = 0; column < GetNumberOfColumns(matrix1); column++)
                    {
                        result[row, column] = matrix1[row, column] + matrix2[row, column];
                    }
                }
                return result;
            }
            else
            {
                throw new Exception("invalid matrix size");
            }
        }
        /// <summary>
        /// this method substract matrix2 from matrix1
        /// </summary>
        /// <param name="matrix1">first two dimentional array (double[,])</param>
        /// <param name="matrix2">second two dimentional array (double[,])</param>
        /// <returns>result matrix (double[,])</returns>
        /// <exception cref="Exception">
        /// if <c>CheckForPossibleAdditionOrSubstraction</c> for these 2 matrices is false,
        /// it throws "invalid matrix size" - it means you should check your matrices numbers of columns and rows 
        /// </exception>
        public static double[,] Substract(double[,] matrix1, double[,] matrix2)
        {
            double[,] result;
            if (CheckForPossibleAdditionOrSubstraction(matrix1, matrix2))
            {
                result = new double[GetNumberOfRows(matrix1), GetNumberOfColumns(matrix1)];
                for (int row = 0; row < GetNumberOfRows(matrix1); row++)
                {
                    for (int column = 0; column < GetNumberOfColumns(matrix1); column++)
                    {
                        result[row, column] = matrix1[row, column] - matrix2[row, column];
                    }
                }
                return result;
            }
            else
            {
                throw new Exception("invalid matrix size");
            }
        }

    }
}