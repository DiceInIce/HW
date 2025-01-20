#include <iostream>
#include <locale.h>
#define _USE_MATH_DEFINES
#include <math.h>

using namespace std;

int main()
{
	setlocale(LC_ALL, "");

	int L;
	double Pi = M_PI;

	cout << "Введите длину окружности: "; cin >> L; 
	
	double S = Pi * pow(L / (2 * Pi), 2);
	
	cout << "Площадь окружности: " << S << endl;

	return 0;
}