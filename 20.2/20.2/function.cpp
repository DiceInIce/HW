#include "function.hpp"
#include <iostream>

using namespace std;

// Функции для работы с целыми числами
void FillArrayInt(int* arr, int size) {
    srand(time_t(0));
    for (int i = 0; i < size; i++) {
        arr[i] = rand() % 100;
    }
}

void ShowArrayInt(int* arr, int size) {
    for (int i = 0; i < size; i++) {
        cout << arr[i] << " ";
    }
    cout << endl;
}

int MinElementInt(int* arr, int size) {
    int min = arr[0];
    for (int i = 1; i < size; i++) {
        if (arr[i] < min) min = arr[i];
    }
    return min;
}

int MaxElementInt(int* arr, int size) {
    int max = arr[0];
    for (int i = 1; i < size; i++) {
        if (arr[i] > max) max = arr[i];
    }
    return max;
}

void SortArrayInt(int* arr, int size) {
    for (int i = 0; i < size - 1; i++) {
        for (int j = 0; j < size - i - 1; j++) {
            if (arr[j] > arr[j + 1]) swap(arr[j], arr[j + 1]);
        }
    }
}

void EditArrayInt(int* arr, int index, int value, int size) {
    if (index >= 0 && index < size) {
        arr[index] = value;
    }
}

// Функции для работы с символами
void FillArrayChar(char* arr, int size) {
    srand(time(0));
    for (int i = 0; i < size; i++) {
        arr[i] = 'A' + rand() % 26;
    }
}

void ShowArrayChar(char* arr, int size) {
    for (int i = 0; i < size; i++) {
        cout << arr[i] << " ";
    }
    cout << endl;
}

char MinElementChar(char* arr, int size) {
    char min = arr[0];
    for (int i = 1; i < size; i++) {
        if (arr[i] < min) min = arr[i];
    }
    return min;
}

char MaxElementChar(char* arr, int size) {
    char max = arr[0];
    for (int i = 1; i < size; i++) {
        if (arr[i] > max) max = arr[i];
    }
    return max;
}

void SortArrayChar(char* arr, int size) {
    for (int i = 0; i < size - 1; i++) {
        for (int j = 0; j < size - i - 1; j++) {
            if (arr[j] > arr[j + 1]) swap(arr[j], arr[j + 1]);
        }
    }
}

void EditArrayChar(char* arr, int index, char value, int size) {
    if (index >= 0 && index < size) {
        arr[index] = value;
    }
}

// Функции для работы с действительными числами
void FillArrayDouble(double* arr, int size) {
    srand(time(0));
    for (int i = 0; i < size; i++) {
        arr[i] = (rand() % 10000) / 100.0;
    }
}

void ShowArrayDouble(double* arr, int size) {
    for (int i = 0; i < size; i++) {
        cout << arr[i] << " ";
    }
    cout << endl;
}

double MinElementDouble(double* arr, int size) {
    double min = arr[0];
    for (int i = 1; i < size; i++) {
        if (arr[i] < min) min = arr[i];
    }
    return min;
}

double MaxElementDouble(double* arr, int size) {
    double max = arr[0];
    for (int i = 1; i < size; i++) {
        if (arr[i] > max) max = arr[i];
    }
    return max;
}

void SortArrayDouble(double* arr, int size) {
    for (int i = 0; i < size - 1; i++) {
        for (int j = 0; j < size - i - 1; j++) {
            if (arr[j] > arr[j + 1]) swap(arr[j], arr[j + 1]);
        }
    }
}

void EditArrayDouble(double* arr, int index, double value, int size) {
    if (index >= 0 && index < size) {
        arr[index] = value;
    }
}
