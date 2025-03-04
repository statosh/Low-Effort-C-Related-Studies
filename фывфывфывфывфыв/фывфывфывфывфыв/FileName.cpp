#include <iostream>
using namespace std;

double Power(double base, int exponent) {
    double result = 1;
    for (int i = 0; i < abs(exponent); ++i) {
        result *= base;
    }
    if (exponent < 0) {
        result = 1 / result;
    }
    return result;
}

int RangeSum(int start, int end) {
    int sum = 0;
    if (start > end) {
        int temp = start;
        start = end;
        end = temp;
    }
    for (int i = start + 1; i < end; ++i) {
        sum += i;
    }
    return sum;
}

bool IsPerfect(int num) {
    int sum = 0;
    for (int i = 1; i <= num / 2; ++i) {
        if (num % i == 0) {
            sum += i;
        }
    }
    return sum == num;
}

void PerfectNumbersInInterval(int start, int end) {
    if (start > end) {
        int temp = start;
        start = end;
        end = temp;
    }
    cout << "Совершенные числа в интервале [" << start << ", " << end << "]: ";
    bool found = false;
    for (int i = start; i <= end; ++i) {
        if (IsPerfect(i)) {
            cout << i << " ";
            found = true;
        }
    }
    if (!found) {
        cout << "нет.";
    }
    cout << endl;
}

int main() {
    setlocale(LC_ALL, "Russian");
    string input;

    while (true) {
        cout << R"(
1) Вычислить степень числа
2) Найти сумму чисел в диапазоне
3) Найти совершенные числа в интервале

Введите номер действия (или 'quit' для выхода): )";

        cin >> input;

        if (input == "quit") {
            break;
        }

        int choice = input[0] - '0';

        switch (choice) {
        case 1: {
            double base;
            int exponent;
            cout << endl << "Введите основание и показатель степени: ";
            cin >> base >> exponent;
            cout << "Результат: " << Power(base, exponent) << endl;
            break;
        }
        case 2: {
            int start, end;
            cout << endl << "Введите два числа для диапазона: ";
            cin >> start >> end;
            cout << "Сумма чисел в диапазоне: " << RangeSum(start, end) << endl;
            break;
        }
        case 3: {
            int start, end;
            cout << endl << "Введите интервал (два числа): ";
            cin >> start >> end;
            PerfectNumbersInInterval(start, end);
            break;
        }
        default:
            cout << endl << "Неверный выбор. Попробуйте снова.\n";
        }
    }

    return 0;
}
