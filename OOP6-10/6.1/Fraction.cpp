#include "Fraction.h"

Fraction::Fraction(int num, int denom) : numerator(num), denominator(denom) {
    if (denominator == 0) {
        throw invalid_argument("Знаменатель не может быть равен нулю.");
    }
    if (denominator < 0) {
        numerator = -numerator;
        denominator = -denominator;
    }
    reduce();
}



int Fraction::getNumerator() const {
    return numerator;
}

int Fraction::getDenominator() const {
    return denominator;
}

void Fraction::reduce() {
    int divisor = commonDen(numerator, denominator);
    numerator /= divisor;
    denominator /= divisor;
}

int Fraction::commonDen(int a, int b) {
    return b == 0 ? abs(a) : commonDen(b, a % b);
}

Fraction Fraction::operator+(const Fraction& other) const {
    int num = numerator * other.denominator + other.numerator * denominator;
    int denom = denominator * other.denominator;
    return Fraction(num, denom);
}


Fraction Fraction::operator-(const Fraction& other) const {
    int num = numerator * other.denominator - other.numerator * denominator;
    int denom = denominator * other.denominator;
    return Fraction(num, denom);
}

Fraction Fraction::operator*(const Fraction& other) const {
    int num = numerator * other.numerator;
    int denom = denominator * other.denominator;
    return Fraction(num, denom);
}

Fraction Fraction::operator/(const Fraction& other) const {
    if (other.numerator == 0) {
        throw invalid_argument("Деление на ноль.");
    }
    int num = numerator * other.denominator;
    int denom = denominator * other.numerator;
    return Fraction(num, denom);
}

ostream& operator<<(ostream& out, const Fraction& frac) {
    out << frac.numerator << "/" << frac.denominator;
    return out;
}