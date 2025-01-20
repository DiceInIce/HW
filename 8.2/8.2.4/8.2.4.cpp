#include <iostream>

using namespace std;



int main()
{
    setlocale(LC_ALL, "");


    const int MAX_SIZE = 100;
    double arr[MAX_SIZE]{};
    int n;

    cout << "Введите размер массива (не более " << MAX_SIZE << "): ";
    cin >> n;

    if (n <= 0 || n > MAX_SIZE) {
        cout << "Некорректный размер массива.\n";
        return 1;
    }

    cout << "Введите элементы массива:\n";
    for (int i = 0; i < n; i++) {
        cin >> arr[i];
    }

    double sumNegative = 0.0;                   
    double prodBetweenMinMax = 1.0;             
    double prodEven = 1.0;               
    double sumBetweenFirstLastNegative = 0.0;   

    int minIndex = 0, maxIndex = 0;             
    int firstNegative = -1, lastNegative = -1;  

    double minElement = arr[0];
    double maxElement = arr[0];

    for (int i = 0; i < n; i++) {
        // Сумма отрицательных
        if (arr[i] < 0) {
            sumNegative += arr[i];
            if (firstNegative == -1) firstNegative = i;
            lastNegative = i;
        }

        // Минимальный элемент
        if (arr[i] < minElement) {
            minElement = arr[i];
            minIndex = i;
        }

        // Максимальный элемент
        if (arr[i] > maxElement) {
            maxElement = arr[i];
            maxIndex = i;
        }

        // Произведение элементов с четными индексами
        if (i % 2 == 0) {
            prodEven *= arr[i];
        }
    }

    // Вычисление произведения между min и max
    if (minIndex > maxIndex) swap(minIndex, maxIndex);
    for (int i = minIndex + 1; i < maxIndex; i++) {
        prodBetweenMinMax *= arr[i];
    }

    // Вычисление суммы между первым и последним отрицательными
    if (firstNegative != -1 && lastNegative != -1 && firstNegative != lastNegative) {
        for (int i = firstNegative + 1; i < lastNegative; i++) {
            sumBetweenFirstLastNegative += arr[i];
        }
    }

    cout << "\nСумма отрицательных элементов: " << sumNegative;
    cout << "\nПроизведение элементов между min и max элементами: " << prodBetweenMinMax;
    cout << "\nПроизведение элементов с четными номерами: " << prodEven;

    if (firstNegative != -1 && lastNegative != -1 && firstNegative != lastNegative) {
        cout << "\nСумма элементов между первым и последним отрицательными элементами: " << sumBetweenFirstLastNegative;
    }
    else {
        cout << "\nМежду первым и последним отрицательными элементами нет элементов.\n\n";
    }

    return 0;
}


