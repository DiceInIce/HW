#include <iostream>


using namespace std;

int main()
{
    setlocale(LC_ALL, "");

    int num = 0;
    int res = 0;

    cout << "Введите 4-ех значное число: ";
    cin >> num;

    if (10000 > num && num > 999) {
        int a = num / 1000 * 100;
        num -= num / 1000 * 1000;

        int b = num / 100 * 1000;
        num -= num / 100 * 100;

        int c = num / 10;

        int d = (num % 10) * 10;

        res = a + b + c + d;
        cout << res;
    }
    else { 
        cout << "Введено не 4-ех значное число"; 
    }
}
