#include "Block.hpp"
#include "SHA256.hpp"

Block::Block(vector<Transaction> transactions, string previousHash) : transactions(transactions), previousHash(previousHash), timestamp(time(nullptr)), nonce(0) {
	hash = calculateHash();
	merkeleRoot = calculateMerkelRoot();
}

string Block::calculateHash() const {
	stringstream ss;
	ss << previousHash << merkeleRoot << timestamp << nonce;
	return SHA256::hash(ss.str());
}

void Block::mineBLock(int difficulty) {
	string target(difficulty, '0');

	while (hash.substr(0, difficulty) != target) {
		++nonce;
		hash = calculateHash(); // Обновляем хэш
	}
	cout << "Block mined: " << hash << endl;


}

string Block::calculateMerkelRoot() const {
	if (transactions.empty()) return SHA256::hash("");

	vector<string> tree;

	for (const auto& tx : transactions) {
		tree.push_back(tx.hash);
	}

	size_t levelOffset = 0;

	for (size_t levelSize = transactions.size(); levelSize > 1; levelSize = (levelSize + 1) / 2) {

		for (size_t left = 0; left < levelSize; left += 2) {
			size_t right = min(left + 1, levelSize - 1);
			tree.push_back(SHA256::hash(tree[levelOffset + left] + tree[levelOffset + right]));
		}
		levelOffset += levelSize;
	}
	
	return tree.empty() ? "" : tree.back();
}