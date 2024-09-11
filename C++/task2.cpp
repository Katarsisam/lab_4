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
    std::cout <<  "Задание 1." << endl;
    std::cout <<  "Массив:";
    int size = 10;
    vector<double> arr(size);
    for (int i = 0; i < size; i++)
    {
        arr[i] = get_fp_random_num(-100,100);
        std::cout <<  arr[i] << ", ";
    }
    std::cout <<  endl;
    return arr;
}

int find_max(const vector <double>& arr){ // function to find index of maxiumum element in array
    int max_index;
    double max = -100.0; 
     for (int i = 0; i < (int)arr.size(); i++)
    {
        if (arr[i] > max)
        {
            max = arr[i];
            max_index = i;
        }
    }
    return max_index;
}

void task2(const vector <double>& arr,int max_index){
    std::cout <<  "Задание 2." << endl;
    double mulminus = 1;
    double sumplus = 0;
    for (int i = 0; i < max_index;i++){
        if (arr[i] < 0){
            mulminus *= arr[i];
        }else{
            sumplus += arr[i]; 
        }
    }
    std::cout << "Произведение отрицательных элементов:" << mulminus  << endl;
    std::cout <<  "Сумма положительных элементов:" << sumplus << endl;
}

// TASK-3 CODE:

char change_case (char c) {
    if (std::isupper(c)) 
        return std::tolower(c); 
    else
        return std::toupper(c); 
}


void task3(std::string str){
    std::cout <<  "Задание 3." << endl;
    std::cout << "Входная строка:" << str << endl;
    std::transform(str.begin(), str.end(), str.begin(), change_case);
    std::cout << "Cтрока c изменёнными регистрами:"<< str << endl;
}

vector<int> generate_random_int_array(int size){
    vector <int> arr(size);
    for (int i = 0; i < size;i++){
        arr[i] = get_int_random_num(-100,100);
    }
    return arr;
}

void task4(const vector <int>& arr){
    std::cout <<  "Задание 4." << endl;
    std::cout << "Входной массив:";
    int count = 0;
    for(int i = 0;i < (int)arr.size(); i++){
        std::cout << arr[i] << ",";
        if(arr[i + 1] > arr[i] && arr[i+1] > arr[i+2]){
            count++;
        }
    }
    std::cout << endl << "Количество элементов, значение которых больше соседей:"<< count << endl;
}

// TASK_5 CODE:

int sum_array(const vector<int> arr){ // returns sum of elements in array
    int sum = 0;
    for (int i = 0;i < (int)arr.size();i++){
        sum += arr[i];
    }
    return sum;
}



void sort(vector<int> arr, int n) { // sorting using bubbleSort algorithm 
    int isUnsorted; 
    do { 
        isUnsorted = 0; 
        for (int i = 0; i < (n - 1); i++) { 
            if (arr[i] > arr[i + 1]) { 
                isUnsorted = 1; 
                for (; i < (n - 1); i++) { 
                    if (arr[i] > arr[i + 1]) { 
                        std::swap(arr[i], arr[i + 1]); 
                    } 
                } 
            } 
        } 
    } while (isUnsorted); 
} 

void task5(){
    // TODO: Finish this code

    cout << "Задание 5." << endl;
    int size = get_int_random_num(0,10); 
    vector <int> arr(size);
    cout << "Исходный массив:";
    for (int i = 0; i < size; i++){
        arr[i] = get_int_random_num(-100,100);
        cout << arr[i] << ", ";
    }
    int sum_1 = sum_array(arr);
    cout << endl << "Сумма элементов исходного массива:" << sum_1 << endl;

    // Здесь должна быть функция замены цифр в числах массива

    sort(arr,size);
    cout << "Отсортированный по возрастанию массив:";
    for (int i = 0; i < size; i++){
        arr[i] = get_int_random_num(-100,100);
        cout << arr[i] << ", ";
    }
    int sum_2 = sum_array(arr);
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
    task2(arr_task_1,find_max(arr_task_1));
    task3("hello");
    task4(generate_random_int_array(get_int_random_num(0,10)));
    task5();
}