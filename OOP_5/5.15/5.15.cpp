#include <iostream>
#include "Stack.hpp"

using namespace std;

int main()
{
    setlocale(LC_ALL, "");

    Stack<int> stack1;
    stack1.push(1);
    stack1.push(2);
    stack1.push(3);

    Stack<int> stack2;
    stack2.push(3);
    stack2.push(4);
    stack2.push(5);

    // Клонирование
    Stack<int>* clonedStack = stack1.clone();
    cout << "Клонированный стек: ";
    while (!clonedStack->empty()) {
        cout << clonedStack->top() << " ";
        clonedStack->pop();
    }
    delete clonedStack;
    cout << endl;

    // Объединение (+)
    Stack<int> combined = stack1 + stack2;
    cout << "Объединенный стек: ";
    while (!combined.empty()) {
         cout << combined.top() << " ";
        combined.pop();
    }
    cout << endl;

    // Пересечение (*)
    Stack<int> intersection = stack1 * stack2;
     cout << "Пересечение стеков: ";
    while (!intersection.empty()) {
         cout << intersection.top() << " ";
        intersection.pop();
    }
     cout << endl;

    return 0;
}