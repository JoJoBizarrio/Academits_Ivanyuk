using System;

namespace VectorTask
{
    class VectorTaskMain
    {
        static void Main(string[] args)
        {
            // Блок 1, 2 и 3.
            Console.Write("(1a) Создание вектора с размерностью dimension: ");
            Vector vector1A = new Vector(9);
            Console.WriteLine(vector1A);
            Console.WriteLine("Dimension: " + vector1A.Dimension);
            Console.WriteLine();

            // 1b after 1c

            Console.Write("(1b) Копировать из вектора в вектор: ");
            double[] array1C = { 0.1, 9.2, 2.9 };
            Vector vector1C = new Vector(array1C);
            Console.WriteLine(vector1C);
            Console.WriteLine("Dimension: " + vector1C.Dimension);
            Console.WriteLine();

            Console.Write("(1c) Копирует значения из массива в вектор: ");
            Vector vector1B = new Vector(array1C);
            Console.WriteLine(vector1B);
            Console.WriteLine("Dimension: " + vector1B.GetDimension());
            Console.WriteLine();

            Console.Write("(1d) Заполнение вектора значениями из массива. Если длина массива меньше dimension, то в остальных компонентах 0: ");
            double[] array1D = { 1.1, 4.2, 8.9 };
            Vector vector1D = new Vector(5, array1D);
            Console.WriteLine(vector1D);
            Console.WriteLine("Dimension: " + vector1D.GetDimension());
            Console.WriteLine();
            Console.WriteLine();

            // Блок 4
            Console.WriteLine("(4a, 4b) Нестатическое прибавление и вычитание вектора: ");
            vector1A.SetElement(5, 2);

            Console.Write($"vector1C: в {vector1C } прибавить {vector1B} => result: ");
            vector1C.Add(vector1B);
            Console.WriteLine(vector1C);

            Console.Write($"vector1B: из {vector1B } отнять {vector1A} => result: ");
            vector1B.Subtract(vector1A);
            Console.WriteLine(vector1B);
            Console.WriteLine();

            Console.WriteLine("(4c) Умноженение на скаляр: ");
            Console.Write(vector1C + " * 5 = ");
            vector1C.MultiplyByScalar(5);
            Console.WriteLine(vector1C);
            Console.WriteLine();

            Console.WriteLine("(4d) Разворачивает вектор: ");
            Console.Write(vector1C + " => ");
            vector1C.Revert();
            Console.WriteLine(vector1C);
            Console.WriteLine();

            Console.Write("(4e) Получение длины вектора ");
            Vector vector4E = new Vector(3);
            vector4E.SetElement(0, 3);
            vector4E.SetElement(1, 4);
            vector4E.SetElement(2, -4);
            Console.WriteLine($"{vector4E}: Length = {vector4E.GetLength():f1}");
            Console.WriteLine();

            Console.WriteLine("(4f) Получение компоненты вектора по индексу 2: " + vector4E.GetElement(2));
            vector4E.SetElement(2, 2.4);
            Console.WriteLine("Поменяли число c индексом 2 на 2.4: " + vector4E.GetElement(2));
            Console.WriteLine();

            Console.WriteLine("(4g) Возвращает true, если вектора одинаковой размерности и компоненты равны: ");
            Vector vector4G = new Vector(vector4E);
            Console.WriteLine($"Равны ли вектора: {vector4G} и {vector4E} => {vector4E.Equals(vector4G)}");
            vector4G.SetElement(1, -1);
            Console.WriteLine($"Равны ли вектора: {vector4G} и {vector4E} => {vector4E.Equals(vector4G)}");
            Console.WriteLine();

            Console.WriteLine("(4g) ХэшКод: " + vector4E.GetHashCode());
            Console.WriteLine();

            // Блок 5
            Console.WriteLine("(5a) Статическое сложение двух векторов: ");
            Vector vectorsSum = Vector.GetSum(vector4E, vector4G);
            Console.WriteLine($"{vector4E} + {vector4G } = {vectorsSum}");
            Console.WriteLine();

            Console.WriteLine("(5b) Статическое вычитание двух векторов: ");
            Vector vectorsDifference = Vector.GetDifference(vector4E, vector1B);
            Console.WriteLine($"{vector4E} - {vector1B } = {vectorsDifference}");
            Console.WriteLine();

            Console.WriteLine("(5c) Скалярное произведение: ");
            double vectorsProduct = Vector.GetScalarProduct(vector4E, vector4G);
            Console.WriteLine($"{vector4E} * {vector4G} = {vectorsProduct}");
            Console.WriteLine();
        }
    }
}