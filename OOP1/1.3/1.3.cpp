#include <iostream>
#include <cstring>
using namespace std;

class String {
private:
    char* str;          
    size_t size;

    static int objectCount;

public:
    
    String() : String(80) {}

    
    String(size_t length) {
        size = length + 1;
        str = new char[size];
        str[0] = '\0';
        objectCount++;
    }

    
    String(const char* input) {
        size = strlen(input) + 1;
        str = new char[size];
        strcpy(str, input);
        objectCount++;
    }

   
    ~String() {
        delete[] str;
        objectCount--;
    }

    
    void input() {
        cout << "Enter string: ";
        cin.ignore();
        cin.getline(str, size);
    }


    void display() const {
        cout << "String: " << str << endl;
    }

    static int getObjectCount() {
        return objectCount;
    }
};

int String::objectCount = 0;

int main() {
    setlocale(LC_ALL, "");

    String s1;
    s1.input();
    s1.display();

    String s2(30);
    s2.input();
    s2.display();

    String s3("Hello, world!");
    s3.display();

    cout << "Всего строк создано: " << String::getObjectCount() << endl;

    return 0;
}