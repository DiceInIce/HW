#include <iostream>
#include <ctime>

using namespace std;

int* dynamMem(int size) {
	return new int[size];
}

void initArr(int* arr, int size) {
	for (int i = 0; i < size; i++) arr[i] = rand() % 100;
}

void printArr(int* arr,int size) {
	for (int i = 0; i < size; i++) cout << arr[i] << "\t";
    cout << endl;
}

void deleteArr(int* arr) {
	delete[] arr;
}

int* resizeArr(int* arr, int& size, int newSize) {
	int* newArr = new int[newSize];
	int minSize = (size < newSize) ? size : newSize;

	for (int i = 0; i < minSize; i++) {
		newArr[i] = arr[i];
	}

	delete[] arr;
	size = newSize;
	return newArr;
}

int* addElArr(int* arr, int& size, int el) {
	arr = resizeArr(arr, size, size + 1);
	arr[size - 1] = el;
	return arr;
}

int* putElArr(int* arr, int& size, int el, int index) {
    if (index < 0 || index > size) return arr;

    arr = resizeArr(arr, size, size + 1);

    for (int i = size - 1; i > index; i--) {
        arr[i] = arr[i - 1];
    }
    arr[index] = el;

    return arr;
}

int* delElArr(int* arr, int& size, int index) {
    if (index < 0 || index >= size) return arr;

    for (int i = index; i < size - 1; i++) {
        arr[i] = arr[i + 1];
    }

    arr = resizeArr(arr, size, size - 1);

    return arr;
}


void main()
{
	setlocale(LC_ALL, "");
	srand(time(0));

    int size = 5;
    int* arr = dynamMem(size);

    initArr(arr, size);
    printArr(arr, size);

    arr = addElArr(arr, size, 42);
    printArr(arr, size);

    arr = putElArr(arr, size, 99, 2);
    printArr(arr, size);

    arr = delElArr(arr, size, 3);
    printArr(arr, size);

    deleteArr(arr);
}