using System;
using System.Text;
using System.Collections;

namespace VectorTask
{
    internal class Vector
    {
        public int Dimension { get; }

        private double[] VectorArray { get; set; }

        // (1a) Создание вектора с размерностью dimension.
        public Vector(int dimension)
        {
            if (dimension <= 0)
            {
                throw new ArgumentException("Dimension have to be > 0", "dimension");
            }

            Dimension = dimension;
            VectorArray = new double[dimension];

            for (int i = 0; i < dimension; i++)
            {
                VectorArray[i] = 0;
            }
        }

        // (1b) Копировать из вектора в вектор.
        public Vector(Vector vector)
        {
            VectorArray = new double[Dimension];

            Array.Copy(vector.VectorArray, VectorArray, vector.Dimension);
        }

        // (1c) Копирует значения из массива в вектор.
        public Vector(double[] array)
        {
            int arrayLength = array.Length;

            if (arrayLength <= 0)
            {
                throw new ArgumentException("Length of array have to be > 0", "array.Length");
            }

            Dimension = arrayLength;
            VectorArray = new double[arrayLength];

            array.CopyTo(VectorArray, 0);
        }

        // (1d) Заполнение вектора значениями из массива. Если длина массива меньше dimension, то в остальных компонентах 0.
        public Vector(int dimension, double[] array)
        {
            if (dimension <= 0)
            {
                throw new ArgumentException("Dimension have to be > 0", "dimension");
            }

            int arrayLength = array.Length;

            if (dimension <= arrayLength)
            {
                throw new ArgumentException("Length of array have to be > 0", "array.Length");
            }

            Dimension = arrayLength;
            VectorArray = new double[dimension];

            array.CopyTo(VectorArray, 0);
        }

        // (2) Метод для получения размерности вектора.
        public int GetDimension()
        {
            return VectorArray.Length;
        }

        // (3) Выдает компоненты вектора через запятую {1, 2, 3}.
        public override string ToString()
        {
            StringBuilder vectorContent = new StringBuilder();
            vectorContent.Append("{");

            foreach (double e in VectorArray)
            {
                vectorContent.Append($"{e:f1}, ");
            }

            return vectorContent.Remove(vectorContent.Length - 2, 2).Append("}").ToString();
        }

        // (4a) Прибавление к вектору другого вектора.
        public void Add(Vector vector)
        {
            if (Dimension < vector.Dimension)
            {
                Vector temp = new Vector(VectorArray);
                VectorArray = new double[vector.Dimension];

                // Array.Resize<double>(ref vector, vector.Dimension);

                for (int i = 0; i < temp.Dimension; i++)
                {
                    VectorArray[i] = temp.VectorArray[i];
                }
            }

            for (int i = 0; i < vector.Dimension; i++)
            {
                VectorArray[i] += vector.VectorArray[i];
            }
        }

        // (4b) Вычитание вектора из другого вектора.
        public void Substract(Vector vector)
        {
            if (Dimension < vector.Dimension)
            {
                Vector temp = new Vector(VectorArray);
                VectorArray = new double[vector.Dimension];

                // Array.Resize<double>(ref vector, vector.Dimension); - не работает

                for (int i = 0; i < temp.Dimension; i++)
                {
                    VectorArray[i] = temp.Dimension;
                }
            }

            for (int i = 0; i < vector.Dimension; i++)
            {
                VectorArray[i] -= vector.Dimension;
            }
        }

        // (4c) Умноженение на скялар
        public void MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < Dimension; i++)
            {
                VectorArray[i] *= scalar;
            }
        }

        // (4d) Разворачивает вектор.
        public void Revert()
        {
            MultiplyByScalar(-1);
        }

        // (4e) Получение длины вектора.
        public double Length()
        {
            double sum = 0.0;

            foreach (double e in VectorArray)
            {
                sum += Math.Pow(e, 2);
            }

            return Math.Sqrt(sum);
        }

        // (4f) Получение компоненты вектора по индексу.
        public double GetElement(int index)
        {
            if (index >= Dimension || index < 0)
            {
                throw new ArgumentOutOfRangeException("index", index, "Index out of range.");
            }

            return VectorArray[index];
        }

        // (4f) Изменить компоненту вектора по индексу.
        public void SetElement(int index, double value)
        {
            if (index >= Dimension || index < 0)
            {
                throw new ArgumentOutOfRangeException("index", index, "Index out of range.");
            }

            VectorArray[index] = value;
        }

        // (4g) Возвращает true, если вектора одинаковой разммерности и компоненты равны. Иначе false.
        public override bool Equals(object vector)
        {
            return base.Equals(vector);
        }

        // (4g) ХэшКод
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // (5a) Сложение двух векторов.
        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            Vector result;

            if (vector1.Dimension >= vector2.Dimension)
            {
                result = new Vector(vector1);
                result.Add(vector2);
                return result;
            }

            result = new Vector(vector2);
            result.Add(vector1);

            return result;
        }

        // (5b) Вычитание двух векторов.
        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            Vector result;

            if (vector1.Dimension >= vector2.Dimension)
            {
                result = new Vector(vector1);
                result.Substract(vector2);
                return result;
            }

            result = new Vector(vector2);
            result.Add(vector1);

            return result;
        }

        // (5c) Скалярное произведение.
        public static double GetScalarMultiplication(Vector vector1, Vector vector2)
        {
            int minDimension;

            if (vector1.Dimension >= vector2.Dimension)
            {
                minDimension = vector2.Dimension;
            }
            else
            {
                minDimension = vector1.Dimension;
            }

            double result = 0;

            for (int i = 0; i < minDimension; i++)
            {
                result += vector1.VectorArray[i] * vector2.VectorArray[i];
            }

            return result;
        }
    }
}