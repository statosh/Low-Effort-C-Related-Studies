#include <iostream>
#include <cmath>

using namespace std;

class Rectangle {
private:
    double x1, y1;
    double x2, y2;

public:
    Rectangle(double x1, double y1, double x2, double y2)
        : x1(x1), y1(y1), x2(x2), y2(y2) {}

    double getX1() const { return x1; }
    double getY1() const { return y1; }
    double getX2() const { return x2; }
    double getY2() const { return y2; }

    double getWidth() const {
        return abs(x2 - x1);
    }

    double getHeight() const {
        return abs(y2 - y1);
    }

    double getArea() const {
        return getWidth() * getHeight();
    }

    double getPerimeter() const {
        return 2 * (getWidth() + getHeight());
    }

    void setCoordinatesFrom(const Rectangle& other) {
        x1 = other.x1;
        y1 = other.y1;
        x2 = other.x2;
        y2 = other.y2;
    }
};

int main() {
    setlocale(LC_ALL, "Russian");

    Rectangle rect1(1.0, 4.0, 5.0, 1.0);

    cout << "Координаты вершин: (" << rect1.getX1() << ", " << rect1.getY1() << ") и ("
        << rect1.getX2() << ", " << rect1.getY2() << ")\n";

    cout << "Ширина: " << rect1.getWidth() << "\n";
    cout << "Высота: " << rect1.getHeight() << "\n";

    cout << "Площадь: " << rect1.getArea() << "\n";
    cout << "Периметр: " << rect1.getPerimeter() << "\n";

    Rectangle rect2(0, 0, 0, 0);
    rect2.setCoordinatesFrom(rect1);

    cout << "Координаты второго прямоугольника: (" << rect2.getX1() << ", " << rect2.getY1()
        << ") и (" << rect2.getX2() << ", " << rect2.getY2() << ")\n";

    return 0;
}