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

	int firstArr[10]{};
	int copyArr[10]{};

	for (int i = 0; i < 10; i++) {
		firstArr[i] = rand() % 10;
	}

	int* ptrFirstArr = &firstArr[0];
	int* ptrCopyArr = &copyArr[0];

	for (int i = 0; i < 10; i++) {
		*(ptrCopyArr + i) = *(firstArr + i);
	}

	printArr(firstArr);
	cout << endl;
	printArr(copyArr);
}
