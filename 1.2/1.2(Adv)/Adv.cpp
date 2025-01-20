#include <iostream>
#include <locale.h>

using namespace std;

int main()
{
    setlocale(LC_ALL, "");

    cout << "Продам гараж" << endl;
    cout << "Цена: 100500р." << endl;
    cout << "..." << endl;
    cout << "Тел.: 8-800-35-35" << endl;
    cout << "8  \t|" << "8  \t|" << "8  \t|" << "8  \t|" << endl;
    cout << "800\t|" << "800\t|" << "800\t|" << "800\t|" << endl;
    cout << "35 \t|" << "35 \t|" << "35 \t|" << "35 \t|" << endl;
    cout << "35 \t|" << "35 \t|" << "35 \t|" << "35 \t|" << endl;

    return 0;
}