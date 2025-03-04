#include <iostream>
using namespace std;

void main() {
	setlocale(LC_ALL, "Russian");

    int total_seconds;

    cout << "������� ����� � ��������: ";
    cin >> total_seconds;

    if (total_seconds > 86400) {
        cout << "������: ���������� ������ �� ����� ��������� 86400." << endl;
        return;
    }

    int hours = total_seconds / 3600;
    int minutes = (total_seconds % 3600) / 60;
    int seconds = total_seconds % 60;

    cout << "�����: " << hours << " ����� "
                      << minutes << " ����� "
                      << seconds << " ������" << endl;

    int seconds_in_day = 24 * 3600;
    int remaining_seconds = seconds_in_day - total_seconds;

    int remaining_hours = remaining_seconds / 3600;
    int remaining_minutes = (remaining_seconds % 3600) / 60;
    int remaining_secs = remaining_seconds % 60;

    cout << "�� �������� ��������: " << remaining_hours << " ����� "
                                     << remaining_minutes << " ����� "
                                     << remaining_secs << " ������" << endl;
}