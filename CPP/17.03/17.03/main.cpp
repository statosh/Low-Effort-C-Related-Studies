#include <iostream>
#include "Rectangle.h"
#include "Square.h"
#include "Circle.h"

int main() {
    setlocale(LC_ALL, "Russian");

    Rectangle rect(5.0, 3.0);
    Square square(4.0);
    Circle circle(2.0);

    Shape* shapePtr;

    shapePtr = &rect;
    std::cout << "Используем Rectangle через указатель на Shape:" << std::endl;
    shapePtr->draw();
    std::cout << "Площадь: " << shapePtr->area() << std::endl;

    shapePtr = &square;
    std::cout << "\nИспользуем Square через указатель на Shape:" << std::endl;
    shapePtr->draw();
    std::cout << "Площадь: " << shapePtr->area() << std::endl;

    shapePtr = &circle;
    std::cout << "\nИспользуем Circle через указатель на Shape:" << std::endl;
    shapePtr->draw();
    std::cout << "Площадь: " << shapePtr->area() << std::endl;

    Shape& shapeRef = rect;
    std::cout << "\nИспользуем Rectangle через ссылку на Shape:" << std::endl;
    shapeRef.draw();
    std::cout << "Площадь: " << shapeRef.area() << std::endl;

    shapeRef = square;
    std::cout << "\nИспользуем Square через ссылку на Shape:" << std::endl;
    shapeRef.draw();
    std::cout << "Площадь: " << shapeRef.area() << std::endl;

    shapeRef = circle;
    std::cout << "\nИспользуем Circle через ссылку на Shape:" << std::endl;
    shapeRef.draw();
    std::cout << "Площадь: " << shapeRef.area() << std::endl;

    return 0;
}