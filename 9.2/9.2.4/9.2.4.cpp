#include <iostream>

using namespace std;

void generateRandomArray(int arr[], int n) {
    for (int i = 0; i < n; i++) {
        arr[i] = rand() % 10000;
    }
}

// Улучшенная пузырьковая сортировка
int bubbleSort(int arr[], int n) {
    int swaps = 0;
    bool swapped;
    for (int i = 0; i < n - 1; i++) {
        swapped = false;
        for (int j = 0; j < n - 1 - i; j++) {
            if (arr[j] > arr[j + 1]) {
                swap(arr[j], arr[j + 1]);
                swapped = true;
                swaps++;
            }
        }
        if (!swapped) break;
    }
    return swaps;
}

// Сортировка методом выбора
int selectionSort(int arr[], int n) {
    int swaps = 0;
    for (int i = 0; i < n - 1; i++) {
        int minIdx = i;
        for (int j = i + 1; j < n; j++) {
            if (arr[j] < arr[minIdx]) {
                minIdx = j;
            }
        }
        if (minIdx != i) {
            swap(arr[i], arr[minIdx]);
            swaps++;
        }
    }
    return swaps;
}

int main()
{
    setlocale(LC_ALL, "");

    srand(time(0)); 

    const int n = 1000;  // Размер массива
    const int numTests = 10;  // Количество тестов
    int totalBubbleSwaps = 0, totalSelectionSwaps = 0;

    for (int i = 0; i < numTests; i++) {
        // Генерация случайного массива
        int arrBubble[n], arrSelection[n];
        generateRandomArray(arrBubble, n);
        generateRandomArray(arrSelection, n);

        // Подсчет количества перестановок для пузырьковой сортировки
        int bubbleSwaps = bubbleSort(arrBubble, n);
        totalBubbleSwaps += bubbleSwaps;

        // Подсчет количества перестановок для сортировки методом выбора
        int selectionSwaps = selectionSort(arrSelection, n);
        totalSelectionSwaps += selectionSwaps;
    }

    // Вычисление среднего числа перестановок
    double avgBubbleSwaps = totalBubbleSwaps / numTests;
    double avgSelectionSwaps = totalSelectionSwaps / numTests;

    // Вывод
    cout << "Среднее количество перестановок при сортировке пузырьком: " << avgBubbleSwaps << endl;
    cout << "Среднее количество перестановок при сортировке методом выбора: " << avgSelectionSwaps << endl;

    return 0;

}