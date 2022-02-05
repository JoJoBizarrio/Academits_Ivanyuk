using System;

namespace MatrixTask
{
    class Determinant
    {
        public const double Epsilon = 1.0e-10;

        // Swaps two rows of matrix.
        public static void SwapRows(double[,] matrix, int row1Index, int row2Index)
        {
            int rowLength = matrix.GetLength(1);

            for (int i = 0; i < rowLength; ++i)
            {
                double temp = matrix[row1Index, i];
                matrix[row1Index, i] = matrix[row2Index, i];
                matrix[row2Index, i] = temp;
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
                    if (Math.Abs(matrix[j, i]) > Epsilon)
                    {
                        isUpperTriangularMatrix = false;
                    }

                    if (Math.Abs(matrix[i, j]) > Epsilon)
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
        public static bool HasRowOrColumnFilledZeros(double[,] matrix)
        {
            int matrixSize = matrix.GetLength(0);

            if (matrixSize != matrix.GetLength(1))
            {
                throw new Exception("Array isn't square matrix.");
            }

            for (int i = 0; i < matrixSize; ++i)
            {
                int rowZerosCount = 0;
                int columnZerosCount = 0;

                for (int j = 0; j < matrixSize; ++j)
                {
                    if (Math.Abs(matrix[i, j]) <= Epsilon)
                    {
                        ++rowZerosCount;
                    }

                    if (Math.Abs(matrix[j, i]) <= Epsilon)
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
        public static double GetDeterminant(double[,] matrix)
        {
            int matrixSize = matrix.GetLength(0);

            if (matrixSize != matrix.GetLength(1))
            {
                throw new Exception("Array isn't square matrix.");
            }

            int matrixLength = matrix.Length;

            if (matrixLength == 0)
            {
                throw new Exception("Empty matrix.");
            }

            if (HasRowOrColumnFilledZeros(matrix))
            {
                return 0;
            }

            double[,] triangularMatrix = new double[matrixSize, matrixSize];
            Array.Copy(matrix, triangularMatrix, matrixLength);

            int swapsCount = 0;

            if (!IsTriangularMatrix(matrix))
            {
                for (int i = 0; i < matrixSize - 1; ++i)
                {
                    if (Math.Abs(triangularMatrix[i, i]) <= Epsilon)
                    {
                        for (int j = i + 1; j < matrixSize; ++j)
                        {
                            if (Math.Abs(triangularMatrix[j, i]) > Epsilon)
                            {
                                SwapRows(triangularMatrix, i, j);
                                ++swapsCount;

                                break;
                            }
                        }
                    }

                    for (int j = i + 1; j < matrixSize; ++j)
                    {
                        if (Math.Abs(triangularMatrix[j, i]) <= Epsilon)
                        {
                            continue;
                        }

                        double multiplicationFactor = triangularMatrix[j, i] / triangularMatrix[i, i];

                        for (int k = 0; k < matrixSize; ++k)
                        {
                            triangularMatrix[j, k] -= triangularMatrix[i, k] * multiplicationFactor;
                        }
                    }
                }
            }

            double determinant = triangularMatrix[0, 0];

            for (int i = 1; i < matrixSize; ++i)
            {
                determinant *= triangularMatrix[i, i];
            }

            return Math.Pow(-1, swapsCount) * determinant;
        }
    }
}