#include "StringCustom.h"


StringCustom::StringCustom() : lenght(80) {
	str = new char[lenght + 1];
	str[lenght] = '\0';
	++objectCount;
};

StringCustom::StringCustom(size_t size) : lenght(size) {
	str = new char[lenght + 1];
	str[lenght] = '\0';
	++objectCount;
};

StringCustom::StringCustom(const char* s) {
	lenght = strlen(s);
	str = new char[lenght + 1];
	strcpy_s(str, lenght + 1, s);
	++objectCount;
}

StringCustom::StringCustom(const StringCustom& other) {
	lenght = other.lenght;
	str = new char[lenght + 1];
	strcpy_s(str, lenght + 1, other.str);
	++objectCount;
};

void StringCustom::input() {
	cout << "¬ведите строку: ";
	cin.getline(str, lenght + 1);
};

void StringCustom::display() {
	cout << str;
};

StringCustom& StringCustom::operator=(const StringCustom& other) {
	if (this != &other) {
		delete[] str;
		lenght = other.lenght;
		str = new char[lenght + 1];
		strcpy_s(str, lenght + 1, other.str);
	}
	return *this;
};

StringCustom::~StringCustom() {
	delete[] str;
	--objectCount;
};

int StringCustom::getObjectCount() {
	return objectCount;
}