#include <iostream>
using namespace std;

long int PowerRecursive(int base, int exponent) {
    if (exponent == 0) return 1;
    return base * PowerRecursive(base, exponent - 1);
}

void PrintStars(int n) {
    if (n <= 0) return;
    cout << "*";
    PrintStars(n - 1);
}

int SumInRange(int a, int b) {
    if (a > b) {
        int temp = a;
        a = b;
        b = temp;
    }
    if (a == b) return a;
    return a + SumInRange(a + 1, b);
}



// Максимум в одномерном массиве
int findMax(int arr[], int size) {
    int maxVal = arr[0];
    for (int i = 1; i < size; ++i) {
        if (arr[i] > maxVal) {
            maxVal = arr[i];
        }
    }
    return maxVal;
}

// Максимум в двумерном массиве
int findMax(int arr[][3], int rows, int cols) {
    int maxVal = arr[0][0];
    for (int i = 0; i < rows; ++i) {
        for (int j = 0; j < cols; ++j) {
            if (arr[i][j] > maxVal) {
                maxVal = arr[i][j];
            }
        }
    }
    return maxVal;
}

// Максимум в трёхмерном массиве
int findMax(int arr[][3][3], int x, int y, int z) {
    int maxVal = arr[0][0][0];
    for (int i = 0; i < x; ++i) {
        for (int j = 0; j < y; ++j) {
            for (int k = 0; k < z; ++k) {
                if (arr[i][j][k] > maxVal) {
                    maxVal = arr[i][j][k];
                }
            }
        }
    }
    return maxVal;
}

// Максимум среди двух чисел
int findMax(int a, int b) {
    return (a > b) ? a : b;
}

// Максимум среди трёх чисел
int findMax(int a, int b, int c) {
    return findMax(findMax(a, b), c);
}



int main() {
    setlocale(LC_ALL, "Russian");
    char input[10];
    while (true) {
        cout << R"(
1) Степень числа (рекурсивно)
2) Вывести N звёзд
3) Сумма чисел от A до B
4) Найти максимум в массиве

Введите номер действия (или 'quit' для выхода): )";
        cin >> input;

        if (strcmp(input, "quit") == 0) break;

        int choice = atoi(input);
        switch (choice) {
        case 1: {
            int base, exponent;
            cout << endl << "Введите основание и показатель степени: ";
            cin >> base >> exponent;
            cout << "Результат: " << PowerRecursive(base, exponent) << endl;
            break;
        }
        case 2: {
            int n;
            cout << endl << "Введите количество звёзд: ";
            cin >> n;
            PrintStars(n);
            cout << endl;
            break;
        }
        case 3: {
            int a, b;
            cout << endl << "Введите два числа (A и B): ";
            cin >> a >> b;
            cout << "Сумма чисел от " << a << " до " << b << ": " << SumInRange(a, b) << endl;
            break;
        }
        case 4: {

            int arr1[] = { 1, 5, 3, 9, 2 };
            cout << endl << "Максимум в одномерном массиве { 1, 5, 3, 9, 2 }\n--------------------\n" << findMax(arr1, 5) << endl;

            int arr2[2][3] = { {1, 2, 3}, {7, 5, 6} };
            cout << endl << "Максимум в двумерном массиве { {1, 2, 3}, {7, 5, 6} }\n--------------------\n" << findMax(arr2, 2, 3) << endl;

            int arr3[2][3][3] = { {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}}, {{10, 11, 12}, {13, 14, 15}, {16, 17, 18}} };
            cout << endl << "Максимум в трёхмерном массиве { {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}}, {{10, 11, 12}, {13, 14, 15}, {16, 17, 18}} }\n--------------------\n" << findMax(arr3, 2, 3, 3) << endl;

            cout << endl << "Максимум из двух чисел (10 и 20): " << findMax(10, 20) << endl;

            cout << "Максимум из трёх чисел (10, 20 и 15): " << findMax(10, 20, 15) << endl;

            break;
        }
        default:
            cout << "Неверный выбор!" << endl;
        }
    }
    return 0;
}
