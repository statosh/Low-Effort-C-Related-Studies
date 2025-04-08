#include <iostream>
#include "task7.h"

// Вопрос 1: Шаблон класса в C++ - это класс, который может работать с различными типами данных.
// Шаблоны используются для создания универсальных классов и функций.
//
// Вопрос 2: Преимущества: повторное использование кода, безопасность типов.
// Недостатки: увеличение размера исполняемого файла, сложность отладки.
//
// Вопрос 3: Типы параметров: типы данных (например, T), значения (например, int N), шаблоны (например, template <template <typename> class TContainer>).
//
// Вопрос 4: Да, можно специализировать шаблоны классов.
// Пример: template <> class Stack<char> { /* специализация для char */ };
//
// Вопрос 5: Ошибка компиляции, если тип не поддерживает необходимые операции. Избегается явной специализацией шаблона или проверкой типов.

template <typename T>
class Stack {
private:
    T* data;
    size_t capacity;
    size_t topIndex;

public:
    Stack(size_t size) : capacity(size), topIndex(0) {
        data = new T[capacity];
    }

    ~Stack() {
        delete[] data;
    }

    void push(const T& item) {
        if (topIndex >= capacity) {
            std::cerr << "Стек переполнен!" << std::endl;
            return;
        }
        data[topIndex++] = item;
    }

    T pop() {
        if (isEmpty()) {
            std::cerr << "Стек пуст!" << std::endl;
            throw std::out_of_range("Стек пуст");
        }
        return data[--topIndex];
    }

    T top() const {
        if (isEmpty()) {
            std::cerr << "Стек пуст!" << std::endl;
            throw std::out_of_range("Стек пуст");
        }
        return data[topIndex - 1];
    }

    bool isEmpty() const {
        return topIndex == 0;
    }
};

void task7() {
    Stack<int> intStack(5);
    Stack<double> doubleStack(3);

    intStack.push(10);
    intStack.push(20);
    std::cout << "Верхний элемент стека: " << intStack.top() << std::endl;

    doubleStack.push(1.5);
    doubleStack.push(2.5);
    if (!doubleStack.isEmpty()) {
        std::cout << "Первый элемент стека: " << doubleStack.pop() << std::endl;
    }
}