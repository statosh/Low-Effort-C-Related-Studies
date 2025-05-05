#include <iostream>
using namespace std;

void main() {
    setlocale(LC_ALL, "Russian");

    char figure;
    const double pi = 3.14;
    cout << "Введите символ фигуры (R - прямоугольник, T - треугольник, C - круг): ";
    cin >> figure;

    switch (figure) {
        case 'R':
        case 'r': {
            double length, width;
            cout << "Введите длину и ширину прямоугольника: ";
            cin >> length >> width;
            double area = length * width;
            cout << "Площадь прямоугольника: " << area << endl;
            break;
        }
        case 'T':
        case 't': {
            double base, height;
            cout << "Введите основание и высоту треугольника: ";
            cin >> base >> height;
            double area = 0.5 * base * height;
            cout << "Площадь треугольника: " << area << endl;
            break;
        }
        case 'C':
        case 'c': {
            double radius;
            cout << "Введите радиус круга: ";
            cin >> radius;
            double area = pi * radius * radius;
            cout << "Площадь круга: " << area << endl;
            break;
        }
        default:
            cout << "Ошибка: неправильный символ!" << endl;
            break;
        }
}
