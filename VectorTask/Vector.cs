using System;
using System.Text;

namespace VectorTask
{
    internal class Vector
    {
        private double[] VectorArray { get; set; }

        // (1a) Создание вектора с размерностью dimension.
        public Vector(int dimension)
        {
            if (dimension <= 0)
            {
                throw new ArgumentException("Dimension must be > 0", "dimension");
            }

            VectorArray = new double[dimension];

            for (int i = 0; i < dimension; i++)
            {
                VectorArray[i] = 0;
            }
        }

        // (1b) Копировать из вектора в вектор.
        public Vector(Vector vector)
        {
            int vectorSize = vector.GetSize();

            VectorArray = new double[vectorSize];

            // VectorArray.CopyTo(vector, 0);

            for (int i = 0; i < vectorSize; i++)
            {
                VectorArray[i] = vector.GetElement(i);
            }
        }

        // (1c) Копирует значения из массива в вектор.
        public Vector(double[] array)
        {
            int arrayLength = array.Length;

            if (arrayLength <= 0)
            {
                throw new ArgumentException("Length of array have to be > 0", "array.Length");
            }

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

            VectorArray = new double[dimension];

            array.CopyTo(VectorArray, 0);
        }

        // (2) Метод для получения размерности вектора.
        public int GetSize()
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

        //(4a) Прибавление к вектору другого вектора.
        public void Add(Vector vector)
        {
            if (GetSize() < vector.GetSize())
            {
                Vector temp = new Vector(VectorArray);
                VectorArray = new double[vector.GetSize()];

                // Array.Resize(ref VectorArray, vector.GetSize()); - не работает

                for (int i = 0; i < temp.GetSize(); i++)
                {
                    VectorArray[i] = temp.GetElement(i);
                }
            }

            for (int i = 0; i < vector.GetSize(); i++)
            {
                VectorArray[i] += vector.GetElement(i);
            }
        }

        // (4b) Вычитание вектора из другого вектора.
        public void Substract(Vector vector)
        {
            if (GetSize() < vector.GetSize())
            {
                Vector temp = new Vector(VectorArray);
                VectorArray = new double[vector.GetSize()];

                // Array.Resize(ref VectorArray, vector.GetSize()); - не работает

                for (int i = 0; i < temp.GetSize(); i++)
                {
                    VectorArray[i] = temp.GetElement(i);
                }
            }

            for (int i = 0; i < vector.GetSize(); i++)
            {
                VectorArray[i] -= vector.GetElement(i);
            }
        }

        // (4c) Умноженение на скялар
        public void MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < GetSize(); i++)
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
            if (index >= GetSize() || index < 0)
            {
                throw new ArgumentOutOfRangeException("index", index, "Index out of range.");
            }

            return VectorArray[index];
        }

        // (4f) Изменить компоненту вектора по индексу.
        public void SetElement(int index, double value)
        {
            if (index >= GetSize() || index < 0)
            {
                throw new ArgumentOutOfRangeException("index", index, "Index out of range.");
            }

            VectorArray[index] = value;
        }

        /*
        // (4g) Возвращает true, если вектора одинаковой разммерности и компоненты равны. Иначе false.
        public bool Equals(Vector compareToVector)
        {
            int vectorSize = GetSize();

            if (vectorSize == compareToVector.GetSize())
            {
                for (int i = 0; i < vectorSize; i++)
                {
                    if (VectorArray[i] != compareToVector.GetElement(i))
                    {
                        return false;
                    }
                }
                
                return true;
            }

            return false;
        }
        */

        // (4g) Возвращает true, если вектора одинаковой разммерности и компоненты равны. Иначе false.
        public bool Equals(Vector compareToVector)
        {
            return base.Equals(compareToVector);
        }

        // (5a) Сложение двух векторов.
        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            Vector result;

            if (vector1.GetSize() >= vector2.GetSize())
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

            if (vector1.GetSize() >= vector2.GetSize())
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