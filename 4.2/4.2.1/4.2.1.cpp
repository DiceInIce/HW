#include <iostream>
#include <string>

using namespace std;

int main() {

    setlocale(LC_ALL, "");

    // Пиццы
    string pizza1_name = "Маргарита";
    double pizza1_price = 10.0;

    string pizza2_name = "Пепперони";
    double pizza2_price = 12.0;

    string pizza3_name = "Вегетарианская";
    double pizza3_price = 11.0;

    string pizza4_name = "Четыре сыра";
    double pizza4_price = 14.0;

    // Напитки
    string drink1_name = "Кола";
    double drink1_price = 1.5;

    string drink2_name = "Сок";
    double drink2_price = 2.5;

    string drink3_name = "Чай";
    double drink3_price = 2.0;

    // Расчет
    double total = 0.0;
    int total_pizza_count = 0; // 5 в подарок
    double drink_discount = 0.0;
    string order_summary = "Ваш заказ:\n";

    cout << "Пицца у Витюши!" << endl;

    while (true) {
        //Меню
        cout << "\nМеню пиццы:" << endl;
        cout << "P1: " << pizza1_name << " - $" << pizza1_price << endl;
        cout << "P2: " << pizza2_name << " - $" << pizza2_price << endl;
        cout << "P3: " << pizza3_name << " - $" << pizza3_price << endl;
        cout << "P4: " << pizza4_name << " - $" << pizza4_price << endl;

        cout << "\nМеню напитков:" << endl;
        cout << "D1: " << drink1_name << " - $" << drink1_price << endl;
        cout << "D2: " << drink2_name << " - $" << drink2_price << endl;
        cout << "D3: " << drink3_name << " - $" << drink3_price << endl;

        // Ввод кода продукта
        string product_code;
        cout << "\nВведите код продукта (или 'finish' для завершения заказа): ";
        cin >> product_code;

        if (product_code == "finish") {
            break;
        }

        // Ввод количества
        int quantity;
        cout << "Введите количество: ";
        cin >> quantity;

        // Обработка заказа
        switch (product_code[0]) {
        case 'P': {
            int free_pizzas = quantity / 5;
            switch (product_code[1]) {
            case '1':
                total += (quantity - free_pizzas) * pizza1_price;
                total_pizza_count += quantity;
                order_summary += pizza1_name + " x" + to_string(quantity) + "\n";
                break;
            case '2':
                total += (quantity - free_pizzas) * pizza2_price;
                total_pizza_count += quantity;
                order_summary += pizza2_name + " x" + to_string(quantity) + "\n";
                break;
            case '3':
                total += (quantity - free_pizzas) * pizza3_price;
                total_pizza_count += quantity;
                order_summary += pizza3_name + " x" + to_string(quantity) + "\n";
                break;
            case '4':
                total += (quantity - free_pizzas) * pizza4_price;
                total_pizza_count += quantity;
                order_summary += pizza4_name + " x" + to_string(quantity) + "\n";
                break;
            default:
                cout << "Неверный код продукта. Попробуйте снова." << endl;
                break;
            }
            break;
        }
        case 'D': {
            switch (product_code[1]) {
            case '1':
                total += quantity * drink1_price;
                order_summary += drink1_name + " x" + to_string(quantity) + "\n";
                break;
            case '2':
                if (quantity > 3) {
                    drink_discount += quantity * drink2_price * 0.15;
                }
                total += quantity * drink2_price;
                order_summary += drink2_name + " x" + to_string(quantity) + "\n";
                break;
            case '3':
                total += quantity * drink3_price;
                order_summary += drink3_name + " x" + to_string(quantity) + "\n";
                break;
            default:
                cout << "Неверный код продукта. Попробуйте снова." << endl;
                break;
            }
            break;
        }
        default:
            cout << "Неверный код продукта. Попробуйте снова." << endl;
            break;
        }
    }

    // Скидон
    if (total > 50.0) {
        total *= 0.8;
    }

    total -= drink_discount;

    // Итог
    cout << "\n" << order_summary;
    cout << "\nИтого к оплате: $" << total << endl;

    return 0;
}