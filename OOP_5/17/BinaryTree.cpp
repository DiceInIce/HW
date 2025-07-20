#include "BinaryTree.hpp"
#include <iostream>
#include <algorithm>

GAI_Database::GAI_Database() : root(nullptr) {}

GAI_Database::~GAI_Database() {
    clear(root);
}

void GAI_Database::clear(TreeNode* node) {
    if (node) {
        clear(node->left);
        clear(node->right);
        delete node;
    }
}

GAI_Database::TreeNode* GAI_Database::insert(TreeNode* node, const string& carNumber) {
    if (!node) {
        return new TreeNode(carNumber);
    }

    if (carNumber < node->carNumber) {
        node->left = insert(node->left, carNumber);
    }
    else if (carNumber > node->carNumber) {
        node->right = insert(node->right, carNumber);
    }

    return node;
}

GAI_Database::TreeNode* GAI_Database::find(TreeNode* node, const string& carNumber) const {
    if (!node || node->carNumber == carNumber) {
        return node;
    }

    return carNumber < node->carNumber ? find(node->left, carNumber) : find(node->right, carNumber);
}

void GAI_Database::addViolation(const string& carNumber, const TrafficViolation& violation) {
    TreeNode* node = find(root, carNumber);
    if (!node) {
        root = insert(root, carNumber);
        node = find(root, carNumber);
    }
    node->violations.push_back(violation);
}

void GAI_Database::printInOrder(TreeNode* node) const {
    if (node) {
        printInOrder(node->left);
        cout << "\nНомер автомобиля: " << node->carNumber << endl;
        cout << "Нарушения (" << node->violations.size() << "):" << endl;
        for (const auto& violation : node->violations) {
            violation.print();
        }
        printInOrder(node->right);
    }
}

void GAI_Database::printRange(TreeNode* node, const string& start, const string& end) const {
    if (node) {
        if (start < node->carNumber) {
            printRange(node->left, start, end);
        }

        if (start <= node->carNumber && node->carNumber <= end) {
            cout << "\nНомер автомобиля: " << node->carNumber << endl;
            cout << "Нарушения (" << node->violations.size() << "):" << endl;
            for (const auto& violation : node->violations) {
                violation.print();
            }
        }

        if (node->carNumber < end) {
            printRange(node->right, start, end);
        }
    }
}

void GAI_Database::printAll() const {
    cout << "=== Полная база данных ГАИ ===" << endl;
    printInOrder(root);
    cout << "============================" << endl;
}

void GAI_Database::printByNumber(const string& carNumber) const {
    TreeNode* node = find(root, carNumber);
    if (node) {
        cout << "\nНарушения для автомобиля " << carNumber << ":" << endl;
        for (const auto& violation : node->violations) {
            violation.print();
        }
    }
    else {
        cout << "Автомобиль с номером " << carNumber << " не найден в базе." << endl;
    }
}

void GAI_Database::printByRange(const string& start, const string& end) const {
    cout << "=== Нарушения для номеров с " << start << " по " << end << " ===" << endl;
    printRange(root, start, end);
    cout << "=================================" << endl;
}