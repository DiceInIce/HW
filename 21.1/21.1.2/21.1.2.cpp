#include <iostream>
#include <fstream>
#include <cctype>
#include <string>

using namespace std;

bool isVowel(char ch) {
    ch = tolower(static_cast<unsigned char>(ch));
    string vowels = "aeiouаеёиоуыэюя";
    return vowels.find(ch) != string::npos;
}

bool isConsonant(char ch) {
    ch = tolower(static_cast<unsigned char>(ch));
    string consonants = "bcdfghjklmnpqrstvwxyzбвгджзйклмнпрстфхцчшщ";
    return consonants.find(ch) != string::npos;
}

void collectInfo(const char* inputFile, const char* outputFile) {

    ifstream in(inputFile);
    ofstream out(outputFile);

    string line;
    char ch;
    int charCount = 0;
    int lineCount = 0;
    int vowCount = 0;
    int consCount = 0;
    int numCount = 0;

    if (!in) {
        cout << "Ошибка в открытии 1ого файла";
        return;
    }

    if (!out) {
        cout << "Ошибка в открытии 2ого файла";
        in.close();
        return;
    }
    
    while (in.get(ch)) {
        if (!isspace(static_cast<unsigned char>(ch))) charCount++;
        if (isVowel(ch)) vowCount++;
        else if (isConsonant(ch)) consCount++;
        else if (isdigit(static_cast<unsigned char>(ch))) numCount++;
    }

    in.clear();
    in.seekg(0);

    while (getline(in, line)) {
        lineCount++;
    }

    out << "Количество символов: " << charCount << endl;
    out << "Количество строк: " << lineCount << endl;
    out << "Количество гласных: " << vowCount << endl;
    out << "Количество согласных: " << consCount << endl;
    out << "Количество цифр: " << numCount << endl;

    in.close();
    out.close();
}

int main()
{
    setlocale(LC_ALL, "");

    collectInfo("txtFile.txt", "statFile.txt");

    return 0;
}