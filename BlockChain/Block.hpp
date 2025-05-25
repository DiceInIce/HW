#pragma once
#include <iostream>
#include <string>
#include <sstream>
#include <vector>
#include "Transaction.hpp"

using namespace std;

class Block {
public:
	string previousHash; // Хэш предыдущего блока
	vector<Transaction> transactions; // Данные содержащиеся в блоке
	string hash; // Текущий хэш блока 
	time_t timestamp; // Временная отметка блока (когда добыт блок)
	int nonce; // Число подбирамое для майнинга
	string merkeleRoot; //Корень древа Меркела для транзакций

	Block(vector<Transaction> transactions, string previousHash);


	//Вычисление хэша блока с учетом nonce
	string calculateHash() const;

	string calculateMerkelRoot() const;

	//Метод "майнинга" блока - находит хэш, начинайющийся с определенного количества нулей
	void mineBLock(int difficulty);


private:

};