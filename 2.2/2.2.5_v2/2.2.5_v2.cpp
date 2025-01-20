#include <iostream>
#include <locale.h>
#include <cmath>

using namespace std;

int main()
{
    setlocale(LC_ALL, "");

    // ≈сли ежемес€чный процент добавл€етс€ к сумме депозита

    double deposit;
    double rate;
    double monthlyPayoutEuros = 0;
    double monthlyPayoutCents = 0;


    cout << "¬ведите сумму денежного вклада (в евро): ";
    cin >> deposit;

    cout << "¬ведите процент годовых, которые выплачивает банк: ";
    cin >> rate;

    double monthlyRate = rate / 12.0;

    for (int i = 1; i <= 12; ++i) {

        double monthlyPayout = (deposit * monthlyRate) / 100.0;
        deposit += monthlyPayout;

        monthlyPayoutCents = modf(monthlyPayout, &monthlyPayoutEuros);
        int monthlyPayoutCents2 = monthlyPayoutCents / 0.01;

        cout << "ћес€ц " << i << ": сумма выплаты = " << monthlyPayoutEuros << " евро "<< monthlyPayoutCents2 << " центов" << endl;
    }

    return 0;
}