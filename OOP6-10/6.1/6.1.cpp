#include <iostream>
#include "Fraction.h"

int main() {
    setlocale(LC_ALL, "");

    Fraction a(1, 2);
    Fraction b(3, 4);


    cout << "Первая дробь: " << a << endl;
    cout << "Вторая дробь: " << b << endl;
    cout << "Сумма: " << a + b << endl;
    cout << "Разность: " << b - a << endl;
    cout << "Произведение: " << a * b << endl;
    cout << "Деление: " << a / b << endl;

    return 0;
}