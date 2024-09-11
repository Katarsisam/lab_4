#include <iostream>
#include <random>
#include <vector>
#include <algorithm>
using namespace std;

// VARIANT 13

double get_fp_random_num(int min, int max) // get random floating point number
{
    random_device rd;
    mt19937 generator(rd());
    uniform_real_distribution<double> distribution(min, max);// функция destribition для задания диапозона значений
    double random_number = distribution(generator);
    return random_number;
}

int get_int_random_num(int min, int max) // get random integer number
{
    random_device rd;
    mt19937 generator(rd());
    uniform_int_distribution<int> distribution(min, max);// функция destribition для задания диапозона значений
    int random_number = distribution(generator);
    return random_number;
}

vector<double> task1(){
    cout <<  "Задание 1." << endl;
    cout <<  "Массив:";
    int size = 10;
    vector<double> arr(size);
    for (int i = 0; i < size; i++)
    {
        arr[i] = get_fp_random_num(-100,100);
        cout <<  arr[i] << ", ";
    }
    cout <<  endl;
    return arr;
}



void task2(const vector <double>& arr){
   cout <<  "Задание 2." << endl;
    double mulminus = 1;
    double sumplus = 0;
    for (int i = 0; i < (int)arr.size();i++){
        if (arr[i] < 0){
            mulminus *= arr[i];
        }else{
            sumplus += arr[i]; 
        }
    }
    cout << "Произведение отрицательных элементов:" << mulminus  << endl;
    cout <<  "Сумма положительных элементов:" << sumplus << endl;
}

// TASK-3 CODE:

char change_case (char c) {
    if (isupper(c)) 
        return tolower(c); 
    else
        return toupper(c); 
}


void task3(string str){
    cout <<  "Задание 3." << endl;
    cout << "Входная строка:" << str << endl;
    transform(str.begin(), str.end(), str.begin(), change_case);
    cout << "Cтрока c изменёнными регистрами:"<< str << endl;
}

vector<int> generate_random_int_array(int size){
    vector <int> arr(size);
    for (int i = 0; i < size;i++){
        arr[i] = get_int_random_num(-100,100);
    }
    return arr;
}

void task4(const vector <int>& arr){
    cout <<  "Задание 4." << endl;
    cout << "Входной массив:";
    int count = 0;
    for(int i = 0;i < (int)arr.size(); i++){
        cout << arr[i] << ",";
        if(arr[i + 1] > arr[i] && arr[i+1] > arr[i+2]){
            count++;
        }
    }
    cout << endl << "Количество элементов, значение которых больше соседей:"<< count << endl;
}

// TASK_5 CODE:

void task5(){
    
    random_device rd; 
    auto rng = default_random_engine { rd() };
    int n = 0;
    cout << "Задание 5." << endl << "Введите предел n ";
    do {
        scanf("%d",&n);
        if(n<10)
            cout << "n<10, введите другой предел ";
    }while (n <10);

    int size = get_int_random_num(10,n); 
    vector <int> arr = generate_random_int_array(size);
    cout << "Исходный массив: ";
    for (int i : arr){
        cout << i << ", ";
    }
    int sum_1 = accumulate(arr.begin(),arr.end(),0);
    cout << endl << "Сумма элементов исходного массива:" << sum_1 << endl;

    cout << "Перетасованный массив: ";
    shuffle(begin(arr), end(arr), rng);
    for (int i : arr){
        cout << i << ", ";
    }
    cout <<endl<< "Отсортированный по возрастанию массив: ";
    sort(arr.begin(),arr.end());
    for (int i : arr){
        cout << i << ", ";
    }
    cout <<endl<< "Новый массив: ";
    arr = generate_random_int_array(size);
    for (int i : arr){
        cout << i << ", ";
    }
    int sum_2 = accumulate(arr.begin(),arr.end(),0);
    cout << endl << "Сумма элементов полученного массива:" << sum_2 << endl;

    if (sum_2 > sum_1)
    {
        cout << sum_2 << ">" << sum_1 << endl;
    }else if (sum_2 < sum_1)
    {
        cout << sum_2 << "<" << sum_1 << endl;
    }else if (sum_2 == sum_1)
    {
        cout << sum_2 << "=" << sum_1 << endl;
    }
    
    
    



}

int main(){
 
    vector<double> arr_task_1 = task1();
    task2(arr_task_1);
    task3("hello");
    task4(generate_random_int_array(10));
    task5();
}