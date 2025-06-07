#include "Person.h"
#pragma warning(disable : 4996)
#include <cstring>

Person::Person(const char* name, int age) : age(age) {
    fullName = new char[strlen(name) + 1];
    strcpy(fullName, name);
}

Person::Person(const Person& other) : age(other.age) {
    fullName = new char[strlen(other.fullName) + 1];
    strcpy(fullName, other.fullName);
}

Person& Person::operator=(const Person& other) {
    if (this != &other) {
        delete[] fullName;
        fullName = new char[strlen(other.fullName) + 1];
        strcpy(fullName, other.fullName);
        age = other.age;
    }
    return *this;
}

Person::~Person() {
    delete[] fullName;
}

void Person::print() const {
    cout << "Имя: " << fullName << ", Возраст: " << age << endl;
}