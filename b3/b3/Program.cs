using System;
using System.Collections.Generic;

// 接口：形状
public interface IShape
{
    double CalculateArea(); // 计算面积
}

// 长方形类
public class Rectangle : IShape
{
    private double length;
    private double width;

    // 长方形类的构造函数
    public Rectangle(double length, double width)
    {
        this.length = length;
        this.width = width;
    }

    // 长方形的计算面积方法
    public double CalculateArea()
    {
        return length * width;
    }
}

// 正方形类（是长方形的一种特殊情况）
public class Square : Rectangle
{
    // 正方形类的构造函数
    public Square(double side) : base(side, side)
    {
    }
}

// 三角形类
public class Triangle : IShape
{
    private double side1;
    private double side2;
    private double side3;

    // 三角形类的构造函数
    public Triangle(double side1, double side2, double side3)
    {
        this.side1 = side1;
        this.side2 = side2;
        this.side3 = side3;
    }

    // 三角形的计算面积方法（使用海伦公式）
    public double CalculateArea()
    {
        double s = (side1 + side2 + side3) / 2;
        return Math.Sqrt(s * (s - side1) * (s - side2) * (s - side3));
    }
}

// 形状类型枚举
public enum ShapeType
{
    Rectangle,
    Square,
    Triangle
}

// 简单工厂类
public class ShapeFactory
{
    // 创建形状对象的静态方法
    public static IShape CreateShape(ShapeType type, params double[] parameters)
    {
        switch (type)
        {
            case ShapeType.Rectangle:
                return new Rectangle(parameters[0], parameters[1]);
            case ShapeType.Square:
                return new Square(parameters[0]);
            case ShapeType.Triangle:
                return new Triangle(parameters[0], parameters[1], parameters[2]);
            default:
                throw new ArgumentException("Invalid shape type");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        List<IShape> shapes = new List<IShape>();
        double totalArea = 0;

        // 随机创建10个形状对象
        for (int i = 0; i < 10; i++)
        {
            ShapeType type = (ShapeType)random.Next(0, 3);
            IShape shape;

            // 根据随机生成的类型创建对象
            switch (type)
            {
                case ShapeType.Rectangle:
                    shape = ShapeFactory.CreateShape(type, random.Next(1, 10), random.Next(1, 10));
                    break;
                case ShapeType.Square:
                    shape = ShapeFactory.CreateShape(type, random.Next(1, 10));
                    break;
                case ShapeType.Triangle:
                    shape = ShapeFactory.CreateShape(type, random.Next(1, 10), random.Next(1, 10), random.Next(1, 10));
                    break;
                default:
                    throw new ArgumentException("Invalid shape type");
            }

            // 计算并累加面积
            totalArea += shape.CalculateArea();
            shapes.Add(shape);
        }

        // 输出每个形状的面积和总面积
        foreach (var shape in shapes)
        {
            Console.WriteLine($"Shape Area: {shape.CalculateArea()}");
        }

        Console.WriteLine($"Total Area: {totalArea}");
    }
}
