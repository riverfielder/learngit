using System;

// 接口：形状
public interface IShape
{
    double CalculateArea(); // 计算面积
    bool IsValid();         // 判断形状是否合法
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

    // 判断长方形是否合法
    public bool IsValid()
    {
        return length > 0 && width > 0;
    }

    // 长方形的属性
    public double Length
    {
        get { return length; }
        set { length = value; }
    }

    public double Width
    {
        get { return width; }
        set { width = value; }
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

    // 判断三角形是否合法
    public bool IsValid()
    {
        return side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1 &&
               side1 > 0 && side2 > 0 && side3 > 0;
    }

    // 三角形的属性
    public double Side1
    {
        get { return side1; }
        set { side1 = value; }
    }

    public double Side2
    {
        get { return side2; }
        set { side2 = value; }
    }

    public double Side3
    {
        get { return side3; }
        set { side3 = value; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // 测试长方形
        Rectangle rectangle = new Rectangle(5, 4);
        Console.WriteLine("Rectangle Area: " + rectangle.CalculateArea());
        Console.WriteLine("Rectangle Is Valid: " + rectangle.IsValid());

        // 测试正方形
        Square square = new Square(5);
        Console.WriteLine("Square Area: " + square.CalculateArea());
        Console.WriteLine("Square Is Valid: " + square.IsValid());

        // 测试三角形
        Triangle triangle = new Triangle(3, 4, 5);
        Console.WriteLine("Triangle Area: " + triangle.CalculateArea());
        Console.WriteLine("Triangle Is Valid: " + triangle.IsValid());
    }
}
