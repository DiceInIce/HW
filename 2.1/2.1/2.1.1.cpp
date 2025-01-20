#include <iostream>
#include <locale.h>

using namespace std;

int main()
{
	setlocale(LC_ALL, "");

	double R1;
	double R2;
	double R3;
	
	cout << "Введите величины сопротивления:" << endl;
	cout << "R1: "; cin >> R1;
	cout << "R2: "; cin >> R2;
	cout << "R3: "; cin >> R3;
	double R0 = 1 /(1 / R1 + 1 / R2 + 1 / R3);

	cout << "Общее сопротивление цепи: "<< R0 <<  endl;
	
	return 0;
}
