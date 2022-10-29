﻿using System;
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
        class Rectangle : Geometric_Figure
        {
            private Point p1;
            private Point p2;
            private Point p3;
            private Point p4;
            private double side1;
            private double side2;
            public Rectangle(Point _p1, double _side1, double _side2)
            {
                side1 = _side1;
                side2 = _side2;
                p1 = _p1;
                p2 = new Point(p1.x + side1, p1.y);
                p3 = new Point(p1.x + side1, p1.y + side2);
                p4 = new Point(p1.x, p2.y + side2);
            }

            public override double Figure_Square()
            {
                return side1 * side2;
            }
            public override double Figure_Perimeter()
            {
                return 2 * (side1 + side2);
            }
            public override string ToString()
            {
                string temp;
                Console.WriteLine("Это прямоугольник. Его точки:");
                temp = p1.ToString() + " " + p2.ToString() + " " + p3.ToString()
                    + " " + p4.ToString()
                    + $"\nПервая сторона прямоугольника равна {side1}."
                    + $"\nВторая сторона прямоугольника равна {side2}.";
                Console.WriteLine(temp);
                return temp;
            }
        }
        class Parallelogram : Geometric_Figure
        {
            private Point p1;
            private Point p2;
            private Point p3;
            private Point p4;
            private double side1;
            private double side2;
            private double height;
            public Parallelogram(Point _p1, Point _p2, Point _p4)
            {
                p1 = _p1;
                p2 = _p2;
                p4 = _p4;
                height = Math.Abs(p1.y - p4.y);
                side2 = p1.distance(p4);
                side1 = p1.distance(p2);     
                p3 = new Point(p2.x + p4.x - p1.x, p4.y);              
            }

            public override double Figure_Square()
            {
                return side1 * height;
            }
            public override double Figure_Perimeter()
            {
                return 2 * (side1 + side2);
            }
            public override string ToString()
            {
                string temp;
                Console.WriteLine("Это параллелограмм. Его точки:");
                temp = p1.ToString() + " " + p2.ToString() + " " + p3.ToString()
                    + " " + p4.ToString()
                    + $"\nПервая сторона равна {side1}."
                    + $"\nВторая сторона равна {side2}."
                    + $"\nВысота параллелограмма {height}.";
                Console.WriteLine(temp);
                return temp;
            }
        }
        class Trapezoid : Geometric_Figure
        {
            private Point p1;
            private Point p2;
            private Point p3;
            private Point p4;
            private double side_up;
            private double side_down;
            private double side;
            private double height;
            public Trapezoid(Point _p1, Point _p2, Point _p4)
            {
                p1 = _p1;
                p2 = _p2;
                p4 = _p4;
                height = Math.Abs(p1.y - p4.y);
                side = p1.distance(p4);
                side_down = p1.distance(p2);
                p3 = new Point(p2.x - (p4.x - p1.x), p4.y);
                side_up = p4.distance(p3);
            }

            public override double Figure_Square()
            {
                return (side_up + side_down) * height / 2;
            }
            public override double Figure_Perimeter()
            {
                return 2 * side + side_up + side_down;
            }
            public override string ToString()
            {
                string temp;
                Console.WriteLine("Это трапеция. Ее точки:");
                temp = p1.ToString() + " " + p2.ToString() + " " + p3.ToString()
                    + " " + p4.ToString()
                    + $"\nВерхняя сторона равна {side_up}."
                    + $"\nНижняя сторона равна {side_down}."
                    + $"\nБоковая сторона равна {side}."
                    + $"\nВысота трапеции {height}.";
                Console.WriteLine(temp);
                return temp;
            }
        }
        class Circle : Geometric_Figure
        {
            private Point center;
            private double radius;
            public Circle(Point _center, double _radius)
            {
                center = _center;
                radius = _radius;          
            }

            public override double Figure_Square()
            {
                return Math.PI * Math.Pow(radius, 2);
            }
            public override double Figure_Perimeter()
            {
                return 2 * Math.PI * radius;
            }
            public override string ToString()
            {
                string temp;
                Console.WriteLine("Это круг. Его центр:");
                temp = center.ToString() 
                    + $"\nРадиус круга {radius}.";
                Console.WriteLine(temp);
                return temp;
            }
        }
        class Ellipse : Geometric_Figure
        {
            private double eccentricity;
            private Point focus1;
            private Point focus2;
            private Point center;
            private Point up;
            private Point down;
            private Point left;
            private Point right;
            private double radius1;
            private double radius2;
            public Ellipse(Point _focus1, Point _focus2, double _eccentricity)
            {
                focus1 = _focus1;
                focus2 = _focus2;
                eccentricity = _eccentricity;
                center = new Point((focus1.x + focus2.x) / 2, focus1.y);
                radius1 = center.distance(focus1) / eccentricity;
                left = new Point(center.x - radius1, center.y);
                right = new Point(center.x + radius1, center.y);
                radius2 = Math.Sqrt(radius1 * radius1 - 
                    Math.Pow(focus1.distance(center),2));
                up = new Point(center.x, center.y + radius2);
                down = new Point(center.x, center.y - radius2);
            }

            public override double Figure_Square()
            {
                return Math.PI * radius1 * radius2;
            }
            public override double Figure_Perimeter()
            {
                double perim = Math.PI * radius1 * radius2;
                perim += Math.Pow(radius1 - radius2, 2);
                perim /= (radius1 + radius2);

                return perim*4;
            }
            public override string ToString()
            {
                string temp;
                Console.Write("Это эллипс. Его центр:");
                temp = center.ToString()
                    + $"\nПервый фокус эллипса {focus1}"
                    + $"\nВторой фокус эллипса {focus2}"
                    + $"\nПервый радиус эллипса {radius1}."
                    + $"\nВторой радиус эллипса {radius2}."
                    + $"\nВерхняя вершина эллипса {up}"
                    + $"\nНижняя вершина эллипса {down}"
                    + $"\nЛевая вершина эллипса {left}"
                    + $"\nПравая вершина эллипса {right}"
                    + $"\nЭксцентриситет эллипса {eccentricity}";
                Console.WriteLine(temp);
                return temp;
            }
        }

        class CompositeFigure: Geometric_Figure
        {
            private Geometric_Figure[] geoFigures;
            public CompositeFigure(Geometric_Figure[] _geoFigures)
            {
                geoFigures = _geoFigures;
            }
            public override double Figure_Square()
            {
                double sum = 0;
                foreach(var it in geoFigures)
                {
                    sum += it.Figure_Square();
                }

                return sum;
            }
            public override double Figure_Perimeter()
            {
                double sum = 0;
                foreach (var it in geoFigures)
                    sum += it.Figure_Perimeter();
                return sum;
            }
            public override string ToString()
            {
                string temp_s = "Это сложная фигура! Она состоит из следующих фигур:\n";
                Console.WriteLine(temp_s);
                foreach(var it in geoFigures)
                {
                    temp_s += it.ToString();
                    Console.WriteLine();
                }
                return temp_s;
            }
        }

        static void Main(string[] args)
        {
            Point p1 = new Point(4, 0);
            Point p2 = new Point(0, 0);
            Point p3 = new Point(0, 3);
            Point p4 = new Point(3, 4);
            Point p5 = new Point(-4, 0);

            Triangle t1 = new Triangle(p1, p2, p3);
            t1.ToString();
            Console.WriteLine($"Площадь треугольника равна {t1.Figure_Square()}");
            Console.WriteLine($"Периметр треугольника равен {t1.Figure_Perimeter()}");
            Console.WriteLine();

            Square s1 = new Square(p1, 5);
            s1.ToString();
            Console.WriteLine($"Площадь квадрата равна {s1.Figure_Square()}");
            Console.WriteLine($"Периметр квадрата равен {s1.Figure_Perimeter()}\n");
            Console.WriteLine();

            Diamond d1 = new Diamond(p2, 3, 4);
            d1.ToString();
            Console.WriteLine($"Площадь ромба равна {d1.Figure_Square()}");
            Console.WriteLine($"Периметр ромба равен {d1.Figure_Perimeter()}\n");
            Console.WriteLine();
            
            Rectangle r1 = new Rectangle(p2, 3, 4);
            r1.ToString();
            Console.WriteLine($"Площадь прямоугольника равна {r1.Figure_Square()}");
            Console.WriteLine($"Периметр прямоугольника равен {r1.Figure_Perimeter()}\n");
            Console.WriteLine();

            Parallelogram par1 = new Parallelogram(p2, p1, p4);
            par1.ToString();
            Console.WriteLine($"Площадь параллелограмма равна {par1.Figure_Square()}");
            Console.WriteLine($"Периметр параллелограмма равен {par1.Figure_Perimeter()}\n");
            Console.WriteLine();

            Trapezoid trap1 = new Trapezoid(p2, p1, p4);
            trap1.ToString();
            Console.WriteLine($"Площадь трапеции равна {trap1.Figure_Square()}");
            Console.WriteLine($"Периметр трапеции равен {trap1.Figure_Perimeter()}\n");
            Console.WriteLine();

            Circle c1 = new Circle(p2, 5);
            c1.ToString();
            Console.WriteLine($"Площадь круга равна {c1.Figure_Square()}");
            Console.WriteLine($"Периметр круга равен {c1.Figure_Perimeter()}\n");
            Console.WriteLine();

            Ellipse e1 = new Ellipse(p1, p5, 0.8);
            e1.ToString();
            Console.WriteLine($"Площадь эллипса равна {e1.Figure_Square()}");
            Console.WriteLine($"Периметр эллипса равен {e1.Figure_Perimeter()}\n");
            Console.WriteLine();

            Geometric_Figure[] gf1 = new Geometric_Figure[] { t1, s1, d1 };
            CompositeFigure cf1 = new CompositeFigure(gf1);
            cf1.ToString();
            Console.WriteLine($"Площадь сложной фигуры равна {cf1.Figure_Square()}");
            Console.WriteLine($"Периметр сложной фигуры равен {cf1.Figure_Perimeter()}\n");
            Console.WriteLine();



        }
    }
}
