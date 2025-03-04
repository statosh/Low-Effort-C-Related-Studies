#include <iostream>
using namespace std;

void main() {
	setlocale(LC_ALL, "Russian");

    int total_seconds;

    cout << "Введите время в секундах: ";
    cin >> total_seconds;

    if (total_seconds > 86400) {
        cout << "Ошибка: количество секунд не может превышать 86400." << endl;
        return;
    }

    int hours = total_seconds / 3600;
    int minutes = (total_seconds % 3600) / 60;
    int seconds = total_seconds % 60;

    cout << "Время: " << hours << " часов "
                      << minutes << " минут "
                      << seconds << " секунд" << endl;

    int seconds_in_day = 24 * 3600;
    int remaining_seconds = seconds_in_day - total_seconds;

    int remaining_hours = remaining_seconds / 3600;
    int remaining_minutes = (remaining_seconds % 3600) / 60;
    int remaining_secs = remaining_seconds % 60;

    cout << "До полуночи осталось: " << remaining_hours << " часов "
                                     << remaining_minutes << " минут "
                                     << remaining_secs << " секунд" << endl;
}