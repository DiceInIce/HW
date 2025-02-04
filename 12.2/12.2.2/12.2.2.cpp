#include <iostream>

using namespace std;

int findCommonDivider(int a, int b, int &min) {
	if (a % min == 0 && b % min == 0) return min;
	else {
		min--;
		findCommonDivider(a, b, min);
	}
}



void main()
{
	setlocale(LC_ALL, "");

	int a, b;
	int min;

	cout << "Введите два числа:" << endl;
	cin >> a >> b;


	a > b ? min = b : min = a;

	cout << "Наибольший общий делитель: " << findCommonDivider(a, b, min);

}
