#include <iostream>
#include <locale.h>

using namespace std;

int main()
{
	setlocale(LC_ALL, "");

	int daysIn = 0;

	cout << "¬ведите количество дней: ";
	cin >> daysIn;

	int weeksOut = daysIn / 7;
	int daysOut = daysIn % 7;
	
	cout << "Ёто " << weeksOut << " недель и " << daysOut << " дней" << endl;
		
	return 0;
}