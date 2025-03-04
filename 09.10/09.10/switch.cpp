#include <iostream>
using namespace std;

void main() {
    setlocale(LC_ALL, "Russian");

    char figure;
    const double pi = 3.14;
    cout << "������� ������ ������ (R - �������������, T - �����������, C - ����): ";
    cin >> figure;

    switch (figure) {
        case 'R':
        case 'r': {
            double length, width;
            cout << "������� ����� � ������ ��������������: ";
            cin >> length >> width;
            double area = length * width;
            cout << "������� ��������������: " << area << endl;
            break;
        }
        case 'T':
        case 't': {
            double base, height;
            cout << "������� ��������� � ������ ������������: ";
            cin >> base >> height;
            double area = 0.5 * base * height;
            cout << "������� ������������: " << area << endl;
            break;
        }
        case 'C':
        case 'c': {
            double radius;
            cout << "������� ������ �����: ";
            cin >> radius;
            double area = pi * radius * radius;
            cout << "������� �����: " << area << endl;
            break;
        }
        default:
            cout << "������: ������������ ������!" << endl;
            break;
        }
}
