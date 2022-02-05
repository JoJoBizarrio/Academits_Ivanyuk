using System;
using System.Text;

namespace MatrixTask
{
    internal class Vector
    {
        internal double[] Components;

        public int Dimension
        {
            get { return Components.Length; }
        }

        // (1a) Создание вектора с размерностью dimension.
        public Vector(int dimension)
        {
            if (dimension <= 0)
            {
                throw new ArgumentException("Dimension have to be > 0", nameof(dimension));
            }

            Components = new double[dimension];
        }

        // (1b) Копировать из вектора в вектор.
        public Vector(Vector vector)
        {
            Components = new double[vector.Dimension];

            Array.Copy(vector.Components, Components, vector.Dimension);
        }

        // (1c) Копирует значения из массива в вектор.
        public Vector(double[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Length of array have to be > 0", nameof(array.Length));
            }

            Components = new double[array.Length];

            array.CopyTo(Components, 0);
        }

        // (1d) Заполнение вектора значениями из массива. Если длина массива меньше dimension, то в остальных компонентах 0.
        public Vector(int dimension, double[] array)
        {
            if (dimension <= 0)
            {
                throw new ArgumentException("Dimension have to be > 0", nameof(dimension));
            }

            Components = new double[dimension];

            int minDimension = Math.Min(dimension, array.Length);

            Array.Copy(array, Components, minDimension);
        }

        // (2) Метод для получения размерности вектора.
        public int GetDimension()
        {
            return Components.Length;
        }

        // (3) Выдает компоненты вектора через запятую {1, 2, 3}.
        public override string ToString()
        {
            StringBuilder vectorContent = new StringBuilder();
            vectorContent.Append("{");

            foreach (double e in Components)
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
                Vector temp = new Vector(Components);

                Array.Resize(ref Components, vector.Dimension);

                temp.Components.CopyTo(Components, 0);
            }

            for (int i = 0; i < vector.Dimension; i++)
            {
                Components[i] += vector.Components[i];
            }
        }

        // (4b) Вычитание вектора из другого вектора.
        public void Subtract(Vector vector)
        {
            if (Dimension < vector.Dimension)
            {
                Vector temp = new Vector(Components);

                Array.Resize(ref Components, vector.Dimension);

                temp.Components.CopyTo(Components, 0);
            }

            for (int i = 0; i < vector.Dimension; i++)
            {
                Components[i] -= vector.Components[i];
            }
        }

        // (4c) Умножение на скаляр
        public void MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < Dimension; i++)
            {
                Components[i] *= scalar;
            }
        }

        // (4d) Разворачивает вектор.
        public void Revert()
        {
            MultiplyByScalar(-1);
        }

        // (4e) Получение длины вектора.
        public double GetLength()
        {
            double sum = 0.0;

            foreach (double e in Components)
            {
                sum += e * e;
            }

            return Math.Sqrt(sum);
        }

        // (4f) Получение компоненты вектора по индексу.
        public double GetElement(int index)
        {
            if (index < 0 || index >= Dimension)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, "Index out of range.");
            }

            return Components[index];
        }

        // (4f) Изменить компоненту вектора по индексу.
        public void SetElement(int index, double value)
        {
            if (index < 0 || index >= Dimension)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, "Index out of range.");
            }

            Components[index] = value;
        }

        // (4g) Возвращает true, если вектора одинаковой разммерности и компоненты равны. Иначе false.
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this)) return true;

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType()) return false;

            Vector vector = (Vector)obj;

            for (int i = 0; i < Dimension; i++)
            {
                if (Components[i] != vector.Components[i])
                {
                    return false;
                }
            }

            return true;
        }

        // (4g) ХэшКод
        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 11;

            foreach (double e in Components)
            {
                hash += hash * prime + e.GetHashCode();
            }

            return hash;
        }

        // (5a) Сложение двух векторов.
        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            Vector result = new Vector(vector2);
            result.Add(vector1);

            return result;
        }

        // (5b) Вычитание двух векторов.
        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            Vector result = new Vector(vector2);
            result.Subtract(vector1);

            return result;
        }

        // (5c) Скалярное произведение.
        public static double GetScalarProduct(Vector vector1, Vector vector2)
        {
            int minDimension = Math.Min(vector1.Dimension, vector2.Dimension);

            double result = 0;

            for (int i = 0; i < minDimension; i++)
            {
                result += vector1.Components[i] * vector2.Components[i];
            }

            return result;
        }
    }
}