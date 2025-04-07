#include <iostream>
#include <cmath>
#include "task4.h"

// Вопрос 1: Константный метод в C++ - это метод, который не изменяет состояние объекта. 
// Ограничения: не может изменять поля-члены класса (кроме mutable), не может вызывать не-константные методы.
// 
// Вопрос 2: Важно для обеспечения безопасности данных и корректности поведения программы. 
// Преимущества: защита данных, возможность вызывать такие методы для константных объектов.
// 
// Вопрос 3: Нет, константные методы не могут изменять состояние объекта, так как это противоречит их назначению.
// 
// Вопрос 4: Объявляется с использованием ключевого слова const после списка параметров. 
// Пример: double getArea() const { return width * height; }
// 
// Вопрос 5: Перегруженные методы с учетом const позволяют выполнять разные действия для константных и неконстантных объектов. 
// Пример: int getValue() const { return value; } и int& getValue() { return value; }

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
    std::cout << "Расстояние от p1 до начала координат: " << dist1 << std::endl;

    bool isEqual = p1.isEqual(p2);
    std::cout << "p1 равно p2? " << (isEqual ? "Да" : "Нет") << std::endl;
}