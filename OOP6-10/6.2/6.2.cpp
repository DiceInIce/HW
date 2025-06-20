#include <iostream>
#include "Complex.h"

int main() {
    setlocale(LC_ALL, "");

    Complex a(3, 2);
    Complex b(1, -4);

    cout << "Первое комплексное число: " << a << endl;
    cout << "Второе комплексное число: " << b << endl;
    cout << "Сумма: " << a + b << endl;
    cout << "Разность: " << b - a << endl;
    cout << "Произведение: " << a * b << endl;
    cout << "Деление: " << a / b << endl;

    return 0;
}