#include <iostream>
using namespace std;

class Flat {
private:
    double area;
    double price;

public:
    Flat(double a = 0.0, double p = 0.0);

    double getArea() const;
    double getPrice() const;

    void setArea(double a);
    void setPrice(double p);

    bool operator==(const Flat& other) const;
    Flat& operator=(const Flat& other);
    bool operator>(const Flat& other) const;

    friend ostream& operator<<(ostream& out, const Flat& f);
};
