#include "Building.h"

Building::Building(int count) : apartmentCount(count) {
    apartments = new Apartment[apartmentCount];
}

Building::Building(const Building& other) : apartmentCount(other.apartmentCount) {
    apartments = new Apartment[apartmentCount];
    for (int i = 0; i < apartmentCount; ++i)
        apartments[i] = other.apartments[i];
}

Building& Building::operator=(const Building& other) {
    if (this != &other) {
        delete[] apartments;
        apartmentCount = other.apartmentCount;
        apartments = new Apartment[apartmentCount];
        for (int i = 0; i < apartmentCount; ++i)
            apartments[i] = other.apartments[i];
    }
    return *this;
}

Building::~Building() {
    delete[] apartments;
}

void Building::setApartment(int index, const Apartment& apartment) {
    if (index >= 0 && index < apartmentCount)
        apartments[index] = apartment;
}

void Building::print() const {
    cout << "Дом: " << apartmentCount << " квартир(ы)" << endl;
    for (int i = 0; i < apartmentCount; ++i) {
        cout << "Квартира #" << i + 1 << ":" << endl;
        apartments[i].print();
    }
}