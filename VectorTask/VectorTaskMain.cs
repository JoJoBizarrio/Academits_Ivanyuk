using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorTask
{
    class VectorTask
    {
        static void Main(string[] args)
        {
            Vector vector1 = new Vector(9);

            Console.WriteLine(vector1.toString());
            Console.WriteLine(vector1.GetSize());
        }
    }
}