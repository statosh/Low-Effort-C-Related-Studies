#include <iostream>
#include <stdexcept>
#include "task10.h"

// Вопрос 1: Виртуальные методы в C++ - это методы, которые могут быть переопределены в производных классах.
// Они используются для реализации полиморфизма.
//
// Вопрос 2: Ключевое слово virtual позволяет методу быть переопределенным в производных классах.
// Виртуальный метод может быть переопределен, а невиртуальный - нет.
//
// Вопрос 3: При переопределении виртуальных методов в производных классах вызывается метод производного класса
// при обращении через указатель на базовый класс. Это позволяет реализовать полиморфизм.
//
// Вопрос 4: Ключевые слова: try, catch, throw. try - блок кода, в котором могут возникнуть исключения.
// catch - блок кода для обработки исключений. throw - выброс исключения.
//
// Вопрос 5: Пространства имен в C++ используются для организации кода и предотвращения конфликтов имен.
// Пример: std::cout.

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
            throw std::invalid_argument("Радиус должен быть положительным");
        }
    }

    void draw() const override {
        std::cout << "Рисуем круг с радиусом " << radius << std::endl;
    }
};

class Rectangle : public Shape {
private:
    double width, height;

public:
    Rectangle(double w, double h) : width(w), height(h) {
        if (w <= 0 || h <= 0) {
            throw std::invalid_argument("Ширина и высота должны быть положительными");
        }
    }

    void draw() const override {
        std::cout << "Рисуем прямоугольник с шириной " << width << " и высотой " << height << std::endl;
    }
};

void task10() {
    Shape* shapes[2];
    try {
        shapes[0] = new Circle(5);
        shapes[1] = new Rectangle(3, 4);
    } catch (const std::invalid_argument& e) {
        std::cerr << "Ошибка создания фигуры: " << e.what() << std::endl;
        return;
    }

    for (auto shape : shapes) {
        try {
            shape->draw();
        } catch (std::exception& e) {
            std::cerr << "Ошибка: " << e.what() << std::endl;
        }
    }

    delete shapes[0];
    delete shapes[1];
}