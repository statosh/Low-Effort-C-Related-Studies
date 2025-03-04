// Ответы:
//    1: a
//    2 : b
//    3 : a
//    4 : a
//    5 : b
//    6 : a
//    7 : a
//    8 : a
//    9 : a
//    10 : a, b
//    11 : a, b
//    12 : a
//    13 : b
//    14 : a
//    15 : a
//    16 : a
//    17 : a
//    18 : a
//    19 : a
//    20 : a

#include <iostream>
using namespace std;

long long factorial(int n) {
    long long result = 1;
    for (int i = 2; i <= n; ++i) {
        result *= i;
    }
    return result;
}

int gcd(int a, int b) {
    while (b != 0) {
        int temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}

void bubbleSort(int arr[], int size) {
    for (int i = 0; i < size - 1; ++i) {
        for (int j = 0; j < size - i - 1; ++j) {
            if (arr[j] > arr[j + 1]) {
                swap(arr[j], arr[j + 1]);
            }
        }
    }
}

int main() {
    setlocale(LC_ALL, "Russian");

    while (true) {
        cout << R"(
Меню:
1. Вычислить факториал числа
2. Найти НОД двух чисел
3. Отсортировать массив методом пузырька
0. Выход
Выберите действие: )";

        int choice;
        cin >> choice;

        switch (choice) {
        case 1: {
            int n;
            cout << "Введите число: ";
            cin >> n;
            if (n < 0) {
                cout << "Ошибка: факториал определяется только для неотрицательных чисел." << endl;
            } else {
                cout << "Факториал " << n << " = " << factorial(n) << endl;
            }
            break;
        }
        case 2: {
            int a, b;
            cout << "Введите два числа: ";
            cin >> a >> b;
            cout << "НОД(" << a << ", " << b << ") = " << gcd(a, b) << endl;
            break;
        }
        case 3: {
            int size;
            cout << "Введите размер массива: ";
            cin >> size;
            int* arr = new int[size];
            cout << "Введите элементы массива: ";
            for (int i = 0; i < size; ++i) {
                cin >> arr[i];
            }
            bubbleSort(arr, size);
            cout << "Отсортированный массив: ";
            for (int i = 0; i < size; ++i) {
                cout << arr[i] << " ";
            }
            cout << endl;
            delete[] arr;
            break;
        }
        case 0:
            cout << "Выход из программы." << endl;
            return 0;
        default:
            cout << "Неверный выбор. Попробуйте снова." << endl;
        }
    }
}
