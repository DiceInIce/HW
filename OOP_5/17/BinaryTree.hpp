#include <vector>
#include "TrafficViolation.hpp"

class GAI_Database {
private:
    struct TreeNode {
        string carNumber;
        vector<TrafficViolation> violations;
        TreeNode* left;
        TreeNode* right;

        TreeNode(const string& number)
            : carNumber(number), left(nullptr), right(nullptr) {
        }
    };

    TreeNode* root;

    TreeNode* insert(TreeNode* node, const string& carNumber);
    TreeNode* find(TreeNode* node, const string& carNumber) const;
    void printInOrder(TreeNode* node) const;
    void printRange(TreeNode* node, const string& start, const string& end) const;
    void clear(TreeNode* node);

public:
    GAI_Database();
    ~GAI_Database();

    void addViolation(const string& carNumber, const TrafficViolation& violation);
    void printAll() const;
    void printByNumber(const string& carNumber) const;
    void printByRange(const string& start, const string& end) const;
};
