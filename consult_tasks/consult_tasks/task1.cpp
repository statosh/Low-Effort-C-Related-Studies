#include <iostream>
#include <cmath>
#include "task1.h"

// ������ 1: ����� � C++ - ��� ���������������� ��� ������, ������� ����� ��������� ������ � ������ ��� ������ � ����� �������. 
// �������� ���������� ������: ����-����� (������) � ������-����� (�������).
// 
// ������ 2: ������ ������� � ������: public (�������� ����), protected (�������� ������ ������ � ����������� �������), 
// private (�������� ������ ������ ������). �������: public: int x; protected: int y; private: int z;
// 
// ������ 3: ����������� ������ - ����������� �����, ���������� ��� �������� �������. 
// ����������� �� ��������� �������������� ������ ���������� �� ���������.
// 
// ������ 4: ���������� - ����������� �����, ���������� ��� ����������� �������. 
// �� ��������� ��� ������������ ��������, ���������� � ������������.
// 
// ������ 5: ����-����� ������ ����������� ������� � ���������� � ������� ����� ������� ����� �������. 
// ��������� ���������� ������ ���������� ������ �� ����� ���������� ������.

class Vector2D {
public:
    double x, y;

    Vector2D() : x(0), y(0) {}
    Vector2D(double x, double y) : x(x), y(y) {}

    double length() const {
        return std::sqrt(x * x + y * y);
    }

    void normalize() {
        double len = length();
        if (len != 0) {
            x /= len;
            y /= len;
        }
    }

    Vector2D operator+(const Vector2D& other) const {
        return Vector2D(x + other.x, y + other.y);
    }

    Vector2D operator-(const Vector2D& other) const {
        return Vector2D(x - other.x, y - other.y);
    }

    friend Vector2D operator*(double scalar, const Vector2D& vec) {
        return Vector2D(scalar * vec.x, scalar * vec.y);
    }
};

void task1() {
    Vector2D v1(3, 4);
    Vector2D v2(1, 2);

    std::cout << "����� ������� v1: " << v1.length() << std::endl;
    v1.normalize();
    std::cout << "��������������� ������ v1: (" << v1.x << ", " << v1.y << ")" << std::endl;

    Vector2D v3 = v1 + v2;
    std::cout << "����� �������� v1 � v2: (" << v3.x << ", " << v3.y << ")" << std::endl;
}