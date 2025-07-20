#include <iostream>
#include "Array.hpp"

using namespace std;

int main() {

    setlocale(LC_ALL, "");
    
    cout << "=== Демонстрация работы шаблонного класса Array ===" << endl;

    // 1. Создание массива целых чисел
    Array<int> intArr(3, 2);
    cout << "\n1. Создан массив целых чисел (начальный размер 3, шаг роста 2):" << endl;
    intArr.Show();

    // 2. Добавление элементов
    for (int i = 0; i < 5; i++) {
        intArr.Add(i * 10);
    }
    cout << "\n2. После добавления 5 элементов:" << endl;
    intArr.Show();

    // 3. Изменение размера
    intArr.SetSize(7);
    cout << "\n3. После увеличения размера до 7:" << endl;
    intArr.Show();

    // 4. Вставка элемента
    intArr.InsertAt(2, 99);
    cout << "\n4. После вставки числа 99 на позицию 2:" << endl;
    intArr.Show();

    // 5. Удаление элементов
    intArr.RemoveAt(3, 2);
    cout << "\n5. После удаления 2 элементов начиная с позиции 3:" << endl;
    intArr.Show();

    // 6. Создание второго массива
    Array<int> intArr2;
    intArr2.Add(100);
    intArr2.Add(200);
    cout << "\n6. Создан второй массив:" << endl;
    intArr2.Show();

    // 7. Объединение массивов
    intArr.Append(intArr2);
    cout << "\n7. После объединения с вторым массивом:" << endl;
    intArr.Show();

    // 8. Работа с оператором []
    cout << "\n8. Тестирование оператора []:" << endl;
    cout << "Элемент на позиции 0: " << intArr[0] << endl;
    intArr[1] = 555;
    cout << "После изменения элемента на позиции 1 на 555:" << endl;
    intArr.Show();

    // 9. Создание массива строк
    Array<string> strArr(2);
    strArr.Add("Привет");
    strArr.Add("Мир");
    strArr.Add("Шаблоны");
    cout << "\n9. Создан массив строк:" << endl;
    strArr.Show();

    // 10. Получение данных в C-массив
    cout << "\n10. Получение данных в C-массив:" << endl;
    int* rawData = intArr.GetData();
    cout << "C-массив: [";
    for (int i = 0; i < intArr.GetUpperBound() + 1; ++i) {
        cout << rawData[i];
        if (i < intArr.GetUpperBound()) cout << ", ";
    }
    cout << "]" << endl;
    delete[] rawData;

    // 11. Тестирование копирования
    Array<int> intArr3 = intArr;
    cout << "\n11. Создана копия первого массива:" << endl;
    intArr3.Show();

    cout << "\n=== Демонстрация завершена ===" << endl;
    return 0;
}