#include <iostream>
#include <ctime>

using namespace std;

void printArr(int arr[]) {
	for (int i = 0; i < 10; i++) cout << arr[i] << "\t";
}

void main()
{
	setlocale(LC_ALL, "");
	srand(time(0));

	int arr[10]{};

	for (int i = 0; i < 10; i++) {
		arr[i] = rand() % 10;
	}

	printArr(arr);
	cout << endl;

	int* pointerArr = &arr[0];

	for (int i = 0; i < 5; i++) {
		int temp = *(pointerArr + i);
		*(pointerArr + i) = *(pointerArr + (9 - i));
		*(pointerArr + (9 - i)) = temp;
	}

	printArr(arr);
	cout << endl;
}