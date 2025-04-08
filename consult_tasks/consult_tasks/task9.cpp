#include <iostream>
#include "task9.h"

// ������ 1: ��������� � ��� - ��� ��������� ����� ��������, ��� ������� ���� ����� �������� ������,
// �� ���������� ��������� ������ ����������� �� ����������. ������: ����� Car �������� Engine.
//
// ������ 2: ���������� - ������� ����� ���������, ��� ��������� ���� ����������� ��������� ������� �� ����������� ������.
// ��������� - ������ �����, ��� ���������� ����� ������������ ����������. ����������: Car �������� Engine. ���������: Car �������� Driver.
//
// ������ 3: ������������ - �������� ���, ����������� ��������� ����� ������ �� ������ ������������.
// ����: public, protected, private.
//
// ������ 4: ������������� ������������ ��������� ������ ����������� �� ���������� ������� �������.
// ������������: ��������� ������������� ����. ����������: ��������� � ����������, �������� �����.
// �������� ��� ������� ���������� � ���������.
//
// ������ 5: ����������� ������� - �������, ������� ����� ���� �������������� � ����������� �������.
// ����������� ������ - ������, ���������� ���� �� ���� ����������� ������� ��� ����������.
// ��� ������������ ��� ���������� ������������.

enum class Color {
    RED,
    GREEN,
    BLUE
};

class ColorClass {
private:
    Color color;

public:
    ColorClass(Color c) : color(c) {}

    std::string toString() const {
        switch (color) {
        case Color::RED: return "RED";
        case Color::GREEN: return "GREEN";
        case Color::BLUE: return "BLUE";
        default: return "UNKNOWN";
        }
    }
};

class Shape {
protected:
    ColorClass color;

public:
    Shape(Color c) : color(c) {}

    virtual double area() const = 0;
    virtual double perimeter() const = 0;
    virtual void draw() const = 0;

    ColorClass getColor() const {
        return color;
    }
};

class Circle : public Shape {
private:
    double radius;

public:
    Circle(double r, Color c) : Shape(c), radius(r) {}

    double area() const override {
        return 3.14159 * radius * radius;
    }

    double perimeter() const override {
        return 2 * 3.14159 * radius;
    }

    void draw() const override {
        std::cout << "������ ���� � �������� " << radius << " � ������ " << color.toString() << std::endl;
    }
};

class Rectangle : public Shape {
private:
    double width, height;

public:
    Rectangle(double w, double h, Color c) : Shape(c), width(w), height(h) {}

    double area() const override {
        return width * height;
    }

    double perimeter() const override {
        return 2 * (width + height);
    }

    void draw() const override {
        std::cout << "������ ������������� � ������� " << width << ", ������� " << height << " � ������ " << color.toString() << std::endl;
    }
};

void task9() {
    Circle circle(5, Color::RED);
    Rectangle rectangle(3, 4, Color::BLUE);

    std::cout << "������� �����: " << circle.area() << std::endl;
    std::cout << "���� �����: " << circle.getColor().toString() << std::endl;
    std::cout << "������� ��������������: " << rectangle.area() << std::endl;
    std::cout << "���� ��������������: " << rectangle.getColor().toString() << std::endl;
}