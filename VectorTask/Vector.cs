using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorTask
{
    internal class Vector
    {
        public int Dimension { get; set; }

        public double[] vector { get; set; }

        public Vector(int dimension)
        {
            Dimension = dimension;
            vector = new double[dimension];

            for (int i = 0; i < dimension; i++)
            {
                vector[i] = 0;
            }
        }

        public void GetVector()
        {
            foreach (int e in vector)
            {
                Console.Write(vector[e] + ", ");
            }
        }
    }
}
