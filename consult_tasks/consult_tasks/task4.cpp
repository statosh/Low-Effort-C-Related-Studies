#include <iostream>
#include <cmath>
#include "task4.h"

// ������ 1: ����������� ����� � C++ - ��� �����, ������� �� �������� ��������� �������. 
// �����������: �� ����� �������� ����-����� ������ (����� mutable), �� ����� �������� ��-����������� ������.
// 
// ������ 2: ����� ��� ����������� ������������ ������ � ������������ ��������� ���������. 
// ������������: ������ ������, ����������� �������� ����� ������ ��� ����������� ��������.
// 
// ������ 3: ���, ����������� ������ �� ����� �������� ��������� �������, ��� ��� ��� ������������ �� ����������.
// 
// ������ 4: ����������� � �������������� ��������� ����� const ����� ������ ����������. 
// ������: double getArea() const { return width * height; }
// 
// ������ 5: ������������� ������ � ������ const ��������� ��������� ������ �������� ��� ����������� � ������������� ��������. 
// ������: int getValue() const { return value; } � int& getValue() { return value; }

class Point {
private:
    double x, y;

public:
    Point(double x, double y) : x(x), y(y) {}

    double distanceToOrigin() const {
        return std::sqrt(x * x + y * y);
    }

    bool isEqual(const Point& other) const {
        return x == other.x && y == other.y;
    }
};

void task4() {
    Point p1(3, 4);
    Point p2(6, 8);

    double dist1 = p1.distanceToOrigin();
    std::cout << "���������� �� p1 �� ������ ���������: " << dist1 << std::endl;

    bool isEqual = p1.isEqual(p2);
    std::cout << "p1 ����� p2? " << (isEqual ? "��" : "���") << std::endl;
}