#include <iostream>
#include <ctime>
using namespace std;

void mergeArrays(int* A, int M, int* B, int N, int* C, int* size) {
    *size = 0;
    for (int i = 0; i < M; ++i) {
        *(C + (*size)++) = *(A + i);
    }
    for (int i = 0; i < N; ++i) {
        *(C + (*size)++) = *(B + i);
    }
}

void mergeUniqueArrays(int* A, int M, int* B, int N, int* C, int* size) {
    *size = 0;
    for (int i = 0; i < M; ++i) {
        bool found = false;
        for (int j = 0; j < *size; ++j) {
            if (*(C + j) == *(A + i)) {
                found = true;
                break;
            }
        }
        if (!found) {
            *(C + (*size)++) = *(A + i);
        }
    }
    for (int i = 0; i < N; ++i) {
        bool found = false;
        for (int j = 0; j < *size; ++j) {
            if (*(C + j) == *(B + i)) {
                found = true;
                break;
            }
        }
        if (!found) {
            *(C + (*size)++) = *(B + i);
        }
    }
}

void removeElements(int* arr, int* size, bool removeEven) {
    int* end = arr + *size;
    int* current = arr;

    for (int* it = arr; it < end; ++it) {
        if ((removeEven && *it % 2 != 0) || (!removeEven && *it % 2 == 0)) {
            *current++ = *it;
        }
    }

    *size = current - arr;
}

void printArray(int* arr, int size) {
    for (int i = 0; i < size; ++i) {
        cout << *(arr + i) << " ";
    }
    cout << endl;
}

int main() {
    setlocale(LC_ALL, "Russian");
    srand(static_cast<unsigned>(time(0)));

    int M, N;
    cout << "Введите размер первого массива: ";
    cin >> M;
    cout << "Введите размер второго массива: ";
    cin >> N;

    int* A = new int[M];
    int* B = new int[N];

    cout << "Первый массив: ";
    for (int i = 0; i < M; ++i) {
        *(A + i) = rand() % 100;
        cout << *(A + i) << " ";
    }
    cout << endl;

    cout << "Второй массив: ";
    for (int i = 0; i < N; ++i) {
        *(B + i) = rand() % 100;
        cout << *(B + i) << " ";
    }
    cout << endl;

    char input[10];
    while (true) {
        cout << R"(
1) Объединение массивов
2) Объединение массивов без повторений
3) Удаление чётных/нечётных чисел
Введите номер действия (или 'quit' для выхода): )";
        cin >> input;

        if (strcmp(input, "quit") == 0) break;

        int choice = atoi(input);
        switch (choice) {
        case 1: {
            int* C = new int[M + N];
            int size;
            mergeArrays(A, M, B, N, C, &size);

            cout << "Результирующий массив (объединение): ";
            printArray(C, size);

            delete[] C;
            break;
        }
        case 2: {
            int* C = new int[M + N];
            int size;
            mergeUniqueArrays(A, M, B, N, C, &size);

            cout << "Результирующий массив (без повторений): ";
            printArray(C, size);

            delete[] C;
            break;
        }
        case 3: {
            char choice;
            cout << "Введите 'e' для удаления чётных или 'o' для удаления нечётных: ";
            cin >> choice;

            bool removeEven = (choice == 'e');
            cout << "Исходный массив: ";
            printArray(A, M);

            removeElements(A, &M, removeEven);

            cout << "Результирующий массив: ";
            printArray(A, M);
            break;
        }
        default:
            cout << "Неверный выбор!" << endl;
        }
    }

    delete[] A;
    delete[] B;

    return 0;
}
