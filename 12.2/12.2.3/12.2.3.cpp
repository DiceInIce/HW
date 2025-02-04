#include <iostream>
#include <ctime>

using namespace std;

void intToArr(int number, int arr[4]) {
	for (int i = 3; i >= 0; i--) {
		arr[i] = number % 10;
		number /= 10;
	}
}

bool guessingNum(int randomNum[], int& counter) {
	int num;
	int numArr[4]{};

	int correctNum[]{ 0, 0, 0, 0 };
	int correctPlaceSum = 0;
	int correctNumSum = 0;


	cout << "Введите догадку: ";
	cin >> num;

	intToArr(num, numArr);

	for (int i = 0; i < 4; i++) {
		if (numArr[i] == randomNum[i]) correctPlaceSum++;

		for (int j = 0; j < 4; j++) {
			if (numArr[j] == randomNum[i]) correctNum[i] = 1;
		}
	}

	for (int i = 0; i < 4; i++) {
		correctNumSum += correctNum[i];
	}

	counter++;

	if (correctPlaceSum == 4) return true;
	else {
		cout << "Правильный цифр: " << correctNumSum << endl;
		cout << "Цифр на своих местах: " << correctPlaceSum << endl << endl;

		guessingNum(randomNum, counter);
	}

}


void main()
{
	setlocale(LC_ALL, "");
	srand(time(0));

	int randomNum[4]{};
	int counter = 0;

	for (int i = 0; i < 4; i++) {
		randomNum[i] = rand() % 10;
	}

	cout << "Компьютер загадал четырехзначное число" << endl;

	guessingNum(randomNum, counter);


	cout << "\nЗагаданное число - " << randomNum[0] << randomNum[1] << randomNum[2] << randomNum[3] << endl;
	cout << "Понадобилось " << counter << " попыток";

}
