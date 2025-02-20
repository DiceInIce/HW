#include <iostream>

using namespace std;

struct complexNum 
{
    double a;
    double b;

    complexNum(double real, double mnim) : 
        a(real), 
        b(mnim) {
    }

    void print() const {
        cout << a << " + " << b << "i" << endl;
    }

    complexNum operator+(const complexNum& other) {
        return complexNum { a + other.a, b + other.b };
    }
    complexNum operator-(const complexNum& other) {
        return complexNum{ a - other.a, b - other.b };
    }
    complexNum operator*(const complexNum& other) {
        return complexNum(
            a * other.a - b * other.b,  // действительная часть
            a * other.b + b * other.a   // мнимая часть
        );
    }
    complexNum operator/(const complexNum& other) {
        double denominator = other.a * other.a + other.b * other.b;
        if (denominator == 0) {
            throw ("Деление на ноль недопустимо");
        }
        return complexNum(
            (a * other.a + b * other.b) / denominator,  // действительная часть
            (b * other.a - a * other.b) / denominator   // мнимая часть
        );
    }
};




int main()
{
    setlocale(LC_ALL, "");

    complexNum num1(4, 3);
    complexNum num2(2, -1);

    complexNum sum = num1 + num2;
    complexNum sub = num1 - num2;
    complexNum mult = num1 * num2;
    complexNum div = num1 / num2;

    cout << "Сумма: "; sum.print();
    cout << "Разность: "; sub.print();
    cout << "Произведение: "; mult.print();
    cout << "Частное: "; div.print();

    return 0;
}