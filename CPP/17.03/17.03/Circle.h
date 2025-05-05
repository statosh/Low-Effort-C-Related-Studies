#ifndef CIRCLE_H
#define CIRCLE_H

#include "Shape.h"

class Circle : public Shape {
private:
    double radius;

public:
    Circle(double radius) : radius(radius) {}

    double area() const override {
        return 3.141592653589793 * radius * radius;
    }

    void draw() const override {
        std::cout << "Рисуем круг с радиусом " << radius << "." << std::endl;
    }
};

#endif // CIRCLE_H