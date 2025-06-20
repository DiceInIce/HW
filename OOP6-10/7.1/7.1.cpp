#include <iostream>
#include "Overcoat.h"

int main() {
    setlocale(LC_ALL, "");

    Overcoat coat1("Пальто", 15000);
    Overcoat coat2("Пальто", 18000);
    Overcoat coat3("Плащ", 12000);

    cout << "1: " << coat1 << endl;
    cout << "2: " << coat2 << endl;
    cout << "3: " << coat3 << endl;

    if (coat1 == coat2)
        cout << "1 и 2 одного типа" << endl;

    if (coat2 > coat1)
        cout << "2 дороже 1" << endl;

    coat3 = coat1;
    cout << "3 после присваивания 1: " << coat3 << endl;

    return 0;
}