#ifndef RECTANGLE_H
#define RECTANGLE_H

#include "Shape.h"

class Rectangle : public Shape {
private:
    double width;
    double height;

public:
    Rectangle(double width, double height) : width(width), height(height) {}

    double area() const override {
        return width * height;
    }

    void draw() const override {
        std::cout << "Рисуем прямоугольник с шириной " << width << " и высотой " << height << "." << std::endl;
    }

    double getWidth() const { return width; }
    double getHeight() const { return height; }
};

#endif // RECTANGLE_H