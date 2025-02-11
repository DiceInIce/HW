#include <iostream>

using namespace std;

void initArr(int* arr, int size) {
    for (int i = 0; i < size; i++) arr[i] = rand() % 200 - 100;
}

void printArr(int* arr, int size) {
    for (int i = 0; i < size; i++) {
        cout << arr[i] << " ";
    }
    cout << endl;
}

void separateElements(int* arr, int size,
    int*& positives, int& posSize,
    int*& negatives, int& negSize,
    int*& zeros, int& zeroSize) {

    posSize = negSize = zeroSize = 0;
    for (int i = 0; i < size; i++) {
        if (arr[i] > 0) posSize++;
        else if (arr[i] < 0) negSize++;
        else zeroSize++;
    }


    positives = (posSize > 0) ? new int[posSize] : nullptr;
    negatives = (negSize > 0) ? new int[negSize] : nullptr;
    zeros = (zeroSize > 0) ? new int[zeroSize] : nullptr;


    int p = 0, n = 0, z = 0;
    for (int i = 0; i < size; i++) {
        if (arr[i] > 0) positives[p++] = arr[i];
        else if (arr[i] < 0) negatives[n++] = arr[i];
        else zeros[z++] = arr[i];
    }
}

int main() {
    setlocale(LC_ALL, "");

    const int size = 100;
    int arr[size] = {};

    initArr(arr, size);
    cout << "Изначальный массив:\n";
    printArr(arr, size);

    int* positives, posSize;
    int* negatives, negSize;
    int* zeros, zeroSize;

    separateElements(arr, size, positives, posSize, negatives, negSize, zeros, zeroSize);

    cout << "Положительные: ";
    printArr(positives, posSize);
    cout << "Отрицательные: ";
    printArr(negatives, negSize);
    cout << "Нули: ";
    printArr( zeros, zeroSize);


    delete[] positives;
    delete[] negatives;
    delete[] zeros;

    return 0;
}

