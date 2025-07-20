#include <unordered_set>
#include <stdexcept>

template <typename T>
class Queue {
private:
    class Node {
    public:
        T data;
        Node* prev;
        Node* next;
        Node(const T& data) : data(data), prev(nullptr), next(nullptr) {}
    };

    Node* head;
    Node* tail;
    size_t queueSize;

    void clear();

public:
    Queue();
    Queue(const Queue& other);
    ~Queue();

    void enqueue(const T& value);
    void dequeue();
    T& front();
    const T& front() const;
    bool empty() const;
    size_t size() const;

    Queue<T>* clone() const;             // Клонирование
    Queue<T> operator+(const Queue<T>& other) const;  // Объединение
    Queue<T> operator*(const Queue<T>& other) const;  // Пересечение
};

// Реализация методов
template <typename T>
Queue<T>::Queue() : head(nullptr), tail(nullptr), queueSize(0) {}

template <typename T>
Queue<T>::Queue(const Queue& other) : head(nullptr), tail(nullptr), queueSize(0) {
    Node* current = other.head;
    while (current) {
        enqueue(current->data);
        current = current->next;
    }
}

template <typename T>
Queue<T>::~Queue() {
    clear();
}

template <typename T>
void Queue<T>::clear() {
    while (!empty()) {
        dequeue();
    }
}

template <typename T>
void Queue<T>::enqueue(const T& value) {
    Node* newNode = new Node(value);
    if (empty()) {
        head = tail = newNode;
    }
    else {
        tail->next = newNode;
        newNode->prev = tail;
        tail = newNode;
    }
    queueSize++;
}

template <typename T>
void Queue<T>::dequeue() {
    if (empty()) {
        throw std::out_of_range("Ошибка: очередь пуста!");
    }
    Node* temp = head;
    head = head->next;
    if (head) {
        head->prev = nullptr;
    }
    else {
        tail = nullptr;
    }
    delete temp;
    queueSize--;
}

template <typename T>
T& Queue<T>::front() {
    if (empty()) {
        throw std::out_of_range("Ошибка: очередь пуста!");
    }
    return head->data;
}

template <typename T>
const T& Queue<T>::front() const {
    if (empty()) {
        throw std::out_of_range("Ошибка: очередь пуста!");
    }
    return head->data;
}

template <typename T>
bool Queue<T>::empty() const {
    return head == nullptr;
}

template <typename T>
size_t Queue<T>::size() const {
    return queueSize;
}

template <typename T>
Queue<T>* Queue<T>::clone() const {
    Queue<T>* newQueue = new Queue<T>();
    Node* current = head;
    while (current) {
        newQueue->enqueue(current->data);
        current = current->next;
    }
    return newQueue;
}

template <typename T>
Queue<T> Queue<T>::operator+(const Queue<T>& other) const {
    Queue<T> result;
    Node* current = this->head;
    while (current) {
        result.enqueue(current->data);
        current = current->next;
    }
    current = other.head;
    while (current) {
        result.enqueue(current->data);
        current = current->next;
    }
    return result;
}

template <typename T>
Queue<T> Queue<T>::operator*(const Queue<T>& other) const {
    Queue<T> result;
    std::unordered_set<T> elements;
    Node* current = other.head;
    while (current) {
        elements.insert(current->data);
        current = current->next;
    }
    current = this->head;
    while (current) {
        if (elements.find(current->data) != elements.end()) {
            result.enqueue(current->data);
        }
        current = current->next;
    }
    return result;
}