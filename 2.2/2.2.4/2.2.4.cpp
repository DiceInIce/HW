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

	cout << "Вычисление скорости бега" << endl << "Введите длину дистанции (метров) = ";
	cin >> distanceIn;
	cout << "Введите время (мин.сек) = ";
	cin >> timeIn;

	timeSec = modf(timeIn, &timeMin);
	timeSec2 = timeMin * 60 + timeSec /0.01;
	speed = distanceIn / timeSec2 * 3.6;

	cout << "Дистанция: " << distanceIn << " м" << endl;
	cout << "Время: " << timeMin << " мин " << timeSec << " сек = " << timeSec2 << " сек" << endl;
	cout << "Вы бежали со скоростью " << speed << " км/ч";

	return 0;
}