#include "BlockChain.hpp"
#include "Transaction.hpp"

BlockChain::BlockChain() : difficulty(4) {
	Transaction genesisTx("System", "miner", 1000);
	pendingTransactions.push_back(genesisTx);
	createBlock(pendingTransactions);
	pendingTransactions.clear();

}

void BlockChain::createBlock(vector<Transaction> transactions{
	string previousHash = chain.empty() ? "0" : chain.back().hash;
	chain.emplace_back(previousHash, transactions);
	chain.back().mineBLock(difficulty);

	for (const auto& tx : transactions) {
		balances[tx.sender] -= tx.ammount;
		balances[tx.receiver] += tx.ammount;
	}

}


Block BlockChain::getLastestBlock() const {
	return chain.back();
}

void BlockChain::addBlock(Block newBlock{
	newBlock.previousHash = getLastestBlock().hash;
	newBlock.mineBLock(difficulty);

	// ��������� ����� ����
	chain.push_back(newBlock);
}

bool BlockChain::isChainValid() const {
	for (size_t i = 1; i < chain.size(); ++i) {
		const Block& current = chain[i];
		const Block& previous = chain[i - 1];

		// �������� ����������� �������� �����
		if (current.hash != current.calculateHash()){
			cout << "Invalid hash at block " << i << endl;
			return false;
		}
		
		// �������� ������������ ����������� ����
		if (current.previousHash != previous.hash) {
			cout << "Invalid previous hash at block" << i << endl;
			return false;
		}

		if (current.merkeleRoot != current.calculateMerkelRoot()){
			cout << "Invalid Merkele root for block "<< i << endl;
			return false;
		}

		return true;
	}
}

void BlockChain::printChain(const {
	for (size_t i = 0;i < chain.size(); i++) {
		const Block& block = chain[i];
		cout << "Block: " << i << endl;
		cout << "Previous hash: " << block.previousHash << endl;
		cout << "Merkele root: " << block.merkeleRoot << endl;
		cout << "Hash: " << block.hash << endl;
		cout << "Timestamp: " << block.timestamp << endl;
		cout << "Nonce: " << block.nonce << endl;
		cout << "Transactions(" << block.transactions.size() << "):" << endl;

		for (const auto& tx : block.transactions) {
			tx.printTransaction();
		}

		cout << string(40, '-'<< endl;
		
	}
}


void BlockChain::addTransaction(Transaction tx) {
	if (tx.sender != "System" && getBalance(tx.sender> tx.ammount{
		cout << "Transaction failed: insufficien funs" << endl;
		return;
	}

	pendingTransactions.push_back(tx);
	cout << "Transaction added to pending pool" << endl;
}

double BlockChain::getBalance(string address{
	return balances.count(address) ? balances.at(address: 0.0;
}

void BlockChain::minePendingTransaction(string minerAddress{
	Transaction rewardTx("system", minerAddress, 1000);
	pendingTransactions.push_back(rewardTx);

	createBlock(pendingTransactions);
	pendingTransactions.clear();
}