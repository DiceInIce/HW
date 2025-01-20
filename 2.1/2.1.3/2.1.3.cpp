#include <iostream>
#include <locale.h>

using namespace std;

int main()
{
	setlocale(LC_ALL, "");

	int v, t, a;
	
	cout << "Введите скорость: "; cin >> v;
	cout << "Введите время: "; cin >> t;
	cout << "Введите ускорение: "; cin >> a;

	double S = v * t + (a * pow(t, 2)) / 2;

	cout << "Пройденное расстояние: " <<  S  << endl;

	return 0;
}