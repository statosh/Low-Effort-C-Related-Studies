#include <iostream>
using namespace std;

int main() {
    setlocale(LC_ALL, "Russian");

    double distance, time, speed;

    cout << "Введите расстояние до аэропорта (в километрах): ";
    cin >> distance;

    cout << "Введите время, за которое нужно доехать (в часах): ";
    cin >> time;

    if (time <= 0) {
        cout << "Ошибка: время должно быть больше 0." << endl;
        return 1;
    }

    speed = distance / time;

    cout << "Вам нужно ехать со скоростью: " << speed << " км/ч." << endl;

    return 0;
}