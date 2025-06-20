#include <iostream>
#include "Flat.h"

int main() {
    setlocale(LC_ALL, "");

    Flat flat1(60.5, 5000000);
    Flat flat2(60.5, 5500000);
    Flat flat3(45.0, 4000000);

    cout << "1: " << flat1 << endl;
    cout << "2: " << flat2 << endl;
    cout << "3: " << flat3 << endl;

    if (flat1 == flat2)
        cout << "flat1 и flat2 имеют одинаковую площадь." << endl;
    else
        cout << "flat1 и flat2 имеют разную площадь." << endl;

    if (flat2 > flat1)
        cout << "flat2 дороже flat1." << endl;

    flat3 = flat1;
    cout << "flat3 после присваивания flat1: " << flat3 << endl;

    return 0;
}