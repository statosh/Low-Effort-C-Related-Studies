#include <iostream>
#include <cstdlib>
#include <ctime>
using namespace std;

double average(double* arr, int size) {
    double sum = 0;
    for (int i = 0; i < size; ++i) {
        sum += *(arr + i);
    }
    return sum / size;
}

void initializeMatrix(int** matrix, int rows, int cols) {
    srand(time(0));
    for (int i = 0; i < rows; ++i) {
        for (int j = 0; j < cols; ++j) {
            matrix[i][j] = rand() % 100 + 1;
        }
    }
}

void printMatrix(int** matrix, int rows, int cols) {
    for (int i = 0; i < rows; ++i) {
        for (int j = 0; j < cols; ++j) {
            cout << matrix[i][j] << " ";
        }
        cout << endl;
    }
}

int sumMatrix(int** matrix, int rows, int cols) {
    int sum = 0;
    for (int i = 0; i < rows; ++i) {
        for (int j = 0; j < cols; ++j) {
            sum += matrix[i][j];
        }
    }
    return sum;
}

// Исправленная функция транспонирования
void transposeMatrix(int**& matrix, int& rows, int& cols) {
    int** temp = new int* [cols];
    for (int i = 0; i < cols; ++i) {
        temp[i] = new int[rows];
    }

    for (int i = 0; i < rows; ++i) {
        for (int j = 0; j < cols; ++j) {
            temp[j][i] = matrix[i][j];
        }
    }

    for (int i = 0; i < rows; ++i) {
        delete[] matrix[i];
    }
    delete[] matrix;

    matrix = temp;
    swap(rows, cols);
}

void swapRowsAndCols(int** matrix, int rows, int cols) {
    for (int i = 0; i < rows; ++i) {
        for (int j = i + 1; j < cols; ++j) {
            swap(matrix[i][j], matrix[j][i]);
        }
    }
}

int main() {
    setlocale(LC_ALL, "Russian");

    while (true) {
        cout << R"(
Меню:
6. Среднее арифметическое массива
7. Создание и инициализация двумерного массива
8. Сумма элементов двумерного массива
9. Транспонирование матрицы
10. Перестановка строк и столбцов
0. Выход
Выберите действие: )";

        int choice;
        cin >> choice;

        switch (choice) {
        case 6: {
            int size;
            cout << "Введите размер массива: ";
            cin >> size;
            double* arr = new double[size];
            cout << "Введите элементы массива: ";
            for (int i = 0; i < size; ++i) {
                cin >> arr[i];
            }
            cout << "Среднее арифметическое: " << average(arr, size) << endl;
            delete[] arr;
            break;
        }
        case 7: {
            int rows, cols;
            cout << "Введите количество строк и столбцов: ";
            cin >> rows >> cols;
            int** matrix = new int* [rows];
            for (int i = 0; i < rows; ++i) {
                matrix[i] = new int[cols];
            }
            initializeMatrix(matrix, rows, cols);
            printMatrix(matrix, rows, cols);
            for (int i = 0; i < rows; ++i) {
                delete[] matrix[i];
            }
            delete[] matrix;
            break;
        }
        case 8: {
            int rows, cols;
            cout << "Введите количество строк и столбцов: ";
            cin >> rows >> cols;
            int** matrix = new int* [rows];
            for (int i = 0; i < rows; ++i) {
                matrix[i] = new int[cols];
            }
            initializeMatrix(matrix, rows, cols);
            printMatrix(matrix, rows, cols);
            cout << "Сумма элементов: " << sumMatrix(matrix, rows, cols) << endl;
            for (int i = 0; i < rows; ++i) {
                delete[] matrix[i];
            }
            delete[] matrix;
            break;
        }
        case 9: {
            int rows, cols;
            cout << "Введите количество строк и столбцов: ";
            cin >> rows >> cols;
            int** matrix = new int* [rows];
            for (int i = 0; i < rows; ++i) {
                matrix[i] = new int[cols];
            }
            initializeMatrix(matrix, rows, cols);
            cout << "Исходная матрица:\n";
            printMatrix(matrix, rows, cols);
            transposeMatrix(matrix, rows, cols);
            cout << "Транспонированная матрица:\n";
            printMatrix(matrix, rows, cols);
            for (int i = 0; i < rows; ++i) {
                delete[] matrix[i];
            }
            delete[] matrix;
            break;
        }
        case 10: {
            int rows, cols;
            cout << "Введите количество строк и столбцов: ";
            cin >> rows >> cols;
            int** matrix = new int* [rows];
            for (int i = 0; i < rows; ++i) {
                matrix[i] = new int[cols];
            }
            initializeMatrix(matrix, rows, cols);
            cout << "Исходная матрица:\n";
            printMatrix(matrix, rows, cols);
            swapRowsAndCols(matrix, rows, cols);
            cout << "Матрица после перестановки строк и столбцов:\n";
            printMatrix(matrix, rows, cols);
            for (int i = 0; i < rows; ++i) {
                delete[] matrix[i];
            }
            delete[] matrix;
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
