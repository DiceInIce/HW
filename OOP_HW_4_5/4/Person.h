#pragma once
#include <iostream>

using namespace std;

class Person {
    char* fullName;
    int age;

public:
    Person(const char* name = "Без имени", int age = 0);
    Person(const Person& other);
    Person& operator=(const Person& other);
    ~Person();

    void print() const;
};
