#include <iostream>
#include <string>
using namespace std;

class Overcoat {
private:
    string type;
    double price;

public:

    Overcoat(const string& t = "", double p = 0.0);

    string getType() const;
    double getPrice() const;

    void setType(const string& t);
    void setPrice(double p);

    bool operator==(const Overcoat& other) const;
    Overcoat& operator=(const Overcoat& other);
    bool operator>(const Overcoat& other) const;

    friend ostream& operator<<(ostream& out, const Overcoat& o);
};
