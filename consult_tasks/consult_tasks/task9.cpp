#include <iostream>
#include "task9.h"

// Вопрос 1: Агрегация в ООП - это отношение между классами, при котором один класс содержит другой,
// но управление жизненным циклом содержимого не передается. Пример: класс Car содержит Engine.
//
// Вопрос 2: Композиция - сильная форма агрегации, где жизненный цикл содержимого полностью зависит от содержащего класса.
// Агрегация - слабая форма, где содержимое может существовать независимо. Композиция: Car содержит Engine. Агрегация: Car содержит Driver.
//
// Вопрос 3: Наследование - механизм ООП, позволяющий создавать новые классы на основе существующих.
// Виды: public, protected, private.
//
// Вопрос 4: Множественное наследование позволяет классу наследовать от нескольких базовых классов.
// Преимущества: повторное использование кода. Недостатки: сложность в управлении, проблема ромба.
// Избегать при наличии конфликтов и сложности.
//
// Вопрос 5: Виртуальные функции - функции, которые могут быть переопределены в производных классах.
// Абстрактные классы - классы, содержащие хотя бы одну виртуальную функцию без реализации.
// Они используются для реализации полиморфизма.

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
        std::cout << "Đčńóĺě ęđóă ń đŕäčóńîě " << radius << " č öâĺňîě " << color.toString() << std::endl;
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
        std::cout << "Đčńóĺě ďđ˙ěîóăîëüíčę ń řčđčíîé " << width << ", âűńîňîé " << height << " č öâĺňîě " << color.toString() << std::endl;
    }
};

void task9() {
    Circle circle(5, Color::RED);
    Rectangle rectangle(3, 4, Color::BLUE);

    std::cout << "Ďëîůŕäü ęđóăŕ: " << circle.area() << std::endl;
    std::cout << "Öâĺň ęđóăŕ: " << circle.getColor().toString() << std::endl;
    std::cout << "Ďëîůŕäü ďđ˙ěîóăîëüíčęŕ: " << rectangle.area() << std::endl;
    std::cout << "Öâĺň ďđ˙ěîóăîëüíčęŕ: " << rectangle.getColor().toString() << std::endl;
}
