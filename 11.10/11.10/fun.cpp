#include <iostream>
using namespace std;

void reverseNumber();
void sumOfDigits();
void snailDistance();

int main() {
    setlocale(LC_ALL, "Russian");

    int choice;
    cout << R"(
�������� �������:

    1. ������� ����� ����� � �������� �������
    2. ����� ����� ���� �����
    3. ���������� ����������, ���������� ������� �� N ����

������� ����� ������� (1-3): )";

    cin >> choice;

    switch (choice) {
        case 1:
            reverseNumber();
            break;
        case 2:
            sumOfDigits();
            break;
        case 3:
            snailDistance();
            break;
        default:
            cout << "�������� �����! ����������, �������� ����� �� 1 �� 3." << endl;
            break;
    }

    return 0;
}

void reverseNumber() {
    int number;
    cout << "������� ����� ������ ����: ";
    cin >> number;

    if (number > 0) {
        cout << "����� � �������� �������: ";
        while (number > 0) {
            cout << number % 10;
            number /= 10;
        }
        cout << endl;
    } else {
        cout << "������� ����� ������ ����!" << endl;
    }
}

void sumOfDigits() {
    int number;
    cout << "������� �����: ";
    cin >> number;

    int sum = 0;
    while (number != 0) {
        sum += number % 10;
        number /= 10;
    }

    cout << "����� ���� �����: " << sum << endl;
}

void snailDistance() {
    int days;
    cout << "������� ���������� ����: ";
    cin >> days;

    int distance = 0;
    int dailyDistance = 15;

    for (int i = 1; i <= days; ++i) {
        distance += dailyDistance;
        dailyDistance += 2;
    }

    cout << "������ ��������� �� " << days << " ����: " << distance << " ��." << endl;
}