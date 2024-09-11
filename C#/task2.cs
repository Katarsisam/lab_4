using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // VARIANT 13

    static Random random = new Random();

    static double GetFpRandomNum(int min, int max)
    {
        return random.NextDouble() * (max - min) + min;
    }

    static int GetIntRandomNum(int min, int max)
    {
        return random.Next(min, max + 1);
    }

    static List<double> Task1()
    {
        Console.WriteLine("Задание 1.");
        Console.Write("Массив:");
        int size = 10;
        var arr = new List<double>(size);
        for (int i = 0; i < size; i++)
        {
            arr.Add(GetFpRandomNum(-100, 100));
            Console.Write($"{arr[i]}, ");
        }
        Console.WriteLine();
        return arr;
    }

    static int FindMax(List<double> arr)
    {
        return arr.IndexOf(arr.Max());
    }

    static void Task2(List<double> arr, int maxIndex)
    {
        Console.WriteLine("Задание 2.");
        double mulMinus = 1;
        double sumPlus = 0;
        for (int i = 0; i < maxIndex; i++)
        {
            if (arr[i] < 0)
            {
                mulMinus *= arr[i];
            }
            else
            {
                sumPlus += arr[i];
            }
        }
        Console.WriteLine($"Произведение отрицательных элементов: {mulMinus}");
        Console.WriteLine($"Сумма положительных элементов: {sumPlus}");
    }

    static char ChangeCase(char c)
    {
        return char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c);
    }

    static void Task3(string str)
    {
        Console.WriteLine("Задание 3.");
        Console.WriteLine($"Входная строка: {str}");
        string result = new string(str.Select(ChangeCase).ToArray());
        Console.WriteLine($"Cтрока c изменёнными регистрами: {result}");
    }

    static List<int> GenerateRandomIntArray(int size)
    {
        return Enumerable.Range(0, size).Select(_ => GetIntRandomNum(-100, 100)).ToList();
    }

    static void Task4(List<int> arr)
    {
        Console.WriteLine("Задание 4.");
        Console.Write("Входной массив:");
        int count = 0;
        for (int i = 0; i < arr.Count; i++)
        {
            Console.Write($"{arr[i]},");
            if (i > 0 && i < arr.Count - 1 && arr[i] > arr[i - 1] && arr[i] > arr[i + 1])
            {
                count++;
            }
        }
        Console.WriteLine($"\nКоличество элементов, значение которых больше соседей: {count}");
    }

    static int SumArray(List<int> arr)
    {
        return arr.Sum();
    }

    static void Sort(List<int> arr)
    {
        arr.Sort();
    }

    static void Task5()
    {
        Console.WriteLine("Задание 5.");
        int size = GetIntRandomNum(0, 10);
        var arr = GenerateRandomIntArray(size);
        Console.Write("Исходный массив:");
        foreach (var item in arr)
        {
            Console.Write($"{item}, ");
        }
        int sum1 = SumArray(arr);
        Console.WriteLine($"\nСумма элементов исходного массива: {sum1}");

        // Здесь должна быть функция замены цифр в числах массива

        Sort(arr);
        Console.Write("Отсортированный по возрастанию массив:");
        foreach (var item in arr)
        {
            Console.Write($"{item}, ");
        }
        int sum2 = SumArray(arr);
        Console.WriteLine($"\nСумма элементов полученного массива: {sum2}");

        if (sum2 > sum1)
        {
            Console.WriteLine($"{sum2} > {sum1}");
        }
        else if (sum2 < sum1)
        {
            Console.WriteLine($"{sum2} < {sum1}");
        }
        else
        {
            Console.WriteLine($"{sum2} = {sum1}");
        }
    }

    static void Main()
    {
        var arrTask1 = Task1();
        Task2(arrTask1, FindMax(arrTask1));
        Task3("hello");
        Task4(GenerateRandomIntArray(GetIntRandomNum(0, 10)));
        Task5();
    }
}