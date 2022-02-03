using System;

namespace MatrixTask
{
    class MatrixTuskMain
    {
        static void Main(string[] args)
        {
            // 1a. Matrix(n, m) – матрица нулей размера n*m
            Matrix matrix1 = new Matrix(3, 2);

            // 1b. Matrix(Matrix) – конструктор копирования
            Matrix matrix2 = new Matrix(matrix1);

            // 1c. Matrix(double[][]) – из двумерного массива(в C# double[,])
            double[,] array = { { 2, 3 }, { 4, 5 } };
            matrix2 = new Matrix(array);

            // 1d. Matrix(Vector[]) – из массива векторов-строк
            Vector[] vectorsArray = new Vector[2];

            for (int i = 0; i < vectorsArray.GetLength(0); i++)
            {
                vectorsArray[i] = new Vector(3);
            }

            Matrix matrix3 = new Matrix(vectorsArray);

            // 2a. Получение размеров матрицы
            Console.WriteLine("Кол-во элементов: " + matrix3.GetElements());
            Console.WriteLine("Кол-во строк: " + matrix3.GetRows());
            Console.WriteLine("Кол-во колонок: " + matrix3.GetColumns());
            Console.WriteLine();

            // 2b. Получение и задание вектора-строки по индексу	
            Console.WriteLine("Геттер строки: " + matrix3.GetRow(0));
            Vector vector1 = new Vector(3);
            vector1.SetElement(0, 1);
            matrix3.SetRow(0, vector1);
            Console.WriteLine("Таже строка после сеттера: " + matrix3.GetRow(0));
            Console.WriteLine();

            // 2с. Получение вектора-столбца по индексу 
            Console.WriteLine("Геттер столбца:" + matrix3.GetColumn(0));
            Console.WriteLine();

            // 2d. Транспонирование
            matrix3.SetRow(1, vector1);
            Console.WriteLine("транспонирование до: " + matrix3);
            matrix3.Transpose();
            Console.WriteLine("транспонирование после: " + matrix3);
            Console.WriteLine();

            // 2e.Умножение на скаляр
            vector1.SetElement(1, 3.3);
            matrix3.SetRow(0, vector1);
            Console.WriteLine($"Матрица: {matrix3}\t");
            matrix3.MultiplyByScalar(3);
            Console.WriteLine("Умножениe на скаляр 3,3: " + matrix3);
        }
    }
}