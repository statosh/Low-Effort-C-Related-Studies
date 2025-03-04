#include <iostream>
using namespace std;

int arr[] = { 1, 3, 5, 7, 9, 11 };
int arrSize = sizeof(arr) / sizeof(arr[0]);

int LinearSearch(int key) {
    for (int i = 0; i < arrSize; ++i) {
        if (arr[i] == key) {
            return i;
        }
    }
    return -1;
}

int BinarySearch(int key) {
    int left = 0, right = arrSize - 1;
    while (left <= right) {
        int mid = left + (right - left) / 2;
        if (arr[mid] == key) {
            return mid;
        } else if (arr[mid] < key) {
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }
    return -1;
}

int BinaryToDecimal(int binary) {
    int decimal = 0, base = 1;
    while (binary > 0) {
        int last_digit = binary % 10;
        binary /= 10;
        decimal += last_digit * base;
        base *= 2;
    }
    return decimal;
}

void PrintArray() {
    cout << "Массив: ";
    for (int i = 0; i < arrSize; ++i) {
        cout << arr[i] << " ";
    }
    cout << endl;
}

int main() {
    setlocale(LC_ALL, "Russian");
    PrintArray();
    string input;

    while (true) {
        cout << R"(
1) Линейный поиск
2) Бинарный поиск
3) Перевод двоичного числа в десятичное
Введите номер действия (или 'quit' для выхода): )";

        cin >> input;
        if (input == "quit") {
            break;
        }

        int choice = input[0] - '0';
        switch (choice) {
        case 1: {
            int key;
            cout << "Введите ключ для поиска: ";
            cin >> key;
            int result = LinearSearch(key);
            if (result != -1) {
                cout << "Ключ найден на позиции: " << result << endl;
            } else {
                cout << "Ключ не найден" << endl;
            }
            break;
        }
        case 2: {
            int key;
            cout << "Введите ключ для бинарного поиска: ";
            cin >> key;
            int result = BinarySearch(key);
            if (result != -1) {
                cout << "Ключ найден на позиции: " << result << endl;
            } else {
                cout << "Ключ не найден" << endl;
            }
            break;
        }
        case 3: {
            int binary;
            cout << "Введите двоичное число: ";
            cin >> binary;
            cout << "Десятичное представление: " << BinaryToDecimal(binary) << endl;
            break;
        }
        default:
            cout << "Неверный выбор" << endl;
        }
    }
    return 0;
}
