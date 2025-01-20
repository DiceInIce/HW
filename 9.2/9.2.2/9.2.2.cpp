#include <iostream>

using namespace std;

void bubbleSort(int arr[], int n) {
    for (int i = 0; i < n - 1; i++) {

        int counter = 0;

        for (int j = 0; j < n - i - 1; j++) {
            if (arr[j] > arr[j + 1]) {
                swap(arr[j], arr[j + 1]);
                counter ++;
            }

        }

        if (counter == 0) {
            cout << "\nОстановка" << endl;
            break;
        }
    }
}

void main()
{
    setlocale(LC_ALL, "");

    int arr[5]{ };

    cout << "Введите 5 элементов массива:\n";
    cin >> arr[0] >> arr[1] >> arr[2] >> arr[3] >> arr[4];

    bubbleSort(arr, 5);

    cout << endl << endl;

    for (int n : arr) {
        cout << n << endl;
    }
}