#include <iostream>

using namespace std;


void bubbleSort(int arr[], int n) {
    for (int i = 0; i < n - 1; i++) {

        bool swapped = false;

        for (int j = 0; j < n - i - 1; j++) {
            if (arr[j] > arr[j + 1]) {
                swap(arr[j], arr[j + 1]);
                swapped = true;
            }
        }

        if (!swapped) break;
    }
}

void main()
{
    setlocale(LC_ALL, "");

    int max = 99999999999;
    int mobNumbers[]{ max, max, max, max, max, max, max, max, max, max };
    int homeNumbers[]{ max, max, max, max, max, max, max, max, max, max };
    int choice = 0;
    int mobSize = size(mobNumbers);
    int homeSize = size(homeNumbers);
    bool wrote = false;


    while (choice != 6) {
        cout << "\n\nВыберите операцию :" << endl;
        cout << "\nСортировка мобильных номеров - 1";
        cout << "\nСортировка домашних номеров - 2";
        cout << "\nВвести данные - 3";
        cout << "\nУдалить номер - 4";
        cout << "\nВывести данные - 5";
        cout << "\nВыход - 6\n\n";
        cout << "Операция : ";
        cin >> choice;

        switch (choice)
        {
        case 1: {
            bubbleSort(mobNumbers, mobSize);
            choice = 0;
            break;
        }
        case 2: {
            bubbleSort(homeNumbers, homeSize);
            choice = 0;
            break;
        }
        case 3: {
            int choice2 = 0;
            cout << "\nВвести мобильный номер - 1, домашний - 2, выйти - 3 " << endl;
            cin >> choice2;

            switch (choice2)
            {
            case 1: {
                int temp = 0;
                for (int n = 0;n < mobSize; n++) {
                    if (mobNumbers[n] == max) {
                        cout << "Введите номер: ";
                        cin >> mobNumbers[n];

                        wrote = true;
                        break;
                    }
                }
                if (wrote == false) cout << "В справочнике нет места\n";
                else if (wrote == true) cout << "Записано\n";
                break;
            }
            case 2: {
                int temp = 0;
                for (int n = 0;n < homeSize; n++) {
                    if (homeNumbers[n] == max) {
                        cout << "Введите номер: ";
                        cin >> homeNumbers[n];

                        wrote = true;
                        break;
                    }
                }
                if (wrote == false) cout << "В справочнике нет места\n";
                else if (wrote == true) cout << "Записано\n";
                break;
            }
            case 3: {
                break;
            }
            default:

                break;
            }
            choice2 = 0;
            break;
        }
        case 4: {
            int numOrder = 0;
            int choice2 = 0;

            cout << "Удалить мобильный номер - 1, домашний - 2, выйти - 3 " << endl;
            cin >> choice2;

            switch (choice2)
            {
            case 1: {
                cout << "Введите порядковый номер телефона в справочнике: ";
                cin >> numOrder;

                mobNumbers[numOrder - 1] = max;
                break;
            } 
            case 2: {
                cout << "Введите порядковый номер телефона в справочнике: ";
                cin >> numOrder;

                homeNumbers[numOrder - 1] = max;
                break;
            }
            case 3: {
                break;
            }
            default:
                break;
            }
            choice = 0;
            break;
        }
        case 5: {
            int choice2 = 0;
            cout << "\nВывести мобильные номера - 1, домашние - 2, выйти - 3 " << endl;
            cin >> choice2;

            switch (choice2)
            {
            case 1: {
                for (int n = 0; n < mobSize; n ++) {
                    if (mobNumbers[n] != max) cout << n+1 << ": "<< mobNumbers[n] << "\n";
                    else cout << n << ": " << "Пусто\n";
                }
                break;
            }
            case 2: {
                for (int n = 0; n < homeSize; n++) {
                    if (homeNumbers[n] != max) cout << n+1 << ": " << homeNumbers[n] << "\n";
                    else cout << n << ": " << "Пусто\n";
                }
                break;
            }
            case 3: {

                break;
            }
            default:

                break;
            }
            choice = 0;
            break;
        }

        case 6:
            break;
        default:
            break;
        }

    }

}
