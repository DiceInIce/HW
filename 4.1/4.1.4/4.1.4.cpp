#include <iostream>


using namespace std;

int main()
{
    setlocale(LC_ALL, "");

    int l1 = 0;
    int l2 = 0;
    int weight = 0;
    double gas = 300.0;
    int loss = 0;
    int refill = 0;

    cout << "Введите расстояние от точки A до B: ";
    cin >> l1;
    cout << "Введите расстояние от точки B до C: ";
    cin >> l2;
    cout << "Введите вес груза: ";
    cin >> weight;

    if (weight > 2000) {
        cout << "Самолет не взлетит";
        return 0;
    }
    else if (weight <= 500) loss = 1;
    else if (weight <= 1000) loss = 4;
    else if (weight <= 1500) loss = 7;
    else if (weight <= 2000) loss = 9;

    double gasNeededAtoB = l1 * loss;

    if (gasNeededAtoB > gas) {
        cout << "Самолет не сможет долететь от A до B. Топлива недостаточно." << endl;
        return 0;
    }

    double gasLeft = gas - gasNeededAtoB;

    double gasNeededBtoC = l2 * loss;

    if (gasNeededBtoC > gas) {
        cout << "Самолет не сможет долететь от B до C даже с полным баком. Топлива недостаточно." << endl;
        return 0;
    }

    if (gasLeft >= gasNeededBtoC) {
        cout << "Дозаправка не потребуется." << endl;
    }
    else {
        refill = gasNeededBtoC - gasLeft;
        cout << "Для дозаправки потребуется " << refill << " л топлива." << endl;
    }

    return 0;
}