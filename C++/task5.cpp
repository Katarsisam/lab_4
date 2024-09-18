#include <iostream>

#include <iostream>
#include <random>
#include <vector>
#include <algorithm>

using namespace std;
// VAR 3



int get_random(int min, int max) // get random integer number
{
    random_device rd;
    mt19937 generator(rd());
    uniform_int_distribution<int> distribution(min, max);// функция destribition для задания диапозона значений
    int random_number = distribution(generator);
    return random_number;
}

unsigned int x = get_random(1000,2000), y = get_random(1000,2000), z = get_random(1000,2000), w = get_random(1000,2000); // intial parametrs

static unsigned int XORShift() { //128 битная версия
	unsigned int t = x ^ (x << 11);
	x = y; y = z; z = w;                        //присваевание необходимо для изменения сида и повторной генерации
	return w = w ^ (w >> 19) ^ t ^ (t >> 8);    //генерация чисел происходит через возведение в степень сдвинутого по XOR значения 
}

int main(){
    cout << "ГПСЧ XORShift" << endl;
    cout << "Случайное число: " << XORShift() <<endl;
}

//