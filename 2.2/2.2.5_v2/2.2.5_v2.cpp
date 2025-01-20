#include <iostream>
#include <locale.h>
#include <cmath>

using namespace std;

int main()
{
    setlocale(LC_ALL, "");

    // ���� ����������� ������� ����������� � ����� ��������

    double deposit;
    double rate;
    double monthlyPayoutEuros = 0;
    double monthlyPayoutCents = 0;


    cout << "������� ����� ��������� ������ (� ����): ";
    cin >> deposit;

    cout << "������� ������� �������, ������� ����������� ����: ";
    cin >> rate;

    double monthlyRate = rate / 12.0;

    for (int i = 1; i <= 12; ++i) {

        double monthlyPayout = (deposit * monthlyRate) / 100.0;
        deposit += monthlyPayout;

        monthlyPayoutCents = modf(monthlyPayout, &monthlyPayoutEuros);
        int monthlyPayoutCents2 = monthlyPayoutCents / 0.01;

        cout << "����� " << i << ": ����� ������� = " << monthlyPayoutEuros << " ���� "<< monthlyPayoutCents2 << " ������" << endl;
    }

    return 0;
}