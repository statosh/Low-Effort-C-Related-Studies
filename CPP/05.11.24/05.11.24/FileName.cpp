#include <iostream>
#include <cstdlib>
#include <ctime>
using namespace std;

void generateRandomArray(int arr[], int size) {
    for (int i = 0; i < size; ++i) {
        arr[i] = rand() % 51 - 25;
        cout << arr[i] << " ";
    }
    cout << endl;
}

void generateRandomMatrix(int matrix[][4], int rows, int cols) {
    for (int i = 0; i < rows; ++i) {
        for (int j = 0; j < cols; ++j) {
            matrix[i][j] = rand() % 51 - 25;
            cout << matrix[i][j] << "\t";
        }
        cout << endl;
    }
}

void sumArray(int arr[], int size) {
    int sum = 0;
    for (int i = 0; i < size; ++i) {
        sum += arr[i];
    }
    cout << "Сумма элементов массива: " << sum << endl;
}

void productArray(int arr[], int size) {
    int product = 1;
    for (int i = 0; i < size; ++i) {
        product *= arr[i];
    }
    cout << "Произведение элементов массива: " << product << endl;
}

void sumMainDiagonal(int matrix[][4], int size) {
    int sum = 0;
    for (int i = 0; i < size; ++i) {
        sum += matrix[i][i];
    }
    cout << "Сумма элементов на главной диагонали: " << sum << endl;
}

void sumBelowMainDiagonal(int matrix[][4], int size) {
    int sum = 0;
    for (int i = 1; i < size; ++i) {
        for (int j = 0; j < i; ++j) {
            sum += matrix[i][j];
        }
    }
    cout << "Сумма элементов ниже главной диагонали: " << sum << endl;
}

void sumAboveMainDiagonal(int matrix[][4], int size) {
    int sum = 0;
    for (int i = 0; i < size - 1; ++i) {
        for (int j = i + 1; j < size; ++j) {
            sum += matrix[i][j];
        }
    }
    cout << "Сумма элементов выше главной диагонали: " << sum << endl;
}

void productSecondaryDiagonal(int matrix[][4], int size) {
    int product = 1;
    for (int i = 0; i < size; ++i) {
        product *= matrix[i][size - i - 1];
    }
    cout << "Произведение элементов на побочной диагонали: " << product << endl;
}

void maxEvenRows(int matrix[][4], int rows, int cols) {
    for (int i = 0; i < rows; i += 2) {
        int maxElem = matrix[i][0];
        for (int j = 1; j < cols; ++j) {
            if (matrix[i][j] > maxElem) {
                maxElem = matrix[i][j];
            }
        }
        cout << "Максимум в четной строке " << i << ": " << maxElem << endl;
    }
}

void minOddColumns(int matrix[][4], int rows, int cols) {
    for (int j = 1; j < cols; j += 2) {
        int minElem = matrix[0][j];
        for (int i = 1; i < rows; ++i) {
            if (matrix[i][j] < minElem) {
                minElem = matrix[i][j];
            }
        }
        cout << "Минимум в нечетном столбце " << j << ": " << minElem << endl;
    }
}

int main() {
    setlocale(LC_ALL, "Russian");
    srand(time(0));

    const int arrSize = 5;
    int arr[arrSize];
    int matrix[4][4];
    int matrixSize = 4;

    cout << "Сгенерированный одномерный массив:" << endl;
    generateRandomArray(arr, arrSize);

    cout << endl << "Сгенерированная матрица:" << endl;
    generateRandomMatrix(matrix, matrixSize, matrixSize);

    string input;
    while (true) {
        cout << R"(
 1) Найти сумму элементов одномерного массива;
 2) Найти произведение элементов одномерного массива;
 3) Найти сумму элементов матрицы, расположенных на главной диагонали;
 4) Найти сумму элементов матрицы, расположенных ниже главной диагонали;
 5) Найти сумму элементов матрицы, расположенных выше главной диагонали;
 6) Найти произведение элементов матрицы, расположенных на побочной диагонали;
 7) Найти максимумы четных строк матрицы;
 8) Найти минимумы нечетных столбцов матрицы;

Введите номер действия (или 'quit' для выхода): )";
        cin >> input;

        if (input == "quit") {
            break;
        }

        int choice = input[0] - '0';
        switch (choice) {
        case 1:
            sumArray(arr, arrSize);
            break;
        case 2:
            productArray(arr, arrSize);
            break;
        case 3:
            sumMainDiagonal(matrix, matrixSize);
            break;
        case 4:
            sumBelowMainDiagonal(matrix, matrixSize);
            break;
        case 5:
            sumAboveMainDiagonal(matrix, matrixSize);
            break;
        case 6:
            productSecondaryDiagonal(matrix, matrixSize);
            break;
        case 7:
            maxEvenRows(matrix, matrixSize, matrixSize);
            break;
        case 8:
            minOddColumns(matrix, matrixSize, matrixSize);
            break;
        default:
            cout << "Неверный выбор! Попробуйте снова." << endl;
        }
    }

    return 0;
}
