#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <vector>
#include <cstring>
#include <fstream>
#include <string>

using namespace std;

class Contact {
private:
    char* fullName;
    string homePhone;
    string workPhone;
    string mobilePhone;
    string additionalInfo;

public:

    Contact() : fullName(nullptr), homePhone(""), workPhone(""), mobilePhone(""), additionalInfo("") {}

    Contact(const char* name, const string& home, const string& work,
            const string& mobile, const string& info)
        : homePhone(home), workPhone(work), mobilePhone(mobile), additionalInfo(info)
    {
        fullName = new char[strlen(name) + 1];
        strcpy(fullName, name);
    }

    Contact(const Contact& other) {
        fullName = new char[strlen(other.fullName) + 1];
        strcpy(fullName, other.fullName);
        homePhone = other.homePhone;
        workPhone = other.workPhone;
        mobilePhone = other.mobilePhone;
        additionalInfo = other.additionalInfo;
    }

    Contact& operator=(const Contact& other) {
        if (this != &other) {
            delete[] fullName;
            fullName = new char[strlen(other.fullName) + 1];
            strcpy(fullName, other.fullName);
            homePhone = other.homePhone;
            workPhone = other.workPhone;
            mobilePhone = other.mobilePhone;
            additionalInfo = other.additionalInfo;
        }
        return *this;
    }

    ~Contact() {
        delete[] fullName;
    }

    const char* getFullName() const {
        return fullName;
    }

    void display() const {
        cout << "Полное имя: " << fullName << endl;
        cout << "Домашний: " << homePhone << endl;
        cout << "Рабочий: " << workPhone << endl;
        cout << "Мобильный: " << mobilePhone << endl;
        cout << "Доп инфо: " << additionalInfo << endl;
        cout << "-------------------------------" << endl;
    }

    void save(ofstream& out) const {
        size_t len = strlen(fullName);
        out.write(reinterpret_cast<const char*>(&len), sizeof(len));
        out.write(fullName, len);
        size_t fieldSize;

        fieldSize = homePhone.size();
        out.write(reinterpret_cast<const char*>(&fieldSize), sizeof(fieldSize));
        out.write(homePhone.c_str(), fieldSize);

        fieldSize = workPhone.size();
        out.write(reinterpret_cast<const char*>(&fieldSize), sizeof(fieldSize));
        out.write(workPhone.c_str(), fieldSize);

        fieldSize = mobilePhone.size();
        out.write(reinterpret_cast<const char*>(&fieldSize), sizeof(fieldSize));
        out.write(mobilePhone.c_str(), fieldSize);

        fieldSize = additionalInfo.size();
        out.write(reinterpret_cast<const char*>(&fieldSize), sizeof(fieldSize));
        out.write(additionalInfo.c_str(), fieldSize);
    }

    void load(ifstream& in) {
        size_t len;
        in.read(reinterpret_cast<char*>(&len), sizeof(len));
        delete[] fullName;
        fullName = new char[len + 1];
        in.read(fullName, len);
        fullName[len] = '\0';

        size_t fieldSize;
        char* buffer;

        in.read(reinterpret_cast<char*>(&fieldSize), sizeof(fieldSize));
        buffer = new char[fieldSize + 1];
        in.read(buffer, fieldSize);
        buffer[fieldSize] = '\0';
        homePhone = buffer;
        delete[] buffer;

        in.read(reinterpret_cast<char*>(&fieldSize), sizeof(fieldSize));
        buffer = new char[fieldSize + 1];
        in.read(buffer, fieldSize);
        buffer[fieldSize] = '\0';
        workPhone = buffer;
        delete[] buffer;

        in.read(reinterpret_cast<char*>(&fieldSize), sizeof(fieldSize));
        buffer = new char[fieldSize + 1];
        in.read(buffer, fieldSize);
        buffer[fieldSize] = '\0';
        mobilePhone = buffer;
        delete[] buffer;

        in.read(reinterpret_cast<char*>(&fieldSize), sizeof(fieldSize));
        buffer = new char[fieldSize + 1];
        in.read(buffer, fieldSize);
        buffer[fieldSize] = '\0';
        additionalInfo = buffer;
        delete[] buffer;
    }
};


vector<Contact> phonebook;


void addContact() {
    char name[100];
    string home, work, mobile, info;

    cout << "Имя: ";
    cin.ignore();
    cin.getline(name, 100);
    cout << "Домашний телефон: ";
    getline(cin, home);
    cout << "Рабочий телефон: ";
    getline(cin, work);
    cout << "Мобильный телефон: ";
    getline(cin, mobile);
    cout << "Доп информация: ";
    getline(cin, info);

    phonebook.emplace_back(name, home, work, mobile, info);
    cout << "Контакт добавлен" << endl;
}


void showAll() {
    if (phonebook.empty()) {
        cout << "Книга пуста." << endl;
        return;
    }
    for (const auto& c : phonebook) {
        c.display();
    }
}


void searchContact() {
    string query;
    cout << "Введите полное имя для поиска: ";
    cin.ignore();
    getline(cin, query);
    bool found = false;

    for (const auto& c : phonebook) {
        if (query == c.getFullName()) {
            c.display();
            found = true;
        }
    }

    if (!found) {
        cout << "Нет контактов с именем: " << query << endl;
    }
}


void deleteContact() {
    string query;
    cout << "Введите полное имя для удаления: ";
    cin.ignore();
    getline(cin, query);
    bool found = false;

    for (auto it = phonebook.begin(); it != phonebook.end(); ++it) {
        if (query == it->getFullName()) {
            phonebook.erase(it);
            cout << "Контакт удален" << endl;
            found = true;
            break;
        }
    }

    if (!found) {
        cout << "Нет контактов с именем: " << query << endl;
    }
}


void saveToFile(const string& filename) {
    ofstream out(filename, ios::binary);
    if (!out) {
        cout << "Не удалось открыть файл" << endl;
        return;
    }

    size_t size = phonebook.size();
    out.write(reinterpret_cast<char*>(&size), sizeof(size));
    for (const auto& c : phonebook) {
        c.save(out);
    }

    out.close();
    cout << "Сохранено" << endl;
}


void loadFromFile(const string& filename) {
    ifstream in(filename, ios::binary);
    if (!in) {
        cout << "Нет сохраненных данных" << endl;
        return;
    }

    phonebook.clear();
    size_t size;
    in.read(reinterpret_cast<char*>(&size), sizeof(size));
    for (size_t i = 0; i < size; ++i) {
        Contact c;
        c.load(in);
        phonebook.push_back(c);
    }

    in.close();
    cout << "Данные загружены." << endl;
}

void menu() {
    int choice;
    string filename = "phonebook.dat";

    do {
        cout << "\nМеню:" << endl;
        cout << "1. Добавить контакт" << endl;
        cout << "2. Показать все контакты" << endl;
        cout << "3. Поиск" << endl;
        cout << "4. Удаление" << endl;
        cout << "5. Сохранение в файл" << endl;
        cout << "6. Загрузка из файл" << endl;
        cout << "0. Выход" << endl;
        cout << "Выбор: " << endl;
        cin >> choice;

        switch (choice) {
            case 1: addContact(); break;
            case 2: showAll(); break;
            case 3: searchContact(); break;
            case 4: deleteContact(); break;
            case 5: saveToFile(filename); break;
            case 6: loadFromFile(filename); break;
            case 0: cout << "Выход.." << endl; break;
            default: cout << "Неверный выбор" << endl; break;
        }

    } while (choice != 0);
}

int main() {
    setlocale(LC_ALL, "");

    menu();

    return 0;
}