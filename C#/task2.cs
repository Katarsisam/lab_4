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

    static int FindMax(List<double> arr)
    {
        return arr.IndexOf(arr.Max());
    }

    static void Task2(List<double> arr, int maxIndex)
    {
        Console.WriteLine("������� 2.");
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
        Console.WriteLine("������� 5.");
        int size = GetIntRandomNum(0, 10);
        var arr = GenerateRandomIntArray(size);
        Console.Write("�������� ������:");
        foreach (var item in arr)
        {
            Console.Write($"{item}, ");
        }
        int sum1 = SumArray(arr);
        Console.WriteLine($"\n����� ��������� ��������� �������: {sum1}");

        // ����� ������ ���� ������� ������ ���� � ������ �������

        Sort(arr);
        Console.Write("��������������� �� ����������� ������:");
        foreach (var item in arr)
        {
            Console.Write($"{item}, ");
        }
        int sum2 = SumArray(arr);
        Console.WriteLine($"\n����� ��������� ����������� �������: {sum2}");

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