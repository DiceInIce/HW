#include <iostream>
#include <ctime>
#include <cstdlib>

using namespace std;



int main()
{
    setlocale(LC_ALL, "");
	srand(time(0));

	int arr[10]{};
	int arrSize = size(arr);

	int max = arr[0];
	int min = arr[0];

	
	for (int i = 0; i < arrSize; i++) {
		arr[i] = rand() % 100;
	}


	for (int i = 0; i < arrSize; i++) {

		if (arr[i] > max) {
			max = arr[i];
		}

		if (arr[i] < min) {
			min = arr[i];
		}
	}

	cout << "Массив: ";
	for (int i = 0; i < arrSize; i++) {
		cout << arr[i] << "\t";
	}
	cout << "\n Наименьшее число: " << min << "\n Наибольшое число: " << max;

	return 0;
}