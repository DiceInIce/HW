#include <iostream>
#include <locale.h>

using namespace std;

int main()
{
	setlocale(LC_ALL, "");

	int tSecIn = 0;

	cout << "������� ����� � ��������: ";
	cin >> tSecIn;
	int tMin = tSecIn / 60;
	int tHourOut = tMin / 60;
	int tMinOut = tMin % 60;
	int tSecOut = tSecIn % 60;

	cout << "���� �����: " << tHourOut << ":" << tMinOut << ":" << tSecOut;

	return 0;
}