#include <iostream>
#include <fstream>
#include <vector>
#include <string>
#include <algorithm>

using namespace std;

struct Employee {
    string surname;
    string name;
    int age;
};

vector<Employee> employees;
string filename;

void loadFromFile(const string& fname) {
    ifstream file(fname);
    if (!file) {
        cout << "Ошибка открытия файла: " << fname << endl;
        return;
    }
    employees.clear();
    Employee emp;
    while (file >> emp.surname >> emp.name >> emp.age) {
        employees.push_back(emp);
    }
    file.close();
}

void saveToFile(const string& fname) {
    ofstream file(fname);
    for (const auto& emp : employees) {
        file << emp.surname << " " << emp.name << " " << emp.age << endl;
    }
    file.close();
}

void saveSearchResultsToFile(const vector<Employee>& results, const string& fname) {
    ofstream file(fname);
    for (const auto& emp : results) {
        file << emp.surname << " " << emp.name << " " << emp.age << endl;
    }
    file.close();
    cout << "Результаты поиска сохранены в файл: " << fname << endl;
}

void addEmployee() {
    Employee emp;
    cout << "Введите фамилию: ";
    cin >> emp.surname;
    cout << "Введите имя: ";
    cin >> emp.name;
    cout << "Введите возраст: ";
    cin >> emp.age;
    employees.push_back(emp);
    cout << "Сотрудник добавлен." << endl;
}

void deleteEmployee(const string& surname) {
    employees.erase(remove_if(employees.begin(), employees.end(), [&](const Employee& emp) {
        return emp.surname == surname;
        }), employees.end());
    cout << "Сотрудник удалён." << endl;
}

void editEmployee(const string& surname) {
    for (auto& emp : employees) {
        if (emp.surname == surname) {
            cout << "Введите новое имя: ";
            cin >> emp.name;
            cout << "Введите новый возраст: ";
            cin >> emp.age;
            cout << "Данные сотрудника обновлены." << endl;
            return;
        }
    }
    cout << "Сотрудник не найден." << endl;
}

void findBySurname(const string& surname) {
    vector<Employee> results;
    for (const auto& emp : employees) {
        if (emp.surname == surname) {
            cout << emp.surname << " " << emp.name << " " << emp.age << endl;
            results.push_back(emp);
        }
    }
    if (results.empty()) {
        cout << "Сотрудник не найден." << endl;
    }
    else {
        string fname;
        cout << "Введите имя файла для сохранения результата: ";
        cin >> fname;
        saveSearchResultsToFile(results, fname);
    }
}

void findByAge(int age) {
    vector<Employee> results;
    for (const auto& emp : employees) {
        if (emp.age == age) {
            cout << emp.surname << " " << emp.name << " " << emp.age << endl;
            results.push_back(emp);
        }
    }
    if (!results.empty()) {
        string fname;
        cout << "Введите имя файла для сохранения результата: ";
        cin >> fname;
        saveSearchResultsToFile(results, fname);
    }
}

void findByLetter(char letter) {
    vector<Employee> results;
    for (const auto& emp : employees) {
        if (!emp.surname.empty() && emp.surname[0] == letter) {
            cout << emp.surname << " " << emp.name << " " << emp.age << endl;
            results.push_back(emp);
        }
    }
    if (!results.empty()) {
        string fname;
        cout << "Введите имя файла для сохранения результата: ";
        cin >> fname;
        saveSearchResultsToFile(results, fname);
    }
}

void listEmployees() {
    for (const auto& emp : employees) {
        cout << emp.surname << " " << emp.name << " " << emp.age << endl;
    }
}

int main() {
    setlocale(LC_ALL, "");

    cout << "Введите имя файла для загрузки: ";
    cin >> filename;
    loadFromFile(filename);

    int choice;
    do {
        cout << "1. Добавить сотрудника" << endl;
        cout << "2. Редактировать сотрудника" << endl;
        cout << "3. Удалить сотрудника" << endl;
        cout << "4. Найти по фамилии" << endl;
        cout << "5. Найти по возрасту" << endl;
        cout << "6. Найти по первой букве фамилии" << endl;
        cout << "7. Показать всех сотрудников" << endl;
        cout << "8. Сохранить список" << endl;
        cout << "9. Выход" << endl;
        cout << "Выберите действие: ";
        cin >> choice;

        switch (choice) {
        case 1: addEmployee(); break;
        case 2: {
            string surname;
            cout << "Введите фамилию: ";
            cin >> surname;
            editEmployee(surname);
            break;
        }
        case 3: {
            string surname;
            cout << "Введите фамилию: ";
            cin >> surname;
            deleteEmployee(surname);
            break;
        }
        case 4: {
            string surname;
            cout << "Введите фамилию: ";
            cin >> surname;
            findBySurname(surname);
            break;
        }
        case 5: {
            int age;
            cout << "Введите возраст: ";
            cin >> age;
            findByAge(age);
            break;
        }
        case 6: {
            char letter;
            cout << "Введите первую букву фамилии: ";
            cin >> letter;
            findByLetter(letter);
            break;
        }
        case 7: listEmployees(); break;
        case 8: saveToFile(filename); break;
        case 9: saveToFile(filename); break;
        default: cout << "Неверный выбор." << endl;
        }
    } while (choice != 9);

    return 0;
}