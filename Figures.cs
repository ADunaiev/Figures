using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Задание 1.Разработать абстрактный класс «Геометрическая Фигура» 
//с методами «Площадь Фигуры» и «Периметр Фигуры». Разработать классы-наследники: 
//Треугольник, Квадрат, Ромб, Прямоугольник, Параллелограмм, Трапеция, Круг, 
//Эллипс.Реализовать конструкторы, которые однозначно определяют объекты данных 
//классов. Реализовать класс «Составная Фигура», который может состоять из любого 
//количества «Геометрических Фигур». Для данного класса определить метод 
//нахождения площади фигуры. Создать диаграмму взаимоотношений классов.

namespace Figures
{
    internal class Figures
    {
        class Point
        {
            public double x { get; set; }
            public double y { get; set; }

            public Point(double X, double Y)
            {
                x = X;
                y = Y;
            }
            public Point()
            {
                x = 0;
                y = 0;
            }

            public override string ToString()
            {
                return $"({x},{y})";
            }
            public double distance(Point a)
            {
                double dist = 0;
                dist = Math.Sqrt(Math.Pow(x - a.x, 2) + Math.Pow(y - a.y, 2));
                return dist;
            }
        }
        public abstract class Geometric_Figure
        { 
            public abstract double Figure_Square();
            public abstract double Figure_Perimeter();

        }

        class Triangle: Geometric_Figure
        {
            private Point p1;
            private Point p2;
            private Point p3;

            public Triangle(Point _p1, Point _p2, Point _p3)
            {
                p1 = _p1;
                p2 = _p2;
                p3 = _p3;
            }

            public override double Figure_Square()
            {
                double figure_square = 0;
                double a = p1.distance(p2);
                double b = p2.distance(p3);
                double c = p3.distance(p1);
                double p = (a + b + c) / 2;

                figure_square = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

                return figure_square;
            }
            public override double Figure_Perimeter()
            {
                double a = p1.distance(p2);
                double b = p2.distance(p3);
                double c = p3.distance(p1);          

                return a + b + c;
            }

            public override string ToString()
            {
                string temp;
                Console.WriteLine("Это треугольник. Его точки:");
                temp = p1.ToString() + " " + p2.ToString() + " " + p3.ToString();
                Console.WriteLine(temp);
                return temp;
            }
        }
        class Square : Geometric_Figure
        {
            private Point p1;
            private Point p2;
            private Point p3;
            private Point p4;
            private double side;
            public Square(Point _p1, double _side)
            {
                p1 = _p1;
                side = _side;
                p2 = new Point(_p1.x + _side, _p1.y);
                p3 = new Point(_p1.x + _side, _p1.y + _side);
                p4 = new Point(_p1.x, _p1.y + _side);
            }

            public override double Figure_Square()
            {
                return Math.Pow(side, 2);
            }
            public override double Figure_Perimeter()
            {
                return side * 4;
            }

            public override string ToString()
            {
                string temp;
                Console.WriteLine("Это квадрат. Его точки:");
                temp = p1.ToString() + " " + p2.ToString() + " " + p3.ToString() 
                    + " " + p4.ToString() + $"\nСторона кваррата равна {side}.";
                Console.WriteLine(temp);
                return temp;
            }
        }
        class Diamond : Geometric_Figure
        {
            private Point p1;
            private Point p2;
            private Point p3;
            private Point p4;
            private Point center;
            private double radius1;
            private double radius2;
            public Diamond(Point _center, double _radius1, double _radius2)
            {
                center = _center;
                radius1 = _radius1;
                radius2 = _radius2;
                p1 = new Point(center.x + radius1, center.y);
                p2 = new Point(center.x, center.y + radius2);
                p3 = new Point(center.x - radius1, center.y);
                p4 = new Point(center.x, center.y - radius2);
            }

            public override double Figure_Square()
            {
                return radius1*radius2*2;
            }
            public override double Figure_Perimeter()
            {
                return p1.distance(p2) * 4;
            }

            public override string ToString()
            {
                string temp;
                Console.WriteLine("Это ромб. Его точки:");
                temp = p1.ToString() + " " + p2.ToString() + " " + p3.ToString()
                    + " " + p4.ToString() + $"\nСторона ромба равна {p1.distance(p2)}." 
                    + $"\nЦентр ромба: {center}"
                    + $"\nПервый радиус ромба: {radius1}" 
                    + $"\nВторой радиус ромба: {radius2}";
                Console.WriteLine(temp);
                return temp;
            }
        }


        static void Main(string[] args)
        {
            Point p1 = new Point(4, 0);
            Point p2 = new Point(0, 0);
            Point p3 = new Point(0, 3);

            Triangle t1 = new Triangle(p1, p2, p3);

            t1.ToString();
            Console.WriteLine();
            Console.WriteLine($"Площадь треугольника равна {t1.Figure_Square()}");
            Console.WriteLine($"Периметр треугольника равен {t1.Figure_Perimeter()}");
            Console.WriteLine();

            Square s1 = new Square(p1, 5);
            s1.ToString();
            Console.WriteLine();
            Console.WriteLine($"Площадь квадрата равна {s1.Figure_Square()}");
            Console.WriteLine($"Периметр квадрата равен {s1.Figure_Perimeter()}\n");
            Console.WriteLine();

            Diamond d1 = new Diamond(p2, 3, 4);
            d1.ToString();
            Console.WriteLine();
            Console.WriteLine($"Площадь ромба равна {d1.Figure_Square()}");
            Console.WriteLine($"Периметр ромба равен {d1.Figure_Perimeter()}\n");
            Console.WriteLine();
        }
    }
}
