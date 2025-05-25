#pragma once
#include <vector>
#include "Block.hpp"
#include <map>

using namespace std;

// Класс представления всей цепочки блоков
class BlockChain
{


public:
	BlockChain();
	// Добавление транзакций для дальнейшего майнинга
	void addTransaction(Transaction tx);

	// Майнинг блока с ожидающими транзакциями
	void minePendingTransactions(string minerAddress);

	// Получение баланса кошелька
	double getBalance(string address);

	void printChain() const;

	// Проверка целостности блокчейна
	bool isChainValid() const;


private:
	vector<Block> chain;	// Вектор блоков
	int difficulty;			// Уровень сложности майнинга
	map<string, double> balances; //Баланс пользователей
	vector<Transaction> pendingTransactions; // Очередь транзакций

private:
	// Создание генезис-блока (т.е. самомый первый блок)
	void createBlock(vector<Transaction> transactions);

	// Получение последнего блока цепочки
	Block getLastestBlock() const;

	// Добавление нового блока к цепочке
	void addBlock(Block newBlock);


};