#include <iostream>
using namespace std;

void task1() {
    int arr[10];
    cout << "Введите 10 целых чисел: ";
    for (int i = 0; i < 10; ++i) {
        cin >> arr[i];
    }

    int minNum = arr[0];
    for (int i = 1; i < 10; ++i) {
        if (arr[i] < minNum) {
            minNum = arr[i];
        }
    }

    cout << "Минимальное число: " << minNum << endl;
}

void task2() {
    int arr[3][3];
    int num = 1;
    for (int i = 0; i < 3; ++i) {
        for (int j = 0; j < 3; ++j) {
            arr[i][j] = num++;
        }
    }

    cout << "Двумерный массив 3x3:" << endl;
    for (int i = 0; i < 3; ++i) {
        for (int j = 0; j < 3; ++j) {
            cout << arr[i][j] << " ";
        }
        cout << endl;
    }
}

void task3() {
    int arr[4][4];
    cout << "Введите элементы 4x4 массива:" << endl;
    for (int i = 0; i < 4; ++i) {
        for (int j = 0; j < 4; ++j) {
            cin >> arr[i][j];
        }
    }

    int sum = 0;
    for (int i = 0; i < 4; ++i) {
        for (int j = 0; j < 4; ++j) {
            sum += arr[i][j];
        }
    }

    cout << "Сумма всех элементов массива: " << sum << endl;
}

int main() {
    setlocale(LC_ALL, "Russian");

    while (true) {
        cout << R"(
Меню:
1. Одномерный массив - найти минимальное число
2. Двумерный массив 3x3 - заполнение числами от 1 до 9
3. Двумерный массив 4x4 - сумма всех элементов
0. Выход
Выберите действие: )";

        int choice;
        cin >> choice;

        switch (choice) {
        case 1:
            task1();
            break;
        case 2:
            task2();
            break;
        case 3:
            task3();
            break;
        case 0:
            cout << "Выход из программы." << endl;
            return 0;
        default:
            cout << "Неверный выбор. Попробуйте снова." << endl;
        }
    }
}
