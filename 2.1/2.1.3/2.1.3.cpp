#include <iostream>
#include <locale.h>

using namespace std;

int main()
{
	setlocale(LC_ALL, "");

	int v, t, a;
	
	cout << "������� ��������: "; cin >> v;
	cout << "������� �����: "; cin >> t;
	cout << "������� ���������: "; cin >> a;

	double S = v * t + (a * pow(t, 2)) / 2;

	cout << "���������� ����������: " <<  S  << endl;

	return 0;
}