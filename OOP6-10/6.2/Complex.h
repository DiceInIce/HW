#include <iostream>

using namespace std;

class Complex {
private:
    double real;
    double imag;

public:
    
    Complex(double r = 0.0, double i = 0.0);

    
    double getReal() const;
    double getImag() const;

    Complex operator+(const Complex& other) const;
    Complex operator-(const Complex& other) const;
    Complex operator*(const Complex& other) const;
    Complex operator/(const Complex& other) const;

    friend ostream& operator<<(ostream& out, const Complex& c);
    friend istream& operator>>(istream& in, Complex& c);
};
