#include <iostream>
using namespace std;

void main() {
    setlocale(LC_ALL, "Russian");
    int seconds_worked;

    cout << "Введите количество секунд, прошедших с начала рабочего дня: ";
    cin >> seconds_worked;

    int workday_seconds = 8 * 3600;

    if (seconds_worked >= workday_seconds) {
        cout << "Рабочий день уже закончился!" << endl;
    }
    else {
        int remaining_seconds = workday_seconds - seconds_worked;
        int remaining_hours = remaining_seconds / 3600;
        cout << "Осталось работать: " << remaining_hours << " целых часов." << endl;
    }
}