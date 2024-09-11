using System;
using System.Linq;
using System.Collections.Generic;

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

    static void Task2(List<double> arr)
    {
        Console.WriteLine("Задание 2.");
        double mulMinus = 1;
        double sumPlus = 0;
        foreach (var num in arr)
        {
            if (num < 0)
            {
                mulMinus *= num;
            }
            else
            {
                sumPlus += num;
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

    static void Task5()
    {
        Console.WriteLine("Задание 5.");
        Console.Write("Введите предел n: ");
        int n;
        do
        {
            n = int.Parse(Console.ReadLine());
            if (n < 10)
                Console.Write("n<10, введите другой предел: ");
        } while (n < 10);

        int size = GetIntRandomNum(10, n);
        var arr = GenerateRandomIntArray(size);
        Console.WriteLine($"Исходный массив: {string.Join(", ", arr)}");
        int sum1 = arr.Sum();
        Console.WriteLine($"Сумма элементов исходного массива: {sum1}");

        Console.Write("Перетасованный массив: ");
        arr = arr.OrderBy(_ => random.Next()).ToList();
        Console.WriteLine(string.Join(", ", arr));

        Console.Write("Отсортированный по возрастанию массив: ");
        arr.Sort();
        Console.WriteLine(string.Join(", ", arr));

        Console.Write("Новый массив: ");
        arr = GenerateRandomIntArray(size);
        Console.WriteLine(string.Join(", ", arr));
        int sum2 = arr.Sum();
        Console.WriteLine($"Сумма элементов полученного массива: {sum2}");

        if (sum2 > sum1)
            Console.WriteLine($"{sum2} > {sum1}");
        else if (sum2 < sum1)
            Console.WriteLine($"{sum2} < {sum1}");
        else
            Console.WriteLine($"{sum2} = {sum1}");
    }

    static void Main()
    {
        var arrTask1 = Task1();
        Task2(arrTask1);
        Task3("hello");
        Task4(GenerateRandomIntArray(10));
        Task5();
    }
}

