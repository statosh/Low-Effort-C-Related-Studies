#include <iostream>
using namespace std;

int main() {
    setlocale(LC_ALL, "Russian");

    int rows, cols, k;

    cout << "Введите количество строк: ";
    while (!(cin >> rows) || rows <= 0) {
        cin.clear();
        cin.ignore(numeric_limits<streamsize>::max(), '\n');
        cout << "Некорректный ввод. Введите положительное число: ";
    }

    cout << "Введите количество столбцов: ";
    while (!(cin >> cols) || cols <= 0) {
        cin.clear();
        cin.ignore(numeric_limits<streamsize>::max(), '\n');
        cout << "Некорректный ввод. Введите положительное число: ";
    }

    cout << "Введите коэффициент k: ";
    while (!(cin >> k)) {
        cin.clear();
        cin.ignore(numeric_limits<streamsize>::max(), '\n');
        cout << "Некорректный ввод. Введите числовое значение: ";
    }

    int** arr = new int* [rows];
    for (int i = 0; i < rows; ++i) {
        arr[i] = new int[cols];
    }

    for (int i = 0; i < rows; ++i) {
        for (int j = 0; j < cols; ++j) {
            arr[i][j] = i * k;
        }
    }

    cout << "Сгенерированный массив:\n";
    for (int i = 0; i < rows; ++i) {
        for (int j = 0; j < cols; ++j) {
            cout << arr[i][j] << " ";
        }
        cout << endl;
    }

    for (int i = 0; i < rows; ++i) {
        delete[] arr[i];
    }
    delete[] arr;

    return 0;
}
