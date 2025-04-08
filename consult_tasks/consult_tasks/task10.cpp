#include <iostream>
#include <stdexcept>
#include "task10.h"

// ������ 1: ����������� ������ � C++ - ��� ������, ������� ����� ���� �������������� � ����������� �������.
// ��� ������������ ��� ���������� ������������.
//
// ������ 2: �������� ����� virtual ��������� ������ ���� ���������������� � ����������� �������.
// ����������� ����� ����� ���� �������������, � ������������� - ���.
//
// ������ 3: ��� ��������������� ����������� ������� � ����������� ������� ���������� ����� ������������ ������
// ��� ��������� ����� ��������� �� ������� �����. ��� ��������� ����������� �����������.
//
// ������ 4: �������� �����: try, catch, throw. try - ���� ����, � ������� ����� ���������� ����������.
// catch - ���� ���� ��� ��������� ����������. throw - ������ ����������.
//
// ������ 5: ������������ ���� � C++ ������������ ��� ����������� ���� � �������������� ���������� ����.
// ������: std::cout.

class Shape {
public:
    virtual void draw() const = 0;
    virtual ~Shape() {}
};

class Circle : public Shape {
private:
    double radius;

public:
    Circle(double r) : radius(r) {
        if (r <= 0) {
            throw std::invalid_argument("������ ������ ���� �������������");
        }
    }

    void draw() const override {
        std::cout << "������ ���� � �������� " << radius << std::endl;
    }
};

class Rectangle : public Shape {
private:
    double width, height;

public:
    Rectangle(double w, double h) : width(w), height(h) {
        if (w <= 0 || h <= 0) {
            throw std::invalid_argument("������ � ������ ������ ���� ��������������");
        }
    }

    void draw() const override {
        std::cout << "������ ������������� � ������� " << width << " � ������� " << height << std::endl;
    }
};

void task10() {
    Shape* shapes[2];
    try {
        shapes[0] = new Circle(5);
        shapes[1] = new Rectangle(3, 4);
    } catch (const std::invalid_argument& e) {
        std::cerr << "������ �������� ������: " << e.what() << std::endl;
        return;
    }

    for (auto shape : shapes) {
        try {
            shape->draw();
        } catch (std::exception& e) {
            std::cerr << "������: " << e.what() << std::endl;
        }
    }

    delete shapes[0];
    delete shapes[1];
}