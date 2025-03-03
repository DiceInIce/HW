#include <iostream>

using namespace std;

int myStrCmp(const char* str1, const char* str2) {
    while (*str1 && (*str1 == *str2)) {
        str1++;
        str2++;
    }
    return (*str1 > *str2) - (*str1 < *str2);
}

int stringToNumber(char *str) {
    return atoi(str);
}

char* numberToString(int num) {
    static char str[12];
    sprintf_s(str, "%d", num);
    return str;
}

char* Uppercase(char* str) {
    for (char* p = str; *p; p++) {
        *p = toupper((unsigned char)*p);
    }
    return str;
}

char* Lowercase(char* str) {
    for (char* p = str; *p; p++) {
        *p = tolower((unsigned char)*p);
    }
    return str;
}

char* myStrRev(char* str) {
    int len = strlen(str);
    for (int i = 0; i < len / 2; i++) {
        char temp = str[i];
        str[i] = str[len - i - 1];
        str[len - i - 1] = temp;
    }
    return str;
}

int main()
{
    setlocale(LC_ALL, "");

    char str1[] = "Кошка";
    char str2[] = "Собака";
    char str3[] = "1234";
    int num = 65546;

    cout << myStrCmp(str1, str2) << endl;

    cout << stringToNumber(str3) << endl;

    cout << numberToString(num) << endl;

    cout << Lowercase(str1) << endl;

    cout << Uppercase(str1) << endl;

    cout << myStrRev(str1) << endl;

    return 0;
}