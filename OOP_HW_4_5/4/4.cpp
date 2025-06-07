#include <iostream>
#include "Building.h"

using namespace std;

int main() {
    setlocale(LC_ALL, "");

    Person p1("Иван Иванов", 30);
    Person p2("Мария Петрова", 25);
    Person p3("Алексей Смирнов", 40);

    Apartment a1(2);
    a1.setPerson(0, p1);
    a1.setPerson(1, p2);

    Apartment a2(1);
    a2.setPerson(0, p3);

    Building building(2);
    building.setApartment(0, a1);
    building.setApartment(1, a2);

    building.print();

    return 0;
}