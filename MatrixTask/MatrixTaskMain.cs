using VectorTask;

namespace MatrixTask
{
    class MatrixTaskMain
    {
        static void Main(string[] args)
        {
            // 1c. Matrix(double[][]) – из двумерного массива(в C# double[,])
            double[,] array1 = { { 2, 3 }, { 4, 5 } };
            Matrix matrix1 = new Matrix(array1);
            Console.WriteLine(matrix1);

            // 1d. Matrix(Vector[]) – из массива векторов-строк
            Vector[] vectorsArray = new Vector[2];

            for (int i = 0; i < vectorsArray.GetLength(0); i++)
            {
                vectorsArray[i] = new Vector(3);
            }

            Matrix matrix2 = new Matrix(vectorsArray);

            // 2a. Получение размеров матрицы
            Console.WriteLine("Кол-во элементов: " + matrix2.ElementsCount);
            Console.WriteLine("Кол-во строк: " + matrix2.RowsCount);
            Console.WriteLine("Кол-во колонок: " + matrix2.ColumnsCount);
            Console.WriteLine();

            // 2b. Получение и задание вектора-строки по индексу	
            Console.WriteLine("Геттер строки: " + matrix2.GetRow(0));
            Vector vector1 = new Vector(3);
            vector1.SetElement(0, 1);
            matrix2.SetRow(0, vector1);
            Console.WriteLine("Таже строка после сеттера: " + matrix2.GetRow(0));
            Console.WriteLine();

            // 2с. Получение вектора-столбца по индексу 
            Console.WriteLine("Геттер столбца:" + matrix2.GetColumn(0));
            Console.WriteLine();

            // 2d. Транспонирование
            matrix2.SetRow(1, vector1);
            Console.WriteLine("Транспонирование до: " + matrix2);
            matrix2.Transpose();
            Console.WriteLine("Транспонирование после: " + matrix2);
            Console.WriteLine();

            matrix2.MultiplyByScalar(3);
            Console.WriteLine("Умножениe на скаляр 3,3: " + matrix2);
            Console.WriteLine();

            // 2h. Умножение матрицы на вектор
            double[] array2 = { 2, 3 };
            Vector vector = new Vector(array2);

            double[,] array3 = { { 3, 2 }, { 6, 2 }, { 1, 10 } };
            Matrix matrix3 = new Matrix(array3);

            Console.WriteLine($"Вектор: {vector} и матрица: {matrix3}");
            Console.WriteLine("После перемножения вектор * матрица = " + matrix3.MultiplyByVector(vector));
            Console.WriteLine();

            // 2f. Вычисление определителя матрицы
            double[,] array4 = { { 2, 1 }, { 10, 11 } };
            Matrix matrix4 = new Matrix(array4);
            Console.WriteLine("Детерминант: " + matrix4.GetDeterminant());
            Console.WriteLine();

            // 2.i + 2j Add; Substract
            double[,] array5 = { { 2, 3, 0 }, { 4, 5, 9.5 } };
            matrix1 = new Matrix(array5);
            Console.WriteLine("до операции: " + matrix1);
            matrix1.Add(matrix1);
            Console.WriteLine("Добавили такую же матрицу: " + matrix1);
            matrix1.Subtract(matrix1);
            Console.WriteLine("Отняли такую же матрицу: " + matrix1);
        }
    }
}