#include <iostream>
#include <cmath>
#include "task1.h"

// Вопрос 1: Класс в C++ - это пользовательский тип данных, который может содержать данные и методы для работы с этими данными. 
// Основные компоненты класса: поля-члены (данные) и методы-члены (функции).
// 
// Вопрос 2: Уровни доступа в классе: public (доступен всем), protected (доступен внутри класса и производных классах), 
// private (доступен только внутри класса). Примеры: public: int x; protected: int y; private: int z;
// 
// Вопрос 3: Конструктор класса - специальный метод, вызываемый при создании объекта. 
// Конструктор по умолчанию инициализирует объект значениями по умолчанию.
// 
// Вопрос 4: Деструктор - специальный метод, вызываемый при уничтожении объекта. 
// Он необходим для освобождения ресурсов, выделенных в конструкторе.
// 
// Вопрос 5: Поля-члены класса принадлежат объекту и существуют в течение всего времени жизни объекта. 
// Локальные переменные метода существуют только во время выполнения метода.

class Vector2D {
public:
    double x, y;

    Vector2D() : x(0), y(0) {}
    Vector2D(double x, double y) : x(x), y(y) {}

    double length() const {
        return std::sqrt(x * x + y * y);
    }

    void normalize() {
        double len = length();
        if (len != 0) {
            x /= len;
            y /= len;
        }
    }

    Vector2D operator+(const Vector2D& other) const {
        return Vector2D(x + other.x, y + other.y);
    }

    Vector2D operator-(const Vector2D& other) const {
        return Vector2D(x - other.x, y - other.y);
    }

    friend Vector2D operator*(double scalar, const Vector2D& vec) {
        return Vector2D(scalar * vec.x, scalar * vec.y);
    }
};

void task1() {
    Vector2D v1(3, 4);
    Vector2D v2(1, 2);

    std::cout << "Длина вектора v1: " << v1.length() << std::endl;
    v1.normalize();
    std::cout << "Нормализованный вектор v1: (" << v1.x << ", " << v1.y << ")" << std::endl;

    Vector2D v3 = v1 + v2;
    std::cout << "Сумма векторов v1 и v2: (" << v3.x << ", " << v3.y << ")" << std::endl;
}