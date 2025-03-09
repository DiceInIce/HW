#include <iostream>

using namespace std;

int main()
{
    setlocale(LC_ALL, "");

    const char* path1 = "txtFile1.txt";
    const char* path2 = "txtFile2.txt";

    FILE* txtFile1;
    FILE* txtFile2;

    if (fopen_s(&txtFile1, path1, "r") != 0) {
        cout << "Ошибка в открытии 1ого файла";
        return 0;
    }

    if (fopen_s(&txtFile2, path2, "r") != 0) {
        cout << "Ошибка в открытии 2ого файла";
        fclose(txtFile1);
        return 0;
    }

    char line1[128];
    char line2[128];
    int lineNum = 0;
    bool identical = true;

    while (true) {
        char* read1 = fgets(line1, sizeof(line1), txtFile1);
        char* read2 = fgets(line2, sizeof(line2), txtFile2);
        lineNum++;

        if (!read1 && !read2) break;

        if ((read1 && read2 && strcmp(line1, line2) != 0) || (read1 && !read2) || (!read1 && read2)) {
            cout << "Различия в строке - " << lineNum << endl;
            cout << "Файл 1: " << (read1 ? line1 : "конец файла") << endl;
            cout << "Файл 2: " << (read2 ? line2 : "конец файла") << endl << endl;
            identical = false;
        }
    }

    if (identical) cout << "Файлы одинаковые";

    fclose(txtFile1);
    fclose(txtFile2);

    return 0;
}