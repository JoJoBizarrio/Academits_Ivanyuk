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

            // 1d. Matrix(Vector[]) – из массива векторов-строк
            Vector[] vectorsArray1 = new Vector[2];

            for (int i = 0; i < vectorsArray1.GetLength(0); i++)
            {
                vectorsArray1[i] = new Vector(3);
            }

            Matrix matrix3 = new Matrix(vectorsArray1);

            // 2a. Получение размеров матрицы
            Console.WriteLine("Кол-во элементов: " + matrix3.GetElementsCount());
            Console.WriteLine("Кол-во строк: " + matrix3.GetRowsCount());
            Console.WriteLine("Кол-во колонок: " + matrix3.GetColumnsCount());
            Console.WriteLine();

            // 2b. Получение и задание вектора-строки по индексу	
            Console.WriteLine("Геттер строки: " + matrix3.GetRow(0));
            Vector vector1 = new Vector(3);
            vector1.SetElement(0, 1);
            matrix3.SetRow(vector1, 0);
            Console.WriteLine("Таже строка после сеттера: " + matrix3.GetRow(0));
            Console.WriteLine();

            // 2с. Получение вектора-столбца по индексу 
            Console.WriteLine("Геттер столбца:" + matrix3.GetColumn(0));
            Console.WriteLine();

            // 2d. Транспонирование
            //Console.WriteLine("транспонирование до: " + matrix3);
            //matrix3.Transpose();
            //Console.WriteLine("транспонирование после: " + matrix3);

            // 2e.Умножение на скаляр
            vector1.SetElement(1, 3.3);
            matrix3.SetRow(vector1, 0);
            Console.Write($"Матрица: {matrix3}\t");
            matrix3.MultiplyByScalar(3);
            Console.WriteLine("Умножениe на скаляр 3,3: " + matrix3);


        }
    }
}