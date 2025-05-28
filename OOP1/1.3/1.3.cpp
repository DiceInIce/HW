#include <iostream>
#include <cstring>
#include "StringCustom.h"


using namespace std;

int StringCustom::objectCount = 0;

int main() {
    setlocale(LC_ALL, "");

    StringCustom s1;
    s1.input();
    s1.display();
    cout << endl;

    StringCustom s2(30);
    s2.input();
    s2.display();
    cout << endl;

    StringCustom s3("Hello, world!");
    s3.display();
    cout << endl;

    StringCustom s4(s3);
    s4.display();
    cout << endl;

    StringCustom s5 = s4;
    s5.display();
    cout << endl;
    cout << StringCustom::getObjectCount() << endl;

    return 0;
}