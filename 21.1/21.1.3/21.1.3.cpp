#include <iostream>
#include <fstream>
#include <string>

using namespace std;

void caesarCipher(const char* inputFile, const char* outputFile, int shift) {

    ifstream in(inputFile); 
    ofstream outFile(outputFile);
    string line;

    if (!in) {
        cerr << "Ошибка при открытии входного файла!" << endl;
        return;
    }

    if (!outFile) {
        cerr << "Ошибка при открытии выходного файла!" << endl;
        in.close();
        return;
    }

    while (getline(in, line)) {
        string encryptedLine = "";
        for (char ch : line) {
            if (isalpha(ch)) {
                char base = islower(ch) ? 'a' : 'A'; // Определяем базу для маленьких или больших букв
                ch = (ch - base + shift) % 26 + base; // Применяем сдвиг в пределах алфавита
            }
            encryptedLine += ch;
        }
        outFile << encryptedLine << endl;
    }

    in.close();
    outFile.close(); 
}

int main()
{
    setlocale(LC_ALL, "");

    int shift;

    cout << "Шифр Цезаря" << endl << endl;
    cout << "Введите желаемый сдвиг по алфавиту : ";
    cin >> shift;

    caesarCipher("txtFile.txt", "resFile.txt", shift);

    cout << "\nЗавершено";

    return 0;
}
