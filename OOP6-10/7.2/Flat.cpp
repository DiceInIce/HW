#include "Flat.h"

Flat::Flat(double a, double p) : area(a), price(p) {}

double Flat::getArea() const {
    return area;
}

double Flat::getPrice() const {
    return price;
}

void Flat::setArea(double a) {
    area = a;
}

void Flat::setPrice(double p) {
    price = p;
}

bool Flat::operator==(const Flat& other) const {
    return area == other.area;
}

Flat& Flat::operator=(const Flat& other) {
    if (this != &other) {
        area = other.area;
        price = other.price;
    }
    return *this;
}

bool Flat::operator>(const Flat& other) const {
    return price > other.price;
}

ostream& operator<<(ostream& out, const Flat& f) {
    out << "Площадь: " << f.area << " м², Цена: " << f.price << " руб.";
    return out;
}