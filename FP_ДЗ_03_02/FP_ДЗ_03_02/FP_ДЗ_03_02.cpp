#include <iostream>
using namespace std;

void main() {
    setlocale(LC_ALL, "Russian");
    int seconds_worked;

    cout << "������� ���������� ������, ��������� � ������ �������� ���: ";
    cin >> seconds_worked;

    int workday_seconds = 8 * 3600;

    if (seconds_worked >= workday_seconds) {
        cout << "������� ���� ��� ����������!" << endl;
    }
    else {
        int remaining_seconds = workday_seconds - seconds_worked;
        int remaining_hours = remaining_seconds / 3600;
        cout << "�������� ��������: " << remaining_hours << " ����� �����." << endl;
    }
}