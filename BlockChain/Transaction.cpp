#include "Transaction.hpp"
#include "SHA256.hpp"
#include <iostream>

Transaction::Transaction(string sender, string receiver, double ammount) :
	sender(sender),
	receiver(receiver),
	ammount(ammount),
	timestamp(time(nullptr)) {
	hash = calculateHash();
}

string Transaction::calculateHash() const {
	stringstream ss;
	ss << sender << receiver << ammount << timestamp;
	return SHA256::hash(ss.str());
}

void Transaction::printTransaction() const {
	cout << "_________________________________________________" << endl;
	cout << "\tTransaction: " << hash << endl;
	cout << "\tSender: " << sender << endl;
	cout << "\tReceiver: " << receiver << endl;
	cout << "\tAmmount: " << ammount << endl;
	cout << "\tTimestamp: " << timestamp << endl;
}