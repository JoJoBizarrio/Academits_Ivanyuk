using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorTask
{
    internal class Vector
    {
        public int Dimension { get; set; } // это вроде можно убрать, но это не точно.

        public double[] Array { get; set; }

        /// <summary>
        /// (1a) Создание вектора с размерностью dimension.
        /// </summary>
        /// <param name="dimension"> Размерность вектора. </param>
        /// <exception cref="ArgumentException"> Если размерность <= 0. </exception>
        public Vector(int dimension)
        {
            if (dimension <= 0)
            {
                throw new ArgumentException("Dimension must be > 0");
            }

            Dimension = dimension;
            Array = new double[dimension];

            for (int i = 0; i < dimension; i++)
            {
                Array[i] = 0;
            }
        }

        /// <summary>
        /// (1b) Копировать из вектора в вектор.
        /// </summary>
        /// <param name="VectorPurpose"></param>
        public Vector(Vector givingVector)
        {
            int givingVectorSize = givingVector.GetSize();

            Array = new double[givingVectorSize];

            for (int i = 0; i < givingVectorSize; i++)
            {
                Array[i] = givingVector.GetElement(i);
            }
        }

        /// <summary>
        /// (1c) Копирует значения из массива в вектор.
        /// </summary>
        /// <param name="array"></param>
        public Vector(double[] array)
        {
            Array = new double[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                Array[i] = array[i];
            }
        }

        /// <summary>
        /// (1d) Заполнение вектора значениями из массива. Если длина массива меньше dimension, то в остальных компонентах 0.
        /// </summary>
        /// <param name="dimension"></param>
        /// <param name="array"></param>
        public Vector(int dimension, double[] array)
        {
            Dimension = dimension;
            Array = new double[dimension];

            for (int i = 0; i < array.Length; i++)
            {
                Array[i] = array[i];
            }

            for (int i = array.Length; i < dimension; i++)
            {
                Array[i] = 0;
            }
        }

        /// <summary>
        /// (2) Метод для получения размерности вектора.
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            return Dimension;
        }

        /// <summary>
        /// (3) Выдает компоненты вектора через запятую { 1, 2, 3 }.
        /// </summary>
        public string toString()
        {
            string information = "{ ";

            foreach (double e in Array)
            {
                information += e + ", ";
            }

            return information.Substring(0, information.Length - 2) + " }";
        }

        /// <summary>
        /// (4a) Прибавление к вектору другого вектора.
        /// </summary>
        /// <param name="addedVector"></param>
        public void Add(Vector addedVector)
        {
            for (int i = 0; i < addedVector.GetSize(); i++)
            {
                Array[i] += addedVector.GetElement(i);
            }
        }

        /// <summary>
        /// (4b) Вычитание вектора из другого вектора.
        /// </summary>
        /// <param name="subtractedVector"></param>
        public void Subtract(Vector subtractedVector)
        {
            for (int i = 0; i < subtractedVector.GetSize(); i++)
            {
                Array[i] -= subtractedVector.GetElement(i);
            }
        }

        /// <summary>
        /// (4d) Разворачивает вектор.
        /// </summary>
        /// <param name="unwrapVector"></param>
        public void Revert(Vector unwrapVector)
        {
            for (int i = 0; i < unwrapVector.GetSize(); i++)
            {
                unwrapVector.ChangeElement(unwrapVector.GetElement(i) * (-1), i);
            }
        }

        /// <summary>
        /// (4e) Получение длины вектора.
        /// </summary>
        /// <returns></returns>
        public double Length()
        {
            double length = 0.0;

            for (int i = 0; i < GetSize(); i++)
            {
                length += Math.Pow(GetElement(i), 2);
            }

            return Math.Sqrt(length);
        }

        /// <summary>
        /// (4f) Получение компоненты вектора по индексу.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public double GetElement(int index)
        {
            if (index >= GetSize())
            {
                throw new ArgumentOutOfRangeException();
            }

            return Array[index];
        }

        /// <summary>
        /// (4f) Изменить компоненту вектора по индексу.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public double ChangeElement(double value, int index)
        {
            if (index >= GetSize())
            {
                throw new ArgumentOutOfRangeException();
            }

            return Array[index] = value;
        }

        /// <summary>
        /// (4g) Возвращает true, если вектора одинаковой разммерности и компоненты равны. Иначе false.
        /// </summary>
        /// <param name="compareWithVector"></param>
        /// <returns></returns>
        public bool Equals(Vector compareToVector)
        {
            int vectorSize = GetSize();

            if (vectorSize == compareToVector.GetSize())
            {
                for (int i = 0; i < vectorSize; i++)
                {
                    if (Array[i] != compareToVector.GetElement(i))
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// (5a) Сложение двух векторов.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns> Возвращает результат сложения в виде нового вектора.</returns>
        public static Vector Sum(Vector vector1, Vector vector2)
        {
            int maxDimension;
            int minDimension;
            int vector1Size = vector1.GetSize();
            int vector2Size = vector2.GetSize();

            if (vector1Size >= vector2Size)
            {
                maxDimension = vector1Size;
                minDimension = vector2Size;
            }
            else
            {
                maxDimension = vector2Size;
                minDimension = vector1Size;
            }

            Vector result = new Vector(maxDimension);

            for (int i = 0; i < minDimension; i++)
            {
                result.ChangeElement(vector1.GetElement(i) + vector2.GetElement(i), i);
            }

            if (minDimension == maxDimension)
            {
                return result;
            }

            if (vector1Size > vector2Size)
            {
                for (int i = minDimension; i < maxDimension; i++)
                {
                    result.ChangeElement(vector1.GetElement(i), i);
                }
            }
            else
            {
                for (int i = minDimension; i < maxDimension; i++)
                {
                    result.ChangeElement(vector2.GetElement(i), i);
                }
            }

            return result;
        }

        /// <summary>
        /// (5b) Вычитание двух векторов.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns>Возвращает результат вычитания в виде нового вектора.</returns>
        public static Vector Subtract(Vector vector1, Vector vector2)
        {
            int maxDimension;
            int minDimension;
            int vector1Size = vector1.GetSize();
            int vector2Size = vector2.GetSize();

            if (vector1Size >= vector2Size)
            {
                maxDimension = vector1Size;
                minDimension = vector2Size;
            }
            else
            {
                maxDimension = vector2Size;
                minDimension = vector1Size;
            }

            Vector result = new Vector(maxDimension);

            for (int i = 0; i < minDimension; i++)
            {
                result.ChangeElement(vector1.GetElement(i) - vector2.GetElement(i), i);
            }

            if (minDimension == maxDimension)
            {
                return result;
            }

            if (vector1Size > vector2Size)
            {
                for (int i = minDimension; i < maxDimension; i++)
                {
                    result.ChangeElement(-1 * vector1.GetElement(i), i);
                }
            }
            else
            {
                for (int i = minDimension; i < maxDimension; i++)
                {
                    result.ChangeElement(-1 * vector2.GetElement(i), i);
                }
            }

            return result;
        }

        /// <summary>
        /// (5c) Скалярное произведение.
        /// </summary>
        /// <returns></returns>
        public double MultiplyScalarly(Vector vector1, Vector vector2)
        {
            int minDimension;
            int vector1Size = vector1.GetSize();
            int vector2Size = vector2.GetSize();

            if (vector1Size >= vector2Size)
            {
                minDimension = vector2Size;
            }
            else
            {
                minDimension = vector1Size;
            }

            double result = 0;

            for (int i = 0; i < minDimension; i++)
            {
                result += vector1.GetElement(i) * vector2.GetElement(i);
            }

            return result;
        }
    }
}