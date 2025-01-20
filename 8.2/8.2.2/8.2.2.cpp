#include <iostream>
#include <ctime>
#include <cstdlib>

using namespace std;

int randomNumber(int min, int max) {

    int i = rand() % (max - min + 1) + min;

    return i;
}


int main()
{
    setlocale(LC_ALL, "");
    srand(time(0));

    int start = 0;
    int end = 0;

    cout << "Введите диапазон чисел: \nот - ";
    cin >> start;
    cout << "до - ";
    cin >> end;

    const int range = end - start;
    int arr[10]{};
    int arrSize = size(arr);
    int disruptor = 0;
    int resSum = 0;

    for (int i = 0; i < arrSize; i++) {
        arr[i] = randomNumber(start, end);
    }

    cout << "Массив: ";
    for (int n : arr) cout << n << "\n";

    cout << "Укажите число: ";
    cin >> disruptor;

    for (int i = 0; i < arrSize; i++) {
        if (arr[i] < disruptor) resSum += arr[i];
    }

    cout << "\nСумма чисел меньше указанного - " << resSum;

    return 0;
}