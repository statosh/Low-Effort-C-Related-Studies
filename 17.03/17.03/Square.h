#ifndef SQUARE_H
#define SQUARE_H

#include "Rectangle.h"

class Square : public Rectangle {
public:
    Square(double side) : Rectangle(side, side) {}

    double area() const override {
        return Rectangle::area();
    }

    void draw() const override {
        std::cout << "Рисуем квадрат со стороной " << getSide() << "." << std::endl;
    }

    double getSide() const {
        return Rectangle::getWidth();
    }
};

#endif // SQUARE_H