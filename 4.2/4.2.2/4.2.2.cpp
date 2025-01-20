#include <iostream>

using namespace std;

int main() {

    setlocale(LC_ALL, "");

    int sales1 = 0;
    int sales2 = 0;
    int sales3 = 0;

    int salary1 = 200;
    int salary2 = 200;
    int salary3 = 200;

    double bonus = 0;


    cout << "Введите уровень продаж 1-ого менеджера: ";
    cin >> sales1;
    cout << "Введите уровень продажу 2-ого менеджера: ";
    cin >> sales2;
    cout << "Введите уровень продаж 3-его менеджера: ";
    cin >> sales3;

    if (sales1 > 1000) {
        bonus = 1.08;
    }
    else if (sales1 > 500) {
        bonus = 1.05;
    }
    else {
        bonus = 1.03;
    }
    salary1 *= bonus;
    

    if (sales2 > 1000) {
        bonus = 1.08;
    }
    else if (sales2 > 500) {
        bonus = 1.05;
    }
    else {
        bonus = 1.03;
    }
    salary2 *= bonus;


    if (sales3 > 1000) {
        bonus = 1.08;
    }
    else if (sales3 > 500) {
        bonus = 1.05;
    }
    else {
        bonus = 1.03;
    }
    salary3 *= bonus;



    int best = 0;


    if (sales1 > sales2 && sales1 > sales3) {
        salary1 += 200;
        best = 1;
    }
    else if (sales2 > sales1 && sales2 > sales3) {
        salary2 += 200;
        best = 2;
    }
    else {
        salary3 += 200;
        best = 3;
    }

    cout << "\nЗарплата 1-ого менеджера: " << salary1;
    cout << "\nЗарплата 2-ого менеджера: " << salary2;
    cout << "\nЗарплата 3-tго менеджера: " << salary3;

    cout << "\n\nЛучшим стал " << best << " менеджер и получил прибавку в 200$\n";

    return 0;
}
