#include <iostream>
#include <numeric> 

using namespace std;

class Fraction {
private:
    int numerator;
    int denominator;

    void reduce() {
        int gcd = std::gcd(numerator, denominator);
        numerator /= gcd;
        denominator /= gcd;

        if (denominator < 0) {
            numerator = -numerator;
            denominator = -denominator;
        }
    }

public:
    Fraction(int num = 0, int denom = 1) {
        if (denom == 0) {
            throw invalid_argument("Знаменатель не может быть 0");
        }
        numerator = num;
        denominator = denom;
        reduce();
    }

    void input() {
        cout << "Введите чеслитель : ";
        cin >> numerator;
        cout << "Введите знаменатель : ";
        cin >> denominator;
        if (denominator == 0) {
            throw invalid_argument("Знаменатель не может быть 0");
        }
        reduce();
    }

    void display() const {
        cout << numerator << "/" << denominator << endl;
    }

    Fraction operator+(const Fraction& other) const {
        int num = numerator * other.denominator + other.numerator * denominator;
        int denom = denominator * other.denominator;
        return Fraction(num, denom);
    }

    Fraction operator-(const Fraction& other) const {
        int num = numerator * other.denominator - other.numerator * denominator;
        int denom = denominator * other.denominator;
        return Fraction(num, denom);
    }

    Fraction operator*(const Fraction& other) const {
        int num = numerator * other.numerator;
        int denom = denominator * other.denominator;
        return Fraction(num, denom);
    }

    Fraction operator/(const Fraction& other) const {
        if (other.numerator == 0) {
            throw invalid_argument("Деление на ноль");
        }
        int num = numerator * other.denominator;
        int denom = denominator * other.numerator;
        return Fraction(num, denom);
    }
};


int main() {
    setlocale(LC_ALL, "");

    Fraction a, b;

    cout << "Введите первую дробь:" << endl;
    a.input();

    cout << "Введите вторую дробь:" << endl;
    b.input();

    Fraction sum = a + b;
    Fraction difference = a - b;
    Fraction product = a * b;
    Fraction quotient = a / b;

    cout << "\nСумма: ";
    sum.display();

    cout << "Разность: ";
    difference.display();

    cout << "Product: ";
    product.display();

    cout << "Quotient: ";
    quotient.display();

    return 0;
}