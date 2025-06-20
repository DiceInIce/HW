#include "Complex.h"
#include <stdexcept>
#include <cmath>

Complex::Complex(double r, double i) : real(r), imag(i) {}

double Complex::getReal() const {
    return real;
}

double Complex::getImag() const {
    return imag;
}

Complex Complex::operator+(const Complex& other) const {
    return Complex(real + other.real, imag + other.imag);
}

Complex Complex::operator-(const Complex& other) const {
    return Complex(real - other.real, imag - other.imag);
}

Complex Complex::operator*(const Complex& other) const {
    return Complex(
        real * other.real - imag * other.imag,
        real * other.imag + imag * other.real
    );
}

Complex Complex::operator/(const Complex& other) const {
    double denominator = other.real * other.real + other.imag * other.imag;
    if (denominator == 0.0) {
        throw invalid_argument("ƒеление на ноль.");
    }
    return Complex(
        (real * other.real + imag * other.imag) / denominator,
        (imag * other.real - real * other.imag) / denominator
    );
}

ostream& operator<<(ostream& out, const Complex& c) {
    out << c.real;
    if (c.imag >= 0) out << "+";
    out << c.imag << "i";
    return out;
}

istream& operator>>(istream& in, Complex& c) {
    cout << "¬ведите действительную часть: ";
    in >> c.real;
    cout << "¬ведите мнимую часть: ";
    in >> c.imag;
    return in;
}