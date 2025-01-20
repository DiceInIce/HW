#include <iostream>


using namespace std;

int main()
{
    setlocale(LC_ALL, "");

    int a = 0;
    int b = 0;
    int c = 0;
    int d = 0;
    int e = 0;
    int f = 0;
    int g = 0;
    int max = 0;

    cout << "Введите 1-ое число: ";
    cin >> a;
    cout << "Введите 2-ое число: ";
    cin >> b;
    cout << "Введите 3-ое число: ";
    cin >> c;
    cout << "Введите 4-ое число: ";
    cin >> d;
    cout << "Введите 5-ое число: ";
    cin >> e;
    cout << "Введите 6-ое число: ";
    cin >> f;
    cout << "Введите 7-ое число: ";
    cin >> g;

    if (a > b) max = a;
    if (b > max) max = b;
    if (c > max) max = c;
    if (d > max) max = d;
    if (e > max) max = e;
    if (f > max) max = f;
    if (g > max) max = g;
    
    cout << "Наибольшее число: " << max;
    
}


