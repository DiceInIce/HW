#include <iostream>
#include <locale.h>

using namespace std;

int main()
{
	setlocale(LC_ALL, "");

	int daysIn = 0;

	cout << "������� ���������� ����: ";
	cin >> daysIn;

	int weeksOut = daysIn / 7;
	int daysOut = daysIn % 7;
	
	cout << "��� " << weeksOut << " ������ � " << daysOut << " ����" << endl;
		
	return 0;
}