#include "Apartment.h"

Apartment::Apartment(int count) : personCount(count) {
    people = new Person[personCount];
}

Apartment::Apartment(const Apartment& other) : personCount(other.personCount) {
    people = new Person[personCount];
    for (int i = 0; i < personCount; ++i)
        people[i] = other.people[i];
}

Apartment& Apartment::operator=(const Apartment& other) {
    if (this != &other) {
        delete[] people;
        personCount = other.personCount;
        people = new Person[personCount];
        for (int i = 0; i < personCount; ++i)
            people[i] = other.people[i];
    }
    return *this;
}

Apartment::~Apartment() {
    delete[] people;
}

void Apartment::setPerson(int index, const Person& person) {
    if (index >= 0 && index < personCount)
        people[index] = person;
}

void Apartment::print() const {
    cout << " вартира: " << personCount << " человек(а)" << endl;
    for (int i = 0; i < personCount; ++i) {
        cout << "  ∆илец #" << i + 1 << ": ";
        people[i].print();
    }
}