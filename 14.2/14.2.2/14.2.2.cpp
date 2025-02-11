#include <iostream>
#include <ctime>

using namespace std;


void initArr(int* arr, int size) {
	for (int i = 0; i < size; i++) arr[i] = rand() % 100;
}

void printArr(int* arr, int size) {
	for (int i = 0; i < size; i++) {
		cout << arr[i] << " ";
	}
	cout << endl;
}

bool isPrime(int num) {
	if (num < 2) return false;
	for (int i = 2; i <= sqrt(num); i++) {
		if (num % i == 0) return false;
	}
	return true;
}

int* removePrimes(int* arr, int& size) {
	int count = 0;

	for (int i = 0; i < size; i++) {
		if (!isPrime(arr[i])) count++;
	}

	if (count == 0) {
		delete[] arr;
		size = 0;
		return nullptr;
	}

	int* resArr = new int[count];
	int index = 0;

	for (int i = 0; i < size; i++) {
		if (!isPrime(arr[i])) {
			resArr[index++] = arr[i];
		}
	}

	delete[] arr;
	size = count;

	return resArr;
}

int main()
{
	setlocale(LC_ALL, "");
	srand(time(0));


	int size = 30;
	int* arr = new int[size];


	initArr(arr, size);
	cout << "Изначальный массив:\n";
	printArr(arr, size);

	cout << "Массив без простых чисел:\n";
	arr = removePrimes(arr, size);
	printArr(arr, size);


	return 0;
}