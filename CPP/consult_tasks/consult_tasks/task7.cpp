#include <iostream>
#include "task7.h"

// ������ 1: ������ ������ � C++ - ��� �����, ������� ����� �������� � ���������� ������ ������.
// ������� ������������ ��� �������� ������������� ������� � �������.
//
// ������ 2: ������������: ��������� ������������� ����, ������������ �����.
// ����������: ���������� ������� ������������ �����, ��������� �������.
//
// ������ 3: ���� ����������: ���� ������ (��������, T), �������� (��������, int N), ������� (��������, template <template <typename> class TContainer>).
//
// ������ 4: ��, ����� ���������������� ������� �������.
// ������: template <> class Stack<char> { /* ������������� ��� char */ };
//
// ������ 5: ������ ����������, ���� ��� �� ������������ ����������� ��������. ���������� ����� �������������� ������� ��� ��������� �����.

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
            std::cerr << "���� ����������!" << std::endl;
            return;
        }
        data[topIndex++] = item;
    }

    T pop() {
        if (isEmpty()) {
            std::cerr << "���� ����!" << std::endl;
            throw std::out_of_range("���� ����");
        }
        return data[--topIndex];
    }

    T top() const {
        if (isEmpty()) {
            std::cerr << "���� ����!" << std::endl;
            throw std::out_of_range("���� ����");
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
    std::cout << "������� ������� �����: " << intStack.top() << std::endl;

    doubleStack.push(1.5);
    doubleStack.push(2.5);
    if (!doubleStack.isEmpty()) {
        std::cout << "������ ������� �����: " << doubleStack.pop() << std::endl;
    }
}