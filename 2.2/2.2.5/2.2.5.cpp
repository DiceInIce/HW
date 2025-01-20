#include <iostream>
#include <locale.h>
#include <cmath>

using namespace std;

int main()
{
    setlocale(LC_ALL, "");

    // Если ежемесячный процент добавляется к сумме депозита

    double deposit = 0; 
    double Rate = 0; 
    double monthlyPayoutEuros = 0;
    double monthlyPayoutCents = 0;

    cout << "Введите сумму денежного вклада (в евро): ";
    cin >> deposit;
    cout << "Введите процент годовых, которые выплачивает банк: ";
    cin >> Rate;

    double monthlyRate = Rate / 12.0; 

    double monthlyPayout = (deposit * monthlyRate) / 100.0; 

    monthlyPayoutCents = modf(monthlyPayout, &monthlyPayoutEuros);
    int monthlyPayoutCents2 = monthlyPayoutCents / 0.01;

    cout << "Ежемесячная выплата: " << monthlyPayoutEuros << " евро " << monthlyPayoutCents2 << " центов" << endl;

    return 0;
}