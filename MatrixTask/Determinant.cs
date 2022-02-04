using System;

namespace Determinant
{
    class Determinant
    {
        public const double epsilon = 1.0e-10;

        // Swaps two rows of squareMatrix.
        public static void SwapRows(double[,] squareMatrix, int row1Index, int row2Index)
        {
            int rowLength = squareMatrix.GetLength(1);

            for (int i = 0; i < rowLength; ++i)
            {
                double temp = squareMatrix[row1Index, i];
                squareMatrix[row1Index, i] = squareMatrix[row2Index, i];
                squareMatrix[row2Index, i] = temp;
            }
        }

        // Return true, if matrix is triangular.
        public static bool IsTriangularMatrix(double[,] matrix)
        {
            bool isUpperTriangularMatrix = true;
            bool isLowerTriangularMatrix = true;
            int matrixRowLength = matrix.GetLength(1);

            for (int i = 1; i < matrixRowLength; ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    if (Math.Abs(matrix[j, i]) > epsilon)
                    {
                        isUpperTriangularMatrix = false;
                    }

                    if (Math.Abs(matrix[i, j]) > epsilon)
                    {
                        isLowerTriangularMatrix = false;
                    }
                }

                if (!isLowerTriangularMatrix && !isUpperTriangularMatrix)
                {
                    return false;
                }
            }

            return true;
        }

        // Return true, if square matrix has row or column filled zeros.
        public static bool HasRowOrColumnFilledZeros(double[,] squareMatrix)
        {
            int matrixSize = squareMatrix.GetLength(0);

            if (matrixSize != squareMatrix.GetLength(1))
            {
                throw new Exception("Array isn't square squareMatrix.");
            }

            for (int i = 0; i < matrixSize; ++i)
            {
                int rowZerosCount = 0;
                int columnZerosCount = 0;

                for (int j = 0; j < matrixSize; ++j)
                {
                    if (Math.Abs(squareMatrix[i, j]) <= epsilon)
                    {
                        ++rowZerosCount;
                    }

                    if (Math.Abs(squareMatrix[j, i]) <= epsilon)
                    {
                        ++columnZerosCount;
                    }
                }

                if (rowZerosCount == matrixSize || columnZerosCount == matrixSize)
                {
                    return true;
                }
            }

            return false;
        }

        // Сalculate determinant of matrix.
        public static double GetDeterminant(double[,] squareMatrix)
        {
            int squareMatrixSize = squareMatrix.GetLength(0);

            if (squareMatrixSize != squareMatrix.GetLength(1))
            {
                throw new Exception("Array isn't square matrix.");
            }

            int squareMatrixLength = squareMatrix.Length;

            if (squareMatrixLength == 0)
            {
                throw new Exception("Empty squareMatrix.");
            }

            if (HasRowOrColumnFilledZeros(squareMatrix))
            {
                return 0;
            }

            double[,] triangularMatrix = new double[squareMatrixSize, squareMatrixSize];
            Array.Copy(squareMatrix, triangularMatrix, squareMatrixLength);

            int swapsCount = 0;
            int triangularMatrixHeight = triangularMatrix.GetLength(0);

            if (!IsTriangularMatrix(squareMatrix))
            {
                for (int i = 0; i < triangularMatrixHeight - 1; ++i)
                {
                    if (Math.Abs(triangularMatrix[i, i]) <= epsilon)
                    {
                        for (int j = i + 1; j < triangularMatrixHeight; ++j)
                        {
                            if (Math.Abs(triangularMatrix[j, i]) > epsilon)
                            {
                                SwapRows(triangularMatrix, i, j);
                                ++swapsCount;

                                break;
                            }
                        }
                    }

                    for (int j = i + 1; j < triangularMatrixHeight; ++j)
                    {
                        if (Math.Abs(triangularMatrix[j, i]) <= epsilon)
                        {
                            continue;
                        }

                        double multiplicationFactor = triangularMatrix[j, i] / triangularMatrix[i, i];

                        for (int k = 0; k < triangularMatrixHeight; ++k)
                        {
                            triangularMatrix[j, k] -= triangularMatrix[i, k] * multiplicationFactor;
                        }
                    }
                }
            }

            double determinant = triangularMatrix[0, 0];

            for (int i = 1; i < triangularMatrixHeight; ++i)
            {
                determinant *= triangularMatrix[i, i];
            }

            return Math.Pow(-1, swapsCount) * determinant;
        }

        static void Main(string[] args)
        {
            double[,] matrix1 =
            {
                { 3, 3, 5, 4 },
                { 0, 3, 5, 1 },
                { 0, 4, 7, 1 },
                { 0, 3, 1, 4 }
            };

            double[,] matrix2 =
            {
                { 3.567, 1.931},
                { 4.122, 1.217}
            };

            Console.WriteLine($"Детерминант матрицы: {GetDeterminant(matrix1):f1}");
            Console.WriteLine($"Детерминант матрицы: {GetDeterminant(matrix2):f3}");
        }
    }
}