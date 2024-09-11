using System;
using System.Collections.Generic;

class Program
{
    // �������� "����������"
    static bool Confiding(int roundNumber, List<bool> selfChoices, List<bool> enemyChoices) 
    {
        // ������ ������������, ���������� �� ���������� �����
        return true;
    }

    // �������� "�����������"
    static bool Revengeful(int roundNumber, List<bool> selfChoices, List<bool> enemyChoices) 
    {
        // ������������, ���� � ���������� ������ ��������� ����� �����������, ����� �������
        if (roundNumber == 0 || enemyChoices[roundNumber - 1]) 
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

    // �������� "����������"
    static bool Careful(int roundNumber, List<bool> selfChoices, List<bool> enemyChoices) 
    {
        // ������������, ���� � ���������� 3 ������� ��������� 2 ���� ��� ������ �����������, ����� �������
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
        // ���������� ��������� ���������� ������� �� 100 �� 200
        Random random = new Random();
        int totalRounds = random.Next(100, 201);

        // ������� ��� �������� ������� �������
        List<bool> player1Choices = new List<bool>(new bool[totalRounds]);
        List<bool> player2Choices = new List<bool>(new bool[totalRounds]);

        // ����� ���������� ��� �������
        Func<int, List<bool>, List<bool>, bool> player1Algorithm = Revengeful;
        Func<int, List<bool>, List<bool>, bool> player2Algorithm = Confiding;

        // ������� ����
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

        // ����� �����������
        Console.WriteLine("���������� �������: " + totalRounds);
        Console.WriteLine("���� ������ 1: " + player1Score);
        Console.WriteLine("���� ������ 2: " + player2Score);
    }
}

