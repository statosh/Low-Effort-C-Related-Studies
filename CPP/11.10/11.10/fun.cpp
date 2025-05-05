#include <iostream>
using namespace std;

void reverseNumber();
void sumOfDigits();
void snailDistance();

int main() {
    setlocale(LC_ALL, "Russian");

    int choice;
    cout << R"(
Выберите задание:

    1. Вывести цифры числа в обратном порядке
    2. Найти сумму цифр числа
    3. Определить расстояние, пройденное улиткой за N дней

Введите номер задания (1-3): )";

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
            cout << "Неверный выбор! Пожалуйста, выберите число от 1 до 3." << endl;
            break;
    }

    return 0;
}

void reverseNumber() {
    int number;
    cout << "Введите число больше нуля: ";
    cin >> number;

    if (number > 0) {
        cout << "Число в обратном порядке: ";
        while (number > 0) {
            cout << number % 10;
            number /= 10;
        }
        cout << endl;
    } else {
        cout << "Введите число больше нуля!" << endl;
    }
}

void sumOfDigits() {
    int number;
    cout << "Введите число: ";
    cin >> number;

    int sum = 0;
    while (number != 0) {
        sum += number % 10;
        number /= 10;
    }

    cout << "Сумма цифр числа: " << sum << endl;
}

void snailDistance() {
    int days;
    cout << "Введите количество дней: ";
    cin >> days;

    int distance = 0;
    int dailyDistance = 15;

    for (int i = 1; i <= days; ++i) {
        distance += dailyDistance;
        dailyDistance += 2;
    }

    cout << "Улитка проползет за " << days << " дней: " << distance << " см." << endl;
}