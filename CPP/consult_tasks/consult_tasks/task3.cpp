#include <iostream>
#include <cstring>
#include "task3.h"

// Вопрос 1: Указатель this - это указатель на текущий объект в методах класса.
// Он используется для доступа к членам класса и различения между параметрами метода и полями-членами.
// 
// Вопрос 2: Конструктор копирования создает новый объект как копию существующего. 
// Правила: принимает один параметр - ссылку на объект того же класса, инициализирует поля нового объекта значениями полей существующего.
// 
// Вопрос 3: Конструктор копирования нужен для корректного копирования объектов, содержащих динамически выделенные ресурсы. 
// Вызывается при передаче объекта по значению, возврате из функции и инициализации одного объекта другим.
// 
// Вопрос 4: Если не определить конструктор копирования явно, компилятор создаст его автоматически, выполняющий побитовое копирование полей.
// 
// Вопрос 5: При присваивании объекта существующий объект перезаписывается новыми значениями, а при копировании создается новый объект. 
// Присваивание предпочтительнее, когда объект уже существует.

class StringBuffer {
private:
    char* buffer;
    size_t length;

public:
    StringBuffer() : buffer(new char[1]), length(0) {
        buffer[0] = '\0';
    }

    StringBuffer(const char* str) : length(strlen(str)) {
        buffer = new char[length + 1];
        strcpy_s(buffer, length + 1, str);
    }

    StringBuffer(const StringBuffer& other) : length(other.length) {
        buffer = new char[length + 1];
        strcpy_s(buffer, length + 1, other.buffer);
    }

    ~StringBuffer() {
        delete[] buffer;
    }

    StringBuffer& operator=(const StringBuffer& other) {
        if (this != &other) {
            delete[] buffer;
            length = other.length;
            buffer = new char[length + 1];
            strcpy_s(buffer, length + 1, other.buffer);
        }
        return *this;
    }

    StringBuffer& operator+=(const char* str) {
        size_t newLength = length + strlen(str);
        char* newBuffer = new char[newLength + 1];
        strcpy_s(newBuffer, newLength + 1, buffer);
        strcat_s(newBuffer, newLength + 1, str);
        delete[] buffer;
        buffer = newBuffer;
        length = newLength;
        return *this;
    }

    size_t size() const {
        return length;
    }

    const char* getString() const {
        return buffer;
    }
};

void task3() {
    StringBuffer str1("Hello");
    StringBuffer str2(str1);

    std::cout << "Размер строки str1: " << str1.size() << std::endl;
    std::cout << "Размер строки str2: " << str2.size() << std::endl;

    str2 += " World";

    std::cout << "Новая строка str2: " << str2.getString() << std::endl;
}