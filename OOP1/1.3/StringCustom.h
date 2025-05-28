#pragma once
#include <iostream>
#include<cstring>

using namespace std;

class StringCustom
{
	char* str;
	size_t lenght;

	static int objectCount;

	

public:

	StringCustom();
	StringCustom(size_t);
	StringCustom(const char*);
	StringCustom(const StringCustom&);
	StringCustom& operator=(const StringCustom&);

	void input();
	void display();
	static int getObjectCount();


	~StringCustom();
};

