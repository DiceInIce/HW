#include <iostream>
#include <locale.h>

using namespace std;

int main()
{
	setlocale(LC_ALL, "");

	double numIn = 0;

	cout << "Введите дробное число: ";
	cin >> numIn;

	int numLeft1 = numIn;
	double numRight = numIn - numLeft1;
	int numRightOut = numRight / 0.01;
	
	cout << "У вас " << numLeft1 << " долларов и " << numRightOut << " центов";

	return 0;
}