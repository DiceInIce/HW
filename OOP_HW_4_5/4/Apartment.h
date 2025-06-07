#pragma once
#include "Person.h"

class Apartment {
    Person* people;
    int personCount;

public:
    Apartment(int count = 0);
    Apartment(const Apartment& other);
    Apartment& operator=(const Apartment& other);
    ~Apartment();

    void setPerson(int index, const Person& person);
    void print() const;
};

