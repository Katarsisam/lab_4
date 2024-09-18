using System;
using System.Linq;

class Program
{
    static void InputTable(double LeftPoint, double RightPoint, int N)
    {
        if (N == 1)
        {
            Console.WriteLine("N\t     a \t\t\t     b \t\t\t     b-a ");
            Console.WriteLine("----------------------------------------------------------------------------------");
        }
        Console.WriteLine($"{N} |\t{LeftPoint,10:F6}\t\t{RightPoint,10:F6}\t\t{RightPoint - LeftPoint,12:F6}");
    }

    static void InputNewtonMethod(double LeftPoint, double RightPoint, int N)
    {
        if (N == 1)
        {
            Console.WriteLine("N\t     Xn \t\t\t     Xn+1 \t\t\t     Xn+1-Xn ");
            Console.WriteLine("----------------------------------------------------------------------------------");
        }
        Console.WriteLine($"{N} |\t{LeftPoint,10:F6}\t\t{RightPoint,10:F6}\t\t{RightPoint - LeftPoint,12:F6}");
    }

    static double Function(double x)
    {
        return 2 * Math.Log(x) + 0.5 * x + 1;
    }

    static double Df(double x)
    {
        return 2 / x + 0.5;
    }

    static double ChordMethod(double a, double b, double epsilon)
    {
        int counter = 1;
        while (Math.Abs(b - a) > epsilon)
        {
            InputTable(a, b, counter);
            a = a - (b - a) * Function(a) / (Function(b) - Function(a));
            b = b - (a - b) * Function(b) / (Function(a) - Function(b));
            counter++;
        }
        Console.WriteLine("\nRoot of Method of chord = ");
        return b;
    }

    static double HalfDivisionMethod(double LeftPoint, double RightPoint, double epsilon)
    {
        int iteration = 1;
        double midPoint = 0.0;
        if (Function(LeftPoint) * Function(RightPoint) < 0)
        {
            while (Math.Abs(RightPoint - LeftPoint) > epsilon)
            {
                midPoint = (RightPoint + LeftPoint) / 2;
                InputTable(LeftPoint, RightPoint, iteration);
                if (Function(LeftPoint) * Function(midPoint) < 0)
                    RightPoint = midPoint;
                else
                    LeftPoint = midPoint;
                iteration++;
            }
        }
        else
        {
            Console.WriteLine("The interval is selected incorrectly. The function has the same signs at the ends of the segment");
        }
        Console.WriteLine("\nRoot of Half-separation method = ");
        return midPoint;
    }

    static void FindGraphicalSolution(ref float left, ref float right)
    {
        for (float x = -1; x < 5; x += 0.01f)
        {
            if (Math.Ceiling(Function(x)) == 0)
            {
                left = x - 1.0f;
                right = x + 1.0f;
            }
        }
    }

    static double NewtonMethod(double x0, double epsilon)
    {
        double x;
        for (int i = 1; Math.Abs(Function(x0)) >= epsilon && i < 10; i++)
        {
            x = x0 - Function(x0) / Df(x0);
            InputNewtonMethod(x, x0, i);
            x0 = x;
        }
        Console.WriteLine("\nRoot of Newton's method = ");
        return x0;
    }

    static void Main()
    {
        float left = 0;
        float right = 0;
        float x0 = 5;
        float eps = 0.0001f;

        FindGraphicalSolution(ref left, ref right);

        Console.WriteLine("Newton's method");
        Console.WriteLine($"{NewtonMethod(x0, eps):F6}\n");

        Console.WriteLine("Half-separation method");
        Console.WriteLine($"{HalfDivisionMethod(left, right, eps):F6}\n");

        Console.WriteLine("Method of chord");
        Console.WriteLine($"{ChordMethod(left, right, eps):F6}\n");
    }
}

