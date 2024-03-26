using System;

class Circle
{
    private double radius;
    private double centerX;
    private double centerY;

    public Circle(double radius, double centerX, double centerY)
    {
        this.radius = radius;
        this.centerX = centerX;
        this.centerY = centerY;
    }

    public double CalculateSurface()
    {
        return Math.PI * radius * radius;
    }

    public double CalculatePerimeter()
    {
        return 2 * Math.PI * radius;
    }

    public bool IsPointInside(double x, double y)
    {
        double distance = Math.Sqrt(Math.Pow((x - centerX), 2) + Math.Pow((y - centerY), 2));
        return distance <= radius;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Circle with radius {radius}:");
        Console.WriteLine($"Surface: {CalculateSurface()}");
        Console.WriteLine($"Perimeter: {CalculatePerimeter()}");
    }
}

class Program
{
    static Circle[] CreateCircles(int numberOfCircles)
    {
        Circle[] circles = new Circle[numberOfCircles];
        for (int i = 0; i < numberOfCircles; i++)
        {
            Console.WriteLine($"Enter details for circle {i + 1}:");
            Console.Write("Radius: ");
            double radius = Convert.ToDouble(Console.ReadLine());
            Console.Write("Center X coordinate: ");
            double centerX = Convert.ToDouble(Console.ReadLine());
            Console.Write("Center Y coordinate: ");
            double centerY = Convert.ToDouble(Console.ReadLine());

            circles[i] = new Circle(radius, centerX, centerY);
        }
        return circles;
    }

    static void PrintCircleInfo(Circle[] circles)
    {
        foreach (var circle in circles)
        {
            circle.PrintInfo();
        }
    }

    static void CheckPointInCircles(Circle[] circles, double x, double y)
    {
        for (int i = 0; i < circles.Length; i++)
        {
            Console.WriteLine($"Point ({x},{y}) is {(circles[i].IsPointInside(x, y) ? "inside" : "outside")} of circle {i + 1}");
        }
    }

    static void Main(string[] args)
    {
        Console.Write("Enter the number of circles: ");
        int numberOfCircles = Convert.ToInt32(Console.ReadLine());

        Circle[] circles = CreateCircles(numberOfCircles);

        Console.WriteLine("\nInformation of each circle:");
        PrintCircleInfo(circles);

        Console.WriteLine("\nEnter a point to check its position with respect to circles:");
        Console.Write("X coordinate: ");
        double pointX = Convert.ToDouble(Console.ReadLine());
        Console.Write("Y coordinate: ");
        double pointY = Convert.ToDouble(Console.ReadLine());

        CheckPointInCircles(circles, pointX, pointY);
    }
}
