#include <iostream>
using namespace std;

int PowerRecursive(int base, int exponent) {
    if (exponent == 0) return 1;
    return base * PowerRecursive(base, exponent - 1);
}

void PrintStars(int n) {
    if (n <= 0) return;
    cout << "*";
    PrintStars(n - 1);
}

int SumInRange(int a, int b) {
    if (a > b) return 0;
    return a + SumInRange(a + 1, b);
}

int main() {
    setlocale(LC_ALL, "Russian");
    string input;

    while (true) {
        cout << R"(
Выберите задание:
1) Нахождение степени числа (рекурсивно)
2) Вывести N звёзд в ряд (рекурсивно)
3) Сумма всех чисел в диапазоне [a, b] (рекурсивно)
Введите "quit" для выхода.
)";

        cin >> input;
        if (input == "quit") break;

        int choice = input[0] - '0';
        switch (choice) {
        case 1: {
            int base, exponent;
            cout << "Введите основание и показатель степени: ";
            cin >> base >> exponent;
            cout << "Результат: " << PowerRecursive(base, exponent) << endl;
            break;
        }
        case 2: {
            int n;
            cout << "Введите количество звёзд: ";
            cin >> n;
            PrintStars(n);
            cout << endl;
            break;
        }
        case 3: {
            int a, b;
            cout << "Введите два числа (a и b): ";
            cin >> a >> b;
            if (a > b) swap(a, b);
            cout << "Сумма чисел в диапазоне [" << a << ", " << b << "]: " << SumInRange(a, b) << endl;
            break;
        }
        default:
            cout << "Неверный выбор. Попробуйте снова." << endl;
        }
    }
    return 0;
}
