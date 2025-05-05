#include <iostream>
#include "task5.h"

// ������ 1: �������� ����� explicit ����� ������������� ������������� ������� �������������� �����. 
// ������ �������� �������������� ������ ������������ ��� �������� ���������.
// 
// ������ 2: ������������� ������������, ����� ����������� ��������� ���� �������� � �������������� ����� ���� ����������������.
// 
// ������ 3: ��, ����� ��������� ��������� ����������. 
// ������: explicit Fraction(int num, int denom) : numerator(num), denominator(denom) {}
// 
// ������ 4: ������� explicit ��������� ������� �������������� �����, ������� ������ ������ ������������.
// 
// ������ 5: ����� ����������� ������� ������ �������� ����, ���������������, ����� ���������� ����� ������� ��������������. 
// ������� ����������� ���������� �������������, ���������������, ����� �������������� �������� � ���������.

class Fraction {
private:
    int numerator, denominator;

    int gcd(int a, int b) {
        while (b != 0) {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

public:
    explicit Fraction(int num, int denom) : numerator(num), denominator(denom) {
        simplify();
    }

    void simplify() {
        int gcdValue = gcd(numerator, denominator);
        numerator /= gcdValue;
        denominator /= gcdValue;
    }

    friend std::ostream& operator<<(std::ostream& os, const Fraction& f) {
        os << f.numerator << "/" << f.denominator;
        return os;
    }
};

void task5() {
    Fraction f1(3, 5);
    Fraction f2(6, 15);

    f2.simplify();

    std::cout << "f1: " << f1 << std::endl;
    std::cout << "��������� f2: " << f2 << std::endl;
}