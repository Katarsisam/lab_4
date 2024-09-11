using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void FillingTheVector(List<int> vec) // Fill the list with random numbers
    {
        Random random = new Random();
        for (int i = 0; i < vec.Count; i++)
        {
            vec[i] = random.Next(1, 101); // Generate random nums from 1 to 100
        }
    }

    static int ElementCountInVector(List<int> container, int element) // Count occurrences of a given element in the list
    {
        return container.Count(value => value == element);
    }

    static double MathExpectation(List<int> container) // Calculate the real mathematical expectation
    {
        double Mx = 0.0;
        foreach (var value in container)
        {
            Mx += value * 0.01; // Range of numbers 100. Each equally probable
        }
        return Mx;
    }

    static double MathExp(List<int> container) // Calculate expected mathematical expectation
    {
        return container.Count / 2.0; // For uniform distribution, the expectation is the average of the bounds
    }

    static double MathDispersion(List<int> container) // Function to calculate variance
    {
        double Mx = MathExpectation(container); // Calculate variance relative to the real expectation
        double sum = 0.0;
        foreach (var value in container)
        {
            sum += Math.Pow(value - Mx, 2); // Sum the square of the difference between all values and the expectation
        }
        return sum / container.Count; // Divide by the number of samples
    }

    static double ChiSquare(List<int> container)
    {
        double chi = 0.0;
        for (int i = 0; i < 10; i++) // Iterate over 10 intervals
        {
            int observed = ElementCountInVector(container, i * 10); // Observed frequency
            double expected = container.Count * 0.1; // Expected frequency

            chi += Math.Pow(observed - expected, 2) / expected;
        }
        return chi;
    }

    static void Main()
    {
        List<int> vector50 = new List<int>(new int[50]);
        FillingTheVector(vector50);

        List<int> vector100 = new List<int>(new int[100]);
        FillingTheVector(vector100);

        List<int> vector1000 = new List<int>(new int[1000]);
        FillingTheVector(vector1000);

        double criticalValue;

        // For 50 elements
        criticalValue = 66.338; // Critical value of chi-square for 49 degrees of freedom and significance level 0.05
        Console.WriteLine($"Критическое значение X^2 для 50 элементов {criticalValue}");
        double chiSquareValue = ChiSquare(vector50);
        double meanExpected = MathExpectation(vector50); // Real mathematical expectation
        double meanObserved = MathExp(vector50); // Expected mathematical expectation

        Console.WriteLine($"X^2: {chiSquareValue}");

        if (chiSquareValue <= criticalValue)
        {
            Console.WriteLine("Гипотеза о нормальном распределении не отвергается.");
        }
        else
        {
            Console.WriteLine("Гипотеза о нормальном распределении отвергается.");
        }

        Console.WriteLine($"Ожидаемое математическое ожидание: {meanObserved}");
        Console.WriteLine($"Реальное математическое ожидание: {meanExpected}");
        Console.WriteLine();

        // For 100 elements
        criticalValue = 124.342;
        Console.WriteLine($"Критическое значение X^2 для 100 элементов {criticalValue}");
        chiSquareValue = ChiSquare(vector100);
        meanExpected = MathExpectation(vector100);
        meanObserved = MathExp(vector100);

        Console.WriteLine($"X^2: {chiSquareValue}");

        if (chiSquareValue <= criticalValue)
        {
            Console.WriteLine("Гипотеза о нормальном распределении не отвергается.");
        }
        else
        {
            Console.WriteLine("Гипотеза о нормальном распределении отвергается.");
        }

        Console.WriteLine($"Ожидаемое математическое ожидание: {meanObserved}");
        Console.WriteLine($"Реальное математическое ожидание: {meanExpected}");
        Console.WriteLine();

        // For 1000 elements
        criticalValue = 1092.32;
        Console.WriteLine($"Критическое значение X^2 для 1000 элементов {criticalValue}");
        chiSquareValue = ChiSquare(vector1000);
        meanExpected = MathExpectation(vector1000);
        meanObserved = MathExp(vector1000);

        Console.WriteLine($"X^2: {chiSquareValue}");

        if (chiSquareValue <= criticalValue)
        {
            Console.WriteLine("Гипотеза о нормальном распределении не отвергается.");
        }
        else
        {
            Console.WriteLine("Гипотеза о нормальном распределении отвергается.");
        }

        Console.WriteLine($"Ожидаемое математическое ожидание: {meanObserved}");
        Console.WriteLine($"Реальное математическое ожидание: {meanExpected}");
        Console.WriteLine();
    }
}
