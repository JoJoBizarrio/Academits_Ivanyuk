using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorTask
{
    class VectorTaskMain
    {
        static void Main(string[] args)
        {
            // 1a
            Vector vector1 = new Vector(9); 

            Console.WriteLine(vector1.toString());
            Console.WriteLine(vector1.GetSize());

            double[] array = { 5.3, 1.2, 2.9, 7.7, 3.1 };

            Vector vector2 = new Vector(7, array);

            vector1 = new Vector(vector2);

            Console.WriteLine(vector1.toString());
            Console.WriteLine(vector2.toString());

        }
    }
}