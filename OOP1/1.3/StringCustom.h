#pragma once
#include <iostream>
#include<cstring>

using namespace std;

class StringCustom
{
	char* str;
	size_t lenght;

	StringCustom& operator=(const StringCustom&);

public:

	StringCustom();
	StringCustom(size_t);
	StringCustom(const char*);
	StringCustom(const StringCustom&);

	void input();
	void display();

	~StringCustom();
};

