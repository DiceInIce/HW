#include <iostream>
#include "BlockChain.hpp"

using namespace std;

int main()
{
	setlocale(LC_ALL, "");

	BlockChain myBlockChain; // Создаем блокчейн

	myBlockChain.addTransaction(Transaction("miner", "alice", 200));
	myBlockChain.addTransaction(Transaction("miner", "bob", 200));
	myBlockChain.addTransaction(Transaction("alice", "bob", 15));
	myBlockChain.addTransaction(Transaction("bob", "alice", 10));

	cout << endl << "Mining block with pending transaction..." << endl;
	myBlockChain.minePendingTransaction("miner");

	cout << endl << "Blockchain: " << endl;
	myBlockChain.printChain();

	cout << endl << "Balances: " << endl;
	cout << "miner ->" << myBlockChain.getBalance("miner") << endl;
	cout << "alice ->" << myBlockChain.getBalance("alice") << endl;
	cout << "bob ->" << myBlockChain.getBalance("bob") << endl;

	cout << "Is blockchain valid?: " << (myBlockChain.isChainValid() ? "Yes" : "No") << endl;

	return 0;
}