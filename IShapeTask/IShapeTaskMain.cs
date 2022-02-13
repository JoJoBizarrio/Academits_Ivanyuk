using System;
using System.Collections;

namespace IShapeTask
{
    internal class IShapeTaskMain
    {
        public static double GetMaxArea(IShape[] shapesArray)
        {
            double[] areasArray = new double[shapesArray.Length];

            for (int i = 0; i < shapesArray.Length; i++)
            {
                areasArray[i] = shapesArray[i].GetArea();

                Array.Sort(shapesArray, );
            }


            return areasArray.Max();
        }

        static void Main(string[] args)
        {
            Rectangle rectangle1 = new Rectangle(5, 13);
            Rectangle rectangle2 = new Rectangle(22, 8);

            Cicle cicle1 = new Cicle(21);
            Cicle cicle2 = new Cicle(11);

            Square square1 = new Square(21);
            Square square2 = new Square(11);

            Triangle triangle1 = new Triangle(0, 0, 21, 0, 0, 11);
            Triangle triangle2 = new Triangle(-13, 5, 2, 15, 1, 1);

            IShape[] shapesArray = new IShape[8];

            shapesArray[0] = rectangle1;
            shapesArray[1] = rectangle2;

            shapesArray[2] = cicle1;
            shapesArray[3] = cicle2;

            shapesArray[4] = square1;
            shapesArray[5] = square2;

            shapesArray[6] = triangle1;
            shapesArray[7] = triangle2;

            Console.WriteLine("MaxArea: " + GetMaxArea(shapesArray));

            foreach (IShape e in shapesArray)
            {
                Console.WriteLine(e.GetArea());
            }
        }
    }
}

/*
    Все фигуры должны реализовывать этот интерфейс и правильным образом определять данные методы
1.	Square – квадрат
Должен иметь конструктор, принимающий длину стороны
2.	Triangle – треугольник
Должен иметь конструктор, принимающий x1, y1, x2, y2, x3, y3 – шесть координат.
В качестве ширины возвращать max(x1, x2, x3) – min(x1, x2, x3)
В качестве высоты возвращать max(y1, y2, y3) – min(y1, y2, y3)
3.	Rectangle – прямоугольник
Должен иметь конструктор, принимающий длины двух сторон
4.	Circle – окружность
Должна иметь конструктор, принимающий радиус. В качестве ширины и высоты должен выдаваться диаметр

Часть 2. В main в коде объявить массив фигур, чтобы в нём было около 5-10 разных фигур. Задача – написать функцию, которая находит фигуру с максимальной площадью. Вызвать её для этого массива и распечатать информацию о фигуре в консоль. 
Аналогично найдите фигуру со вторым по величине периметром.
Поиск фигур реализовать через стандартный метод Arrays.sort (в C# Array.Sort) с компаратором. Что такое компаратор почитайте сами, но если будут вопросы, задавайте.

Часть 3. Переопределите в фигурах методы toString, hashCode, equals (в C# - ToString, GetHashCode, Equals)
     */