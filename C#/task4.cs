using System;
using System.Collections.Generic;

class Program
{
    // Алгоритм "Доверчивый"
    static bool Confiding(int roundNumber, List<bool> selfChoices, List<bool> enemyChoices) 
    {
        // Всегда сотрудничает, независимо от предыдущих ходов
        return true;
    }

    // Алгоритм "Мстительный"
    static bool Revengeful(int roundNumber, List<bool> selfChoices, List<bool> enemyChoices) 
    {
        // Сотрудничает, если в предыдущем раунде противник также сотрудничал, иначе предает
        if (roundNumber == 0 || enemyChoices[roundNumber - 1]) 
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

    // Алгоритм "Осторожный"
    static bool Careful(int roundNumber, List<bool> selfChoices, List<bool> enemyChoices) 
    {
        // Сотрудничает, если в предыдущих 3 раундах противник 2 раза или больше сотрудничал, иначе предает
        int cooperationCount = 0;
        for (int i = Math.Max(0, roundNumber - 3); i < roundNumber; i++) 
        {
            if (enemyChoices[i]) 
            {
                cooperationCount++;
            }
        }
        return cooperationCount >= 2;
    }

    static void Main() 
    {
        // Генерируем случайное количество раундов от 100 до 200
        Random random = new Random();
        int totalRounds = random.Next(100, 201);

        // Массивы для хранения выборов игроков
        List<bool> player1Choices = new List<bool>(new bool[totalRounds]);
        List<bool> player2Choices = new List<bool>(new bool[totalRounds]);

        // Выбор алгоритмов для игроков
        Func<int, List<bool>, List<bool>, bool> player1Algorithm = Revengeful;
        Func<int, List<bool>, List<bool>, bool> player2Algorithm = Confiding;

        // Игровой цикл
        int player1Score = 0, player2Score = 0;
        for (int round = 0; round < totalRounds; round++) 
        {
            player1Choices[round] = player1Algorithm(round, player1Choices, player2Choices);
            player2Choices[round] = player2Algorithm(round, player2Choices, player1Choices);

            if (player1Choices[round] && player2Choices[round]) 
            {
                player1Score += 24;
                player2Score += 24;
            }
            else if (player1Choices[round] && !player2Choices[round]) 
            {
                player2Score += 20;
            }
            else if (!player1Choices[round] && player2Choices[round]) 
            {
                player1Score += 20;
            }
            else 
            {
                player1Score += 4;
                player2Score += 4;
            }
        }

        // Вывод результатов
        Console.WriteLine("Количество раундов: " + totalRounds);
        Console.WriteLine("Счет игрока 1: " + player1Score);
        Console.WriteLine("Счет игрока 2: " + player2Score);
    }
}

