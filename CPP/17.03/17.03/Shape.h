#ifndef SHAPE_H
#define SHAPE_H

#include <iostream>
#include <string>

class Shape {
public:
    virtual ~Shape() {}

    virtual void draw() const {
        std::cout << "Рисуем фигуру." << std::endl;
    }

    virtual double area() const = 0;
};

#endif // SHAPE_H