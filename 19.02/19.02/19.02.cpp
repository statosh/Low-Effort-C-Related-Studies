#include <iostream>
#include <cstdlib>
#include <ctime>
using namespace std;

template <typename T>
T square(T value) {
    return value * value;
}

template <typename T>
class Array {
private:
    T* data;
    int size;

public:
    Array(int s) : size(s) {
        data = new T[size];
    }

    ~Array() {
        delete[] data;
    }

    void fillRandom(T min, T max) {
        for (int i = 0; i < size; ++i) {
            if constexpr (is_floating_point<T>::value)
                data[i] = min + static_cast<T>(rand()) / (static_cast<T>(RAND_MAX / (max - min)));
            else
                data[i] = min + rand() % (max - min + 1);
        }
    }

    T sum() {
        T total = 0;
        for (int i = 0; i < size; ++i) {
            total += data[i];
        }
        return total;
    }

    double average() {
        return static_cast<double>(sum()) / size;
    }

    void print() {
        for (int i = 0; i < size; ++i) {
            cout << data[i] << " ";
        }
        cout << endl;
    }
};

int main() {
    setlocale(LC_ALL, "Russian");
    srand(time(0));

    while (true) {
        cout << R"(
Меню:
1. Вычислить квадрат числа
2. Создать массив и вычислить сумму и среднее значение
0. Выход
Выберите действие: )";

        int choice;
        cin >> choice;

        switch (choice) {
        case 1: {
            cout << "Введите число: ";
            double num;
            cin >> num;
            cout << "Квадрат числа: " << square(num) << endl;
            break;
        }
        case 2: {
            cout << "Введите размер массива: ";
            int size;
            cin >> size;

            cout << "Выберите тип массива (1 - int, 2 - double): ";
            int type;
            cin >> type;

            if (type == 1) {
                Array<int> arr(size);
                arr.fillRandom(1, 100);
                arr.print();
                cout << "Сумма: " << arr.sum() << ", Среднее: " << arr.average() << endl;
            } else if (type == 2) {
                Array<double> arr(size);
                arr.fillRandom(1.0, 100.0);
                arr.print();
                cout << "Сумма: " << arr.sum() << ", Среднее: " << arr.average() << endl;
            } else {
                cout << "Ошибка: неверный выбор типа!" << endl;
            }
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
