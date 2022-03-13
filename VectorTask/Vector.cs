using System.Text;

namespace VectorTask
{
    public class Vector
    {
        private double[] _components;

        public int Dimension => _components.Length;

        // (1a) Создание вектора с размерностью dimension.
        public Vector(int dimension)
        {
            if (dimension <= 0)
            {
                throw new ArgumentException($"Dimension must be > 0 ({nameof(dimension)} = {dimension}).", nameof(dimension));
            }

            _components = new double[dimension];
        }

        // (1b) Копировать из вектора в вектор.
        public Vector(Vector vector)
        {
            _components = new double[vector.Dimension];

            Array.Copy(vector._components, _components, vector.Dimension);
        }

        // (1c) Копирует значения из массива в вектор.
        public Vector(double[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException($"Length of array must be > 0 ({nameof(array.Length)} = {array.Length}).", nameof(array.Length));
            }

            _components = new double[array.Length];

            array.CopyTo(_components, 0);
        }

        // (1d) Заполнение вектора значениями из массива. Если длина массива меньше dimension, то в остальных компонентах 0.
        public Vector(int dimension, double[] array)
        {
            if (dimension <= 0)
            {
                throw new ArgumentException($"Dimension must be > 0 ({nameof(dimension)} = {dimension}).", nameof(dimension));
            }

            _components = new double[dimension];

            int minDimension = Math.Min(dimension, array.Length);

            Array.Copy(array, _components, minDimension);
        }

        // (3) Выдает компоненты вектора через запятую {1, 2, 3}.
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append('{');

            foreach (double e in _components)
            {
                stringBuilder.Append($"{e:f1}, ");
            }

            return stringBuilder.Remove(stringBuilder.Length - 2, 2).Append('}').ToString();
        }

        // (4a) Прибавление к вектору другого вектора.
        public void Add(Vector vector)
        {
            if (Dimension < vector.Dimension)
            {
                Array.Resize(ref _components, vector.Dimension);
            }

            for (int i = 0; i < vector.Dimension; i++)
            {
                _components[i] += vector._components[i];
            }
        }

        // (4b) Вычитание вектора из другого вектора.
        public void Subtract(Vector vector)
        {
            if (Dimension < vector.Dimension)
            {
                Array.Resize(ref _components, vector.Dimension);
            }

            for (int i = 0; i < vector.Dimension; i++)
            {
                _components[i] -= vector._components[i];
            }
        }

        // (4c) Умножение на скаляр
        public void MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < Dimension; i++)
            {
                _components[i] *= scalar;
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

            foreach (double e in _components)
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
                throw new ArgumentOutOfRangeException(nameof(index), index, $"Argument out of range: [0; {Dimension - 1}].");
            }

            return _components[index];
        }

        // (4f) Изменить компоненту вектора по индексу.
        public void SetElement(int index, double value)
        {
            if (index < 0 || index >= Dimension)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, $"Argument out of range: [0; {Dimension - 1}].");
            }

            _components[index] = value;
        }

        // (4g) Возвращает true, если вектора одинаковой размерности и компоненты равны. Иначе false.
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Vector vector = (Vector)obj;

            if (Dimension != vector.Dimension)
            {
                return false;
            }

            for (int i = 0; i < Dimension; i++)
            {
                if (_components[i] != vector._components[i])
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
            int hash = 11021996;

            foreach (double e in _components)
            {
                hash = hash * prime + e.GetHashCode();
            }

            return hash;
        }

        // (5a) Сложение двух векторов. vector1 + vector2
        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            Vector result = new Vector(vector1);
            result.Add(vector2);

            return result;
        }

        // (5b) Вычитание двух векторов. vector1 - vector2
        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            Vector result = new Vector(vector1);
            result.Subtract(vector2);

            return result;
        }

        // (5c) Скалярное произведение.
        public static double GetScalarProduct(Vector vector1, Vector vector2)
        {
            int minDimension = Math.Min(vector1.Dimension, vector2.Dimension);

            double result = 0;

            for (int i = 0; i < minDimension; i++)
            {
                result += vector1._components[i] * vector2._components[i];
            }

            return result;
        }
    }
}