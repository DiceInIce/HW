#include <iostream>
#include "Queue.hpp"

using namespace std;

int main() {
    setlocale(LC_ALL, "");

    Queue<int> q1;
    q1.enqueue(1);
    q1.enqueue(2);
    q1.enqueue(3);

    Queue<int> q2;
    q2.enqueue(3);
    q2.enqueue(4);
    q2.enqueue(5);

    // Клонирование
    Queue<int>* cloned = q1.clone();
    cout << "Клонированная очередь: ";
    while (!cloned->empty()) {
        cout << cloned->front() << " ";
        cloned->dequeue();
    }
    delete cloned;
    cout << endl;

    // Объединение (+)
    Queue<int> combined = q1 + q2;
    cout << "Объединенная очередь: ";
    while (!combined.empty()) {
        cout << combined.front() << " ";
        combined.dequeue();
    }
    cout << endl;

    // Пересечение (*)
    Queue<int> intersection = q1 * q2;
    cout << "Пересечение очередей: ";
    while (!intersection.empty()) {
        cout << intersection.front() << " ";
        intersection.dequeue();
    }
    cout << endl;

    return 0;
}