#pragma once
#include <string>
using namespace std;

class Reservoir {
private:
    string name;
    string type;
    double length;
    double width;
    double maxDepth;

public:
    Reservoir();
    explicit Reservoir(const string& name, const string& type,
        double length, double width, double maxDepth);
    Reservoir(const Reservoir& other);
    Reservoir& operator=(const Reservoir& other);
    ~Reservoir() = default;

    double getVolume() const;
    double getSurfaceArea() const;
    bool isSameType(const Reservoir& other) const;
    int compareArea(const Reservoir& other) const;

    void display() const;

    // Сеттеры
    void setName(const string& n);
    void setType(const string& t);
    void setLength(double l);
    void setWidth(double w);
    void setDepth(double d);

    // Геттеры
    string getName() const;
    string getType() const;
    double getLength() const;
    double getWidth() const;
    double getDepth() const;
};