#include <iostream>
#include <string>

using namespace std;

struct Auto
{
    int length;
    int clearance;
    int vEngine;
    int fEngine;
    int dWheels;
    string color;
    string transmission;

    void setValues(int len, int clear, int vE, int fE, int dWh, string col, string trans) {
        length = len;
        clearance = clear;
        vEngine = vE;
        fEngine = fE;
        dWheels = dWh;
        color = col;
        transmission = trans;
    }

    void print() {
        cout << "Длина: " << length << " м" << endl;
        cout << "Клиренс: " << clearance << " м" << endl;
        cout << "Объем двигателя: " << vEngine << " л" << endl;
        cout << "Мощность двигателя: " << fEngine << " л.с." << endl;
        cout << "Диаметр колес: " << dWheels << " см" << endl;
        cout << "Цвет: " << color << endl;
        cout << "Тип коробки передач: " << transmission << endl;
        cout << "-----------------------\n";
    }

    bool matches(const Auto& other) {
        return
            (length == other.length || other.length == 0) &&
            (clearance == other.clearance || other.clearance == 0) &&
            (vEngine == other.vEngine || other.vEngine == 0) &&
            (fEngine == other.fEngine || other.fEngine == 0) &&
            (dWheels == other.dWheels || other.dWheels == 0) &&
            (color == other.color || other.color == "0") &&
            (transmission == other.transmission || other.transmission == "0");
    }
};


void search(Auto cars[], int size, const Auto& searchAuto) {
    bool found = false;
    for (int i = 0; i < size; i++) {
        if (cars[i].matches(searchAuto)) {
            cout << "Найден автомобиль:\n";
            cars[i].print();
            cout << "-----------------------\n";
            found = true;
        }
    }
    if (!found) {
        cout << "Таких автомобилей не найдено\n";
    }
}

int main()
{
    setlocale(LC_ALL, "");

    const int carCount = 3;
    Auto cars[carCount];

    cars[0].setValues(4.2, 0.2, 2.0, 150, 35, "Красный", "Автомат");
    cars[1].setValues(4.5, 0.18, 3.0, 200, 30, "Синий", "Механика");
    cars[2].setValues(3.9, 0.15, 1.8, 120, 40, "Черный", "Автомат");

    Auto searchCar;
    cout << "Введите желаемые характеристики автомобиля:\n";
    double length, clearance, vEngine, fEngine, dWheel;
    string color, transmission;

    cout << "Длина (0 для пропуска): ";
    cin >> length;
    cout << "Клиренс (0 для пропуска): ";
    cin >> clearance;
    cout << "Объем двигателя (0 для пропуска): ";
    cin >> vEngine;
    cout << "Мощность двигателя (0 для пропуска): ";
    cin >> fEngine;
    cout << "Диаметр колес (0 для пропуска): ";
    cin >> dWheel;
    cout << "Цвет (0 для пропуска): ";
    cin >> color;
    cout << "Тип коробки передач (0 для пропуска): ";
    cin >> transmission;

    searchCar.setValues(length, clearance, vEngine, fEngine, dWheel, color, transmission);

    cout << "\nРезультаты поиска:\n";
    search(cars, carCount, searchCar);

    return 0;
}
