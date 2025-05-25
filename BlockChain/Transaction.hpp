#pragma once
#include <string>
#include<ctime>
#include <sstream>

using namespace std;

class Transaction
{
public:
	string sender; // Отправитель 
	string receiver; // Получатель
	double ammount; // Сумма
	time_t timestamp; // Временная метка
	string hash; // Хэш транзакции

	Transaction(string sender, string receiver, double ammount);
	string calculateHash() const;
	void printTransaction() const;
};

