#include <iostream>
using namespace std;

class Fraction {
private:

    int numerator;
    int denominator;

public:

    Fraction(int num = 0, int denom = 1);

    int getNumerator() const;
    int getDenominator() const;

    void print();
    void reduce();
    int commonDen(int a, int b); // Наиб. общ. делитель

    Fraction operator+(const Fraction& other) const;
    Fraction operator-(const Fraction& other) const;
    Fraction operator*(const Fraction& other) const;
    Fraction operator/(const Fraction& other) const;

    friend ostream& operator<<(ostream& out, const Fraction& frac);
};

