#include <iostream>
#include <locale.h>
#include <cmath>

using namespace std;

int main()
{
	setlocale(LC_ALL, "");

	int distanceIn = 0;
	double timeIn = 0;
	double timeMin = 0;
	double timeSec = 0;
	double timeSec2 = 0;
	double speed = 0;

	cout << "���������� �������� ����" << endl << "������� ����� ��������� (������) = ";
	cin >> distanceIn;
	cout << "������� ����� (���.���) = ";
	cin >> timeIn;

	timeSec = modf(timeIn, &timeMin);
	timeSec2 = timeMin * 60 + timeSec /0.01;
	speed = distanceIn / timeSec2 * 3.6;

	cout << "���������: " << distanceIn << " �" << endl;
	cout << "�����: " << timeMin << " ��� " << timeSec << " ��� = " << timeSec2 << " ���" << endl;
	cout << "�� ������ �� ��������� " << speed << " ��/�";

	return 0;
}