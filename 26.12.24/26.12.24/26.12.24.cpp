#include <iostream>
using namespace std;

int main() {
    setlocale(LC_ALL, "Russian");

    int size;
    cout << "Введите размер массива: ";
    while (!(cin >> size) || size <= 0) {
        cin.clear();
        cin.ignore(numeric_limits<streamsize>::max(), '\n');
        cout << "Некорректный ввод. Введите положительное число: ";
    }

    int* arr = new int[size];

    cout << "Введите элементы массива:" << endl;
    for (int i = 0; i < size; ++i) {
        cout << "Элемент [" << i << "]: ";
        while (!(cin >> arr[i])) {
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(), '\n');
            cout << "Некорректный ввод. Повторите для элемента [" << i << "]: ";
        }
    }

    cout << "Элементы массива: ";
    for (int i = 0; i < size; ++i) {
        cout << arr[i] << " ";
    }
    cout << endl;

    delete[] arr;

    return 0;
}
