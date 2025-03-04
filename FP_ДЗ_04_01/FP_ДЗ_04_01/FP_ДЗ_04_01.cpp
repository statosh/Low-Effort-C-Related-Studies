#include <iostream>
using namespace std;

void main() {
    setlocale(LC_ALL, "ru");

    int number;

    cout << "Введите шестизначное число: ";
    cin >> number;

    if (number < 100000 || number > 999999) {
        cout << "Ошибка: введено не шестизначное число.\n";
        return;
    }

    int first_half_sum = (number / 100000) + ((number / 10000) % 10) + ((number / 1000) % 10);
    int second_half_sum = ((number / 100) % 10) + ((number / 10) % 10) + (number % 10);

    if (first_half_sum == second_half_sum) {
        cout << "Число является счастливым!\n" ;
    } else {
        cout << "Число не является счастливым.\n";
    }
}