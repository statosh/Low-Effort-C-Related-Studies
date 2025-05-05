#include <iostream>
#include <cstring>
#include "task3.h"

// ������ 1: ��������� this - ��� ��������� �� ������� ������ � ������� ������.
// �� ������������ ��� ������� � ������ ������ � ���������� ����� ����������� ������ � ������-�������.
// 
// ������ 2: ����������� ����������� ������� ����� ������ ��� ����� �������������. 
// �������: ��������� ���� �������� - ������ �� ������ ���� �� ������, �������������� ���� ������ ������� ���������� ����� �������������.
// 
// ������ 3: ����������� ����������� ����� ��� ����������� ����������� ��������, ���������� ����������� ���������� �������. 
// ���������� ��� �������� ������� �� ��������, �������� �� ������� � ������������� ������ ������� ������.
// 
// ������ 4: ���� �� ���������� ����������� ����������� ����, ���������� ������� ��� �������������, ����������� ��������� ����������� �����.
// 
// ������ 5: ��� ������������ ������� ������������ ������ ���������������� ������ ����������, � ��� ����������� ��������� ����� ������. 
// ������������ ����������������, ����� ������ ��� ����������.

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

    std::cout << "������ ������ str1: " << str1.size() << std::endl;
    std::cout << "������ ������ str2: " << str2.size() << std::endl;

    str2 += " World";

    std::cout << "����� ������ str2: " << str2.getString() << std::endl;
}