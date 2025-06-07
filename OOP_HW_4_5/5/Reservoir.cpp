#include "Reservoir.h"
#include <iostream>
using namespace std;

Reservoir::Reservoir()
    : name("Без названия"), type("Неизвестно"), length(0), width(0), maxDepth(0) {
}

Reservoir::Reservoir(const string& name, const string& type,
    double length, double width, double maxDepth)
    : name(name), type(type), length(length), width(width), maxDepth(maxDepth) {
}

Reservoir::Reservoir(const Reservoir& other)
    : name(other.name), type(other.type), length(other.length), width(other.width), maxDepth(other.maxDepth) {
}

Reservoir& Reservoir::operator=(const Reservoir& other) {
    if (this != &other) {
        name = other.name;
        type = other.type;
        length = other.length;
        width = other.width;
        maxDepth = other.maxDepth;
    }
    return *this;
}

double Reservoir::getVolume() const {
    return length * width * maxDepth;
}

double Reservoir::getSurfaceArea() const {
    return length * width;
}

bool Reservoir::isSameType(const Reservoir& other) const {
    return type == other.type;
}

int Reservoir::compareArea(const Reservoir& other) const {
    if (!isSameType(other)) return -2; // разные типы
    double area1 = getSurfaceArea();
    double area2 = other.getSurfaceArea();
    if (area1 == area2) return 0;
    return (area1 > area2) ? 1 : -1;
}

void Reservoir::display() const {
    cout << "Название: " << name << "\nТип: " << type
        << "\nДлина: " << length << " м\nШирина: " << width
        << " м\nГлубина: " << maxDepth << " м\nОбъем: " << getVolume()
        << " м3\nПлощадь: " << getSurfaceArea() << " м2\n" << endl;
}

void Reservoir::setName(const string& n) { name = n; }
void Reservoir::setType(const string& t) { type = t; }
void Reservoir::setLength(double l) { length = l; }
void Reservoir::setWidth(double w) { width = w; }
void Reservoir::setDepth(double d) { maxDepth = d; }

string Reservoir::getName() const { return name; }
string Reservoir::getType() const { return type; }
double Reservoir::getLength() const { return length; }
double Reservoir::getWidth() const { return width; }
double Reservoir::getDepth() const { return maxDepth; }