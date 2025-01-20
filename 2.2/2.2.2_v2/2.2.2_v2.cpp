#include <iostream>
#include <locale.h>
#include <cmath>

using namespace std;

int main()
{
	setlocale(LC_ALL, "");

	double numIn = 0;
	double numLeft = 0;
	double numRight = 0;

	cout << "Введите дробное число: ";
	cin >> numIn;

	numRight = modf(numIn, &numLeft);
	double numRightOut = numRight / 0.01;

	cout << "У вас " << numLeft << " долларов и " << numRightOut << " центов";

	return 0;
}
