using System;

class Program
{
    private static Random random = new Random();
    private static int x = GetRandom(1000, 2000);
    private static int y = GetRandom(1000, 2000);
    private static int z = GetRandom(1000, 2000);
    private static int w = GetRandom(1000, 2000);

    static int GetRandom(int min, int max) // get random integer number
    {
        return random.Next(min, max + 1);
    }

    private static int XORShift()
    {
        uint t = (uint)(x ^ (x << 11));
        x = y; 
        y = z; 
        z = w;
        return w = (int)(w ^ (w >> 19) ^ t ^ (t >> 8));
    }

    static void Main()
    {
        Console.WriteLine("ГПСЧ XORShift");
        Console.WriteLine("Случайное число: " + XORShift());
    }
}