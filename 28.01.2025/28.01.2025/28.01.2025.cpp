#include <iostream>
using namespace std;

long long factorial(int* n) {
    long long result = 1;
    for (int i = 1; i <= *n; ++i) {
        result *= i;
    }
    return result;
}

void multiplicationTable() {
    cout << "\nТаблица умножения:\n";
    for (int i = 1; i <= 10; ++i) {
        for (int j = 1; j <= 10; ++j) {
            cout << i * j << "\t";
        }
        cout << endl;
    }
}

bool isPrime(int* n) {
    if (*n < 2) return false;
    for (int i = 2; i * i <= *n; ++i) {
        if (*n % i == 0) return false;
    }
    return true;
}

int main() {
    setlocale(LC_ALL, "Russian");

    int choice;

    while (true) {
        cout << R"(
Выберите действие:
1) Вычислить факториал
2) Вывести таблицу умножения
3) Проверить число на простоту
0) Выход
Введите номер действия: )";
        cin >> choice;

        switch (choice) {
        case 1: {
            int num;
            cout << "\nВведите число: ";
            cin >> num;
            cout << "Факториал числа " << num << " равен " << factorial(&num) << endl;
            break;
        }
        case 2:
            multiplicationTable();
            break;
        case 3: {
            int num;
            cout << "\nВведите число: ";
            cin >> num;
            cout << "Число " << num << (isPrime(&num) ? " - простое" : " - составное") << endl;
            break;
        }
        case 0:
            cout << "Выход из программы.\n";
            return 0;
        default:
            cout << "Неверный выбор! Попробуйте снова." << endl;
        }
    }

    return 0;
}
