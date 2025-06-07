#pragma once
#include "Apartment.h"

class Building {
    Apartment* apartments;
    int apartmentCount;

public:
    Building(int count = 0);
    Building(const Building& other);
    Building& operator=(const Building& other);
    ~Building();

    void setApartment(int index, const Apartment& apartment);
    void print() const;
};


