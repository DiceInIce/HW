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
	int reverseArr[10]{};

	for (int i = 0; i < 10; i++) {
		arr[i] = rand() % 10;
	}

	int* pointerArr = &arr[0];
	int* pointerRevArr = &reverseArr[0];

	for (int i = 0; i < 10; i++) {
		*(pointerRevArr + i) = *(pointerArr + (9 - i));
	}

	printArr(arr);
	cout << endl;
	printArr(reverseArr);
}