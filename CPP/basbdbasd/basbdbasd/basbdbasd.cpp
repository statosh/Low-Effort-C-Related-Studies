#include <iostream>
using namespace std;

void main() {
    setlocale(LC_ALL, "Russian");

    double radius, area;
    const double pi = 3.14;

    cout << "Введите радиус круга: ";
    cin >> radius;

    area = pi * radius * radius;

    cout << "Площадь круга: " << area << endl;
}