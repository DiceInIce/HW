#include "Reservoir.h"
#include "reservoir_utils.h"
#include <iostream>

int main() {
    setlocale(LC_ALL, "");

    vector<Reservoir> reservoirs;

    Reservoir r1("Байкал", "Озеро", 636, 79, 1642);
    Reservoir r2("Черное море", "Море", 1000, 800, 2210);
    Reservoir r3("Пруд №1", "Пруд", 40, 30, 5);

    addReservoir(reservoirs, r1);
    addReservoir(reservoirs, r2);
    addReservoir(reservoirs, r3);

    printAll(reservoirs);

    cout << "Сравнение типов: " << r1.isSameType(r3) << endl;
    cout << "Сравнение площадей (r1 vs r3): " << r1.compareArea(r3) << endl;

    saveToTextFile(reservoirs, "reservoirs.txt");
    saveToBinaryFile(reservoirs, "reservoirs.bin");

    return 0;
}