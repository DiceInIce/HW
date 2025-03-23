#define CHAR
#include "function.hpp"
#include <iostream>

using namespace std;

int main() {
    setlocale(LC_ALL, "");

    const int size = 10;
    char arr[size];

    FillArray(arr, size);

    cout << "Массив: ";
    ShowArray(arr, size);

    cout << "Минимальный элемент: " << MinElement(arr, size) << endl;

    cout << "Максимальный элемент: " << MaxElement(arr, size) << endl;

    SortArray(arr, size);
    cout << "Отсортированный массив: ";
    ShowArray(arr, size);

    int index;
    char value;
    cout << "Введите индекс и новое значение: ";
    cin >> index >> value;
    EditArray(arr, index, value, size);
    cout << "Массив после редактирования: ";
    ShowArray(arr, size);

    return 0;
}