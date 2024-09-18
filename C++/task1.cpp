
#include <iostream>
#include <cmath>
#include <iomanip>
using namespace std;

void InputTable(double LeftPoint, double RightPoint, int N)
{
    if (N == 1)
    {
        cout << "N";
        cout << "\t     a ";
        cout << "\t\t\t     b ";
        cout << "\t\t\t     b-a ";
        cout << endl;
        cout << "----------------------------------------------------------------------------------";
        cout << endl;
    }
    cout << N << " |";
    cout << "\t" << setw(10) << LeftPoint;
    cout << "\t\t" << setw(10) << RightPoint;
    cout << "\t\t" << setw(12) << RightPoint - LeftPoint; //сама хорда
    cout << endl;
}
void InputNewtonMethod(double LeftPoint, double RightPoint, int N)
{
    if (N == 1)
    {
        cout << "N";
        cout << "\t     Xn ";
        cout << "\t\t\t     Xn+1 ";
        cout << "\t\t\t     Xn+1-Xn ";
        cout << endl;
        cout << "----------------------------------------------------------------------------------";
        cout << endl;
    }
    cout << N << " |";
    cout << "\t" << setw(10) << LeftPoint;
    cout << "\t\t" << setw(10) << RightPoint;
    cout << "\t\t" << setw(12) << RightPoint - LeftPoint;
    cout << endl;
}
double function(double x) {
    
    return 2 * log(x) + 0.5*x + 1; // Заменить функцией, корни которой мы ищем
}

double df(double x) 
{
    return 2/x + 0.5; // заменить на дифференциал функции, корни которой мы ищем.
}

// a, b - пределы хорды, epsilon — необходимая погрешность
double chordMethod(double a, double b, double epsilon) 
{
    int counter = 1;
    while (abs(b - a) > epsilon) // пока значение хорды больше епсилон; 
    {
        InputTable(a, b, counter);
        a = a - (b - a) * function(a) / (function(b) - function(a)); //уравнение конца а хорды (сокращение)
        b = b - (a - b) * function(b) / (function(a) - function(b));  //уравнение конца б хорды
        counter++;
    }
    // a, b — (i - 1)-й и i-й члены
    cout << "\nRoot of Method of hord = ";
    return b;
}
double HalfDivisionMethod(double LeftPoint, double RightPoint, double epsilon)
{
    int iteration = 1;
    double midPoint = 0.0;
    if (function(LeftPoint) * function(RightPoint) < 0)// проверка на разность знаков функции на концах отрезка (по условию метода)
    {
        while (abs(RightPoint - LeftPoint) > epsilon)// пока интервал больше погрешности (аналог хорд)
        {
            midPoint = (RightPoint + LeftPoint) / 2;
            InputTable(LeftPoint, RightPoint, iteration);
            if (function(LeftPoint) * function(midPoint) < 0)  RightPoint = midPoint;// если функция имеет разные знаки, то правая точка середина отрезка
            else LeftPoint = midPoint;
            //midPoint = (RightPoint + LeftPoint) / 2;
            iteration++;

            //вычисление средней точки, пока разница при сближении не станет меньше эпсилон
        }
    }
    else
    {
        cout << "The interval is selected incorrectly. The function has the same signs at the ends of the segment" << endl;
    }
    cout << "\nRoot of Half-seperation method = ";
    return midPoint;
}

void findGraficalSolution(float& left, float& right) // отделяем корни
{
    for (float x = -1; x < 5; x += 0.01) 
    {
        if (ceil(function(x)) == 0) // Свидение значений слева и справа
        {
            left = x - 1.0;
            right = x + 1.0;

        } //определение концов отрезка функции
    }
}


double NewtownMethod(double x0, double epsilon) 
{
    double x;

    for (int i = 1; abs(function(x0)) >= epsilon && i < 10; i++) //пока модуль функции больше погрешности + предел итерации
    {
        x = x0 - function(x0) / df(x0); // определение нового значения для дифиринцирования функции на касательные отрезки;  
        InputNewtonMethod(x, x0, i);
        x0 = x;
    }
    cout << "\nRoot of Newtons method = ";
    return x;
}


int main(void)
{
    //setlocale(LC_ALL, "Rus");
    float left = 0;
    float right = 0;
    float x0 = 5;
    float eps = 0.0001;

    findGraficalSolution(left, right);// отделяем корни
   // cout << left<<" "<<right<<endl;
    cout << "Newtons method" << endl;
    cout << NewtownMethod(x0, eps) << "\n" << endl;
    cout << "Half-seperation method\n" << endl;
    cout << HalfDivisionMethod(left, right, eps) << endl;
    cout << "\nMethod of hord\n" << endl;
    cout << chordMethod(left, right, eps) << endl;

    return 0;
}