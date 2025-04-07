#include <iostream>
#include "task6.h"

// ������ 1: ���������� ���������� � C++ ��������� ���������� ���������������� ��������� ����������� ���������� ��� ����� �������.
// 
// ������ 2: ����� ����������� ����������� ����������, ����� ��������� ���������. 
// �������: +, -, *, /, [], <<, >>.
// 
// ������ 3: ���������� ������� ����� ���� ������ ������ � �������� ������ � ��� ��������� ������, � �� ����� ��� ���� ������ ����� ������ ������ � ����� ��������.
// 
// ������ 4: ���������� operator[] ������ ���������� ������ �� ������� ����������, ��� ��������� ��� ������, ��� � ���������� ��������. 
// ������: T& operator[](size_t index) { return data[index]; }
// 
// ������ 5: ���������� operator<< ��������� ����������, ��� ������ ����� ���������� � �����. 
// ������: friend std::ostream& operator<<(std::ostream& os, const MyClass& obj) { os << obj.value; return os; }

class ComplexNumber {
private:
    double real, imag;

public:
    ComplexNumber(double r, double i) : real(r), imag(i) {}

    ComplexNumber operator+(const ComplexNumber& other) const {
        return ComplexNumber(real + other.real, imag + other.imag);
    }

    ComplexNumber operator-(const ComplexNumber& other) const {
        return ComplexNumber(real - other.real, imag - other.imag);
    }

    ComplexNumber operator*(const ComplexNumber& other) const {
        return ComplexNumber(real * other.real - imag * other.imag, real * other.imag + imag * other.real);
    }

    friend std::ostream& operator<<(std::ostream& os, const ComplexNumber& c) {
        os << "(" << c.real << " + " << c.imag << "i)";
        return os;
    }
};

void task6() {
    ComplexNumber c1(1, 2);
    ComplexNumber c2(3, 4);

    ComplexNumber sum = c1 + c2;
    ComplexNumber diff = c1 - c2;
    ComplexNumber prod = c1 * c2;

    std::cout << "�����: " << sum << std::endl;
    std::cout << "��������: " << diff << std::endl;
    std::cout << "������������: " << prod << std::endl;
}