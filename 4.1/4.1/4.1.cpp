#include <iostream>
#include <cmath>

using namespace std;

int main()
{
    setlocale(LC_ALL, "");

    double num = 0;
    double leftPart = 0;
    double rightPart = 0;
    int sum1 = 0;
    int sum2 = 0;
    int counter = 100;

    cout << "Введите 6-ти значное число: ";
    cin >> num;

    if (99999 < num && num < 1000000) {
        double modNum = num / 1000;

        rightPart = modf(modNum, &leftPart);
        rightPart += 0.00001;
        int rightPartMod = rightPart * 1000;
        int leftPartMod = leftPart;

        for (int i = 0; i <= 2; i++) {
            sum1 += leftPartMod / counter;
            sum2 += rightPartMod / counter;
            leftPartMod -= leftPartMod / counter * counter;
            rightPartMod -= rightPartMod / counter * counter;
            counter /= 10;
        }

        if (sum1 == sum2) {
            cout << "Число счастливое";
        }
        else {
            cout << "Число не счастливое";
        }
    }
    else {
        cout << "Введено не 6-ти значное число";
    }
    return 0;
}