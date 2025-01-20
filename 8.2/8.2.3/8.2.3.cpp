#include <iostream>

using namespace std;



int main()
{
    setlocale(LC_ALL, "");

    int months[12]{};
    int start = 0;
    int end = 0;

    

    for (int i = 0; i < size(months); i++) {
        cout << "\n Введите прибыль за " << i+1 << " месяц: ";
        cin >> months[i];
    }

    int min = 0;
    int minWorth = months[0];
    int max = 0;
    int maxWorth = months[0];
    
    cout << "\nВведите диапазон месяцев:\n";
    cout << "с - ";
    cin >> start;
    cout << "до - ";
    cin >> end;

    int range = end - start;

    for (int i = start - 1; i < end; i++) {

        if (months[i] > maxWorth) {
            maxWorth = months[i];
            max = i;
        }

        if (months[i] < minWorth) {
            minWorth = months[i];
            min = i;
        }
    }

    cout << "\nНаименьшая прибыль была в " << min + 1 << " месяце и составила: " << minWorth << endl;
    cout << "Наибольшая прибыль была в " << max + 1 << " месяце и составила: " << maxWorth << endl;

    return 0;
}