#include <unordered_set>
#include <stdexcept>

template <typename T>
class Stack {
private:
    class Node {
    public:
        T data;
        Node* next;
        Node(const T& data) : data(data), next(nullptr) {}
    };

    Node* topNode;
    size_t stackSize;

    void clear();

public:
    Stack();
    Stack(const Stack& other);
    ~Stack();

    void push(const T& value);
    void pop();
    T& top();
    const T& top() const;
    bool empty() const;
    size_t size() const;

    Stack<T>* clone() const;
    Stack<T> operator+(const Stack<T>& other) const;
    Stack<T> operator*(const Stack<T>& other) const;
};

// Реализация методов прямо в заголовочном файле (для шаблонных классов это необходимо)
template <typename T>
Stack<T>::Stack() : topNode(nullptr), stackSize(0) {}

template <typename T>
Stack<T>::Stack(const Stack& other) : topNode(nullptr), stackSize(0) {
    Node* current = other.topNode;
    Stack<T> tempStack;
    while (current) {
        tempStack.push(current->data);
        current = current->next;
    }
    while (!tempStack.empty()) {
        this->push(tempStack.top());
        tempStack.pop();
    }
}

template <typename T>
Stack<T>::~Stack() {
    clear();
}

template <typename T>
void Stack<T>::clear() {
    while (!empty()) {
        pop();
    }
}

template <typename T>
void Stack<T>::push(const T& value) {
    Node* newNode = new Node(value);
    newNode->next = topNode;
    topNode = newNode;
    stackSize++;
}

template <typename T>
void Stack<T>::pop() {
    if (empty()) {
        throw std::out_of_range("Ошибка: попытка удаления из пустого стека!");
    }
    Node* temp = topNode;
    topNode = topNode->next;
    delete temp;
    stackSize--;
}

template <typename T>
T& Stack<T>::top() {
    if (empty()) {
        throw std::out_of_range("Ошибка: стек пуст!");
    }
    return topNode->data;
}

template <typename T>
const T& Stack<T>::top() const {
    if (empty()) {
        throw std::out_of_range("Ошибка: стек пуст!");
    }
    return topNode->data;
}

template <typename T>
bool Stack<T>::empty() const {
    return topNode == nullptr;
}

template <typename T>
size_t Stack<T>::size() const {
    return stackSize;
}

template <typename T>
Stack<T>* Stack<T>::clone() const {
    Stack<T>* newStack = new Stack<T>();
    Node* current = topNode;
    Stack<T> tempStack;
    while (current) {
        tempStack.push(current->data);
        current = current->next;
    }
    while (!tempStack.empty()) {
        newStack->push(tempStack.top());
        tempStack.pop();
    }
    return newStack;
}

template <typename T>
Stack<T> Stack<T>::operator+(const Stack<T>& other) const {
    Stack<T> result;
    Stack<T> tempThis, tempOther;

    Node* current = this->topNode;
    while (current) {
        tempThis.push(current->data);
        current = current->next;
    }
    while (!tempThis.empty()) {
        result.push(tempThis.top());
        tempThis.pop();
    }

    current = other.topNode;
    while (current) {
        tempOther.push(current->data);
        current = current->next;
    }
    while (!tempOther.empty()) {
        result.push(tempOther.top());
        tempOther.pop();
    }

    return result;
}

template <typename T>
Stack<T> Stack<T>::operator*(const Stack<T>& other) const {
    Stack<T> result;
    std::unordered_set<T> elements;

    Node* current = other.topNode;
    while (current) {
        elements.insert(current->data);
        current = current->next;
    }

    current = this->topNode;
    while (current) {
        if (elements.find(current->data) != elements.end()) {
            result.push(current->data);
        }
        current = current->next;
    }

    Stack<T> reversedResult;
    while (!result.empty()) {
        reversedResult.push(result.top());
        result.pop();
    }

    return reversedResult;
}
