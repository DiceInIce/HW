#include <stdexcept>
#include <iostream>

using namespace std;

template <typename T>
class Array {
private:
    struct Node {
        T data;
        Node* prev;
        Node* next;
        Node(const T& val) : data(val), prev(nullptr), next(nullptr) {}
    };

    Node* head;
    Node* tail;
    int capacity;     // Выделенная память
    int count;        // Фактическое количество элементов
    int growSize;     // Шаг увеличения массива

    void expandCapacity(int newCapacity);
    Node* getNodeAt(int index) const;

public:
    Array();
    Array(int initialSize, int grow = 1);
    Array(const Array& other);
    ~Array();

    int GetSize() const;
    void SetSize(int size, int grow = 1);
    int GetUpperBound() const;
    bool IsEmpty() const;
    void FreeExtra();
    void RemoveAll();
    T GetAt(int index) const;
    void SetAt(int index, const T& value);
    T& operator[](int index);
    const T& operator[](int index) const;
    int Add(const T& value);
    void Append(const Array& other);
    Array& operator=(const Array& other);
    T* GetData() const;
    void InsertAt(int index, const T& value);
    void RemoveAt(int index, int count = 1);
    void Show() const;
};

template <typename T>
Array<T>::Array() : head(nullptr), tail(nullptr), capacity(0), count(0), growSize(1) {}

template <typename T>
Array<T>::Array(int initialSize, int grow) : head(nullptr), tail(nullptr), capacity(0), count(0), growSize(grow) {
    SetSize(initialSize);
}

template <typename T>
Array<T>::Array(const Array& other) : head(nullptr), tail(nullptr), capacity(0), count(0), growSize(other.growSize) {
    *this = other;
}

template <typename T>
Array<T>::~Array() {
    RemoveAll();
}

template <typename T>
void Array<T>::expandCapacity(int newCapacity) {
    if (newCapacity <= capacity) return;

    capacity = newCapacity;
}

template <typename T>
typename Array<T>::Node* Array<T>::getNodeAt(int index) const {
    if (index < 0 || index >= count) {
        throw out_of_range("Index out of range");
    }

    Node* current = head;
    for (int i = 0; i < index; ++i) {
        current = current->next;
    }
    return current;
}

template <typename T>
int Array<T>::GetSize() const {
    return capacity;
}

template <typename T>
void Array<T>::SetSize(int size, int grow) {
    if (size < 0) {
        throw invalid_argument("Size cannot be negative");
    }

    growSize = grow;

    if (size < count) {
        for (int i = count - 1; i >= size; --i) {
            RemoveAt(i);
        }
    }

    capacity = size;
}

template <typename T>
int Array<T>::GetUpperBound() const {
    return count - 1;
}

template <typename T>
bool Array<T>::IsEmpty() const {
    return count == 0;
}

template <typename T>
void Array<T>::FreeExtra() {
    capacity = count;
}

template <typename T>
void Array<T>::RemoveAll() {
    while (head) {
        Node* temp = head;
        head = head->next;
        delete temp;
    }
    tail = nullptr;
    count = 0;
    capacity = 0;
}

template <typename T>
T Array<T>::GetAt(int index) const {
    return (*this)[index];
}

template <typename T>
void Array<T>::SetAt(int index, const T& value) {
    (*this)[index] = value;
}

template <typename T>
T& Array<T>::operator[](int index) {
    Node* node = getNodeAt(index);
    return node->data;
}

template <typename T>
const T& Array<T>::operator[](int index) const {
    Node* node = getNodeAt(index);
    return node->data;
}

template <typename T>
int Array<T>::Add(const T& value) {
    if (count >= capacity) {
        SetSize(capacity + growSize, growSize);
    }

    Node* newNode = new Node(value);
    if (!head) {
        head = tail = newNode;
    }
    else {
        tail->next = newNode;
        newNode->prev = tail;
        tail = newNode;
    }
    count++;
    return count - 1;
}

template <typename T>
void Array<T>::Append(const Array& other) {
    Node* current = other.head;
    while (current) {
        Add(current->data);
        current = current->next;
    }
}

template <typename T>
Array<T>& Array<T>::operator=(const Array& other) {
    if (this == &other) {
        return *this;
    }

    RemoveAll();
    growSize = other.growSize;
    capacity = other.capacity;

    Node* current = other.head;
    while (current) {
        Add(current->data);
        current = current->next;
    }

    return *this;
}

template <typename T>
T* Array<T>::GetData() const {
    if (count == 0) return nullptr;

    T* array = new T[count];
    Node* current = head;
    for (int i = 0; i < count; ++i) {
        array[i] = current->data;
        current = current->next;
    }
    return array;
}

template <typename T>
void Array<T>::InsertAt(int index, const T& value) {
    if (index < 0 || index > count) {
        throw out_of_range("Index out of range");
    }

    if (index == count) {
        Add(value);
        return;
    }

    if (count >= capacity) {
        SetSize(capacity + growSize, growSize);
    }

    Node* newNode = new Node(value);
    if (index == 0) {
        newNode->next = head;
        if (head) head->prev = newNode;
        head = newNode;
        if (!tail) tail = newNode;
    }
    else {
        Node* current = getNodeAt(index);
        newNode->prev = current->prev;
        newNode->next = current;
        current->prev->next = newNode;
        current->prev = newNode;
    }
    count++;
}

template <typename T>
void Array<T>::RemoveAt(int index, int cnt) {
    if (index < 0 || index >= count || cnt <= 0) {
        throw out_of_range("Invalid index or count");
    }

    if (index + cnt > count) {
        cnt = count - index;
    }

    for (int i = 0; i < cnt; ++i) {
        Node* toDelete = getNodeAt(index);

        if (toDelete->prev) {
            toDelete->prev->next = toDelete->next;
        }
        else {
            head = toDelete->next;
        }

        if (toDelete->next) {
            toDelete->next->prev = toDelete->prev;
        }
        else {
            tail = toDelete->prev;
        }

        delete toDelete;
        count--;
    }
}

template <typename T>
void Array<T>::Show() const {
    Node* current = head;
    cout << "Массив (выделено памяти: " << capacity << ", элементов: " << count << "): [";
    for (int i = 0; i < count; ++i) {
        cout << current->data;
        if (i < count - 1) cout << ", ";
        current = current->next;
    }
    cout << "]" << endl;
}