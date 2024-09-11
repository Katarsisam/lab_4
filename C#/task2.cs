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
        Console.WriteLine("������� 1.");
        Console.Write("������:");
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
        Console.WriteLine("������� 2.");
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
        Console.WriteLine($"������������ ������������� ���������: {mulMinus}");
        Console.WriteLine($"����� ������������� ���������: {sumPlus}");
    }

    static char ChangeCase(char c)
    {
        return char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c);
    }

    static void Task3(string str)
    {
        Console.WriteLine("������� 3.");
        Console.WriteLine($"������� ������: {str}");
        string result = new string(str.Select(ChangeCase).ToArray());
        Console.WriteLine($"C����� c ���������� ����������: {result}");
    }

    static List<int> GenerateRandomIntArray(int size)
    {
        return Enumerable.Range(0, size).Select(_ => GetIntRandomNum(-100, 100)).ToList();
    }

    static void Task4(List<int> arr)
    {
        Console.WriteLine("������� 4.");
        Console.Write("������� ������:");
        int count = 0;
        for (int i = 0; i < arr.Count; i++)
        {
            Console.Write($"{arr[i]},");
            if (i > 0 && i < arr.Count - 1 && arr[i] > arr[i - 1] && arr[i] > arr[i + 1])
            {
                count++;
            }
        }
        Console.WriteLine($"\n���������� ���������, �������� ������� ������ �������: {count}");
    }

    static void Task5()
    {
        Console.WriteLine("������� 5.");
        Console.Write("������� ������ n: ");
        int n;
        do
        {
            n = int.Parse(Console.ReadLine());
            if (n < 10)
                Console.Write("n<10, ������� ������ ������: ");
        } while (n < 10);

        int size = GetIntRandomNum(10, n);
        var arr = GenerateRandomIntArray(size);
        Console.WriteLine($"�������� ������: {string.Join(", ", arr)}");
        int sum1 = arr.Sum();
        Console.WriteLine($"����� ��������� ��������� �������: {sum1}");

        Console.Write("�������������� ������: ");
        arr = arr.OrderBy(_ => random.Next()).ToList();
        Console.WriteLine(string.Join(", ", arr));

        Console.Write("��������������� �� ����������� ������: ");
        arr.Sort();
        Console.WriteLine(string.Join(", ", arr));

        Console.Write("����� ������: ");
        arr = GenerateRandomIntArray(size);
        Console.WriteLine(string.Join(", ", arr));
        int sum2 = arr.Sum();
        Console.WriteLine($"����� ��������� ����������� �������: {sum2}");

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

