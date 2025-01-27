#include <iostream>
#include <math.h>
#include <iomanip>

using namespace std;


double logbase(double a, double base) {
	return log(a) / log(base);
}

int sumBetween(int a, int b) {
	int res = 0;
	for (int i = a; i < b - 1; --b) {
		res += b - 1;
	}
	return res;
}

int exelentNum(int a, int b) {
	for (a + 1; a < b; a++) {
		int sum = 0;
		for (int j = 1; j < a; j++)
			if (a % j == 0) sum += j;
		if (a == sum) cout << a << " ";
		continue;
	}
	return 0;
}

bool luckyNum(int a) {
	bool res;
	int left, right;
	int firstHalf = a / 1000;
	int secHalf = a % 1000;

	int sumFirst = 0, sumSec = 0;
	while (firstHalf > 0) {
		sumFirst += firstHalf % 10;
		firstHalf /= 10;
	}
	while (secHalf > 0) {
		sumSec += secHalf % 10;
		secHalf /= 10;
	}

	sumFirst == sumSec ? res = true : res = false;
	return res;
}

void printCard(int suit, int num) {
	char card[13] = { 'A','2','3','4','5','6','7','8','9','0','J','Q','K' };
	cout << " ___________________\n";
	cout << "|                   |\n";
	cout << "|                   |\n";
	if (num == 10)cout << '|' << setw(4) << "1" << card[num - 1] << "              |\n";
	else cout << '|' << setw(4) << card[num - 1] << "               |\n";
	cout << "|                   |\n";
	cout << "|                   |\n";
	cout << "|                   |\n";
	cout << "|                   |\n";
	cout << "|                   |\n";
	switch (suit)
	{
	case 1: cout << '|' << setw(12) << "ЧЕРВИ" << "       |\n"; break;
	case 2: cout << '|' << setw(12) << "БУБНЫ" << "       |\n"; break;
	case 3: cout << '|' << setw(12) << "ТРЕФЫ" << "       |\n"; break;
	case 4: cout << '|' << setw(12) << "ПИКИ" << "       |\n"; break;
	}
	cout << "|                   |\n";
	cout << "|                   |\n";
	cout << "|                   |\n";
	cout << "|                   |\n";
	if (num == 10)cout << "|              " << "1" << card[num - 1] << "   |\n";
	else cout << "|               " << card[num - 1] << "   |\n";
	cout << "|                   |\n";
	cout << "|___________________|\n";
}


int main()
{
	setlocale(LC_ALL, "");

	int a = 0;
	int base = 0;

	int b = 0;
	int c = 0;

	int num = 0; 
	int suit = 0;

	int lucky = 0;

	cout << "Введите показатель степени: ";
	cin >> a;
	cout << "Введите основание степени: ";
	cin >> base;
	cout << endl;
	cout << "Степень числа: " << logbase(a, base) << endl << endl;


	cout << "Введите первое число диапазона: ";
	cin >> b;
	cout << "Введите второе число диапазона: ";
	cin >> c;
	cout << "\nСумма чисел в заданном диапазоне: " << sumBetween(b, c) << endl;
	cout << "Совершенные числа в заданном диапазоне: ";
	exelentNum(b, c);
	cout << endl;

	cout << "Введите карту\n1 - Туз\n2 - Двойка\n3 - Тройка\n4 - Четверка\n5 - Пятерка\n6 - Шестерка\n7 - Семерка\n8 - Восьмерка\n9 - Девятка\n10 - Десятка\n11 - Валет\n12 - Королева\n13 - Король" << endl;
	cout << "Введите номинал: ";
	cin >> num;
	cout << "\n\t\t\tМасть\n1. Червы.\n2. Бубны\n3. Трефы\n4. Пики\n";
	cout << "Введите масть: ";
	cin >> suit;
	printCard(suit, num);
	cout << endl << endl;

	cout << "Введите 6-ти значное число для проверки на счастливое: ";
	cin >> lucky;
	luckyNum(lucky) ? cout << "\nСчастливое" : cout << "\nНе счастливое" << endl;

	return 0;
}
