#include "Overcoat.h"

Overcoat::Overcoat(const string& t, double p) : type(t), price(p) {}

string Overcoat::getType() const {
    return type;
}

double Overcoat::getPrice() const {
    return price;
}

void Overcoat::setType(const string& t) {
    type = t;
}

void Overcoat::setPrice(double p) {
    price = p;
}

bool Overcoat::operator==(const Overcoat& other) const {
    return type == other.type;
}

Overcoat& Overcoat::operator=(const Overcoat& other) {
    if (this != &other) {
        type = other.type;
        price = other.price;
    }
    return *this;
}

bool Overcoat::operator>(const Overcoat& other) const {
    if (type != other.type) {
        cout << "Нельзя сравнить цену: типы одежды разные." << endl;
        return false;
    }
    return price > other.price;
}

ostream& operator<<(ostream& out, const Overcoat& o) {
    out << "Тип: " << o.type << ", Цена: " << o.price;
    return out;
}