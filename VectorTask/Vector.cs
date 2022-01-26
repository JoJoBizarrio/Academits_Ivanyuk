using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorTask
{
    internal class Vector
    {
        public int Dimension { get; set; } // это вроде можно убрать

        public double[] vector { get; set; }

        /// <summary>
        /// (1a) Создание вектора с размерностью dimension.
        /// </summary>
        /// <param name="dimension"> Размерность вектора. </param>
        /// <exception cref="ArgumentException"> Если размерность <= 0. </exception>
        public Vector(int dimension)
        {
            if (dimension <= 0)
            {
                throw new ArgumentException("dimension must be > 0");
            }

            Dimension = dimension;
            vector = new double[dimension];

            for (int i = 0; i < dimension; i++)
            {
                vector[i] = 0;
            }
        }

        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vectorPurpose"></param>
        public Vector(Vector vectorPurpose)
        {
            vector = new double[vectorPurpose.Length()];

            for (int i = 0; i < vectorPurpose.Length(); i++)
            {
                vectorPurpose[i] = vector[i];
            }

        }
        */

        /// <summary>
        /// (1c) Копирует значения из массива в вектор.
        /// </summary>
        /// <param name="array"></param>
        public Vector(double[] array)
        {
            vector = new double[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                vector[i] = array[i];
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
            vector = new double[dimension];

            for (int i = 0; i < array.Length; i++)
            {
                vector[i] = array[i];
            }

            for (int i = array.Length; i < dimension; i++)
            {
                vector[i] = 0;
            }
        }

        /// <summary>
        /// (3) Выдает компоненты вектора через запятую { 1, 2, 3 }.
        /// </summary>
        public string toString()
        {
            string information = "{ ";

            foreach (int e in vector)
            {
                information += vector[e] + ", ";
            }

            return information.Substring(0, information.Length - 2) + " }";
        }

        public int GetSize()
        {
            return Dimension;
        }

        public int Length()
        {
            return Dimension;
        }


    }
}