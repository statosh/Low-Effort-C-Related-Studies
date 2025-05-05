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
    cout << "����� ��������� �������: " << sum << endl;
}

void productArray(int arr[], int size) {
    int product = 1;
    for (int i = 0; i < size; ++i) {
        product *= arr[i];
    }
    cout << "������������ ��������� �������: " << product << endl;
}

void sumMainDiagonal(int matrix[][4], int size) {
    int sum = 0;
    for (int i = 0; i < size; ++i) {
        sum += matrix[i][i];
    }
    cout << "����� ��������� �� ������� ���������: " << sum << endl;
}

void sumBelowMainDiagonal(int matrix[][4], int size) {
    int sum = 0;
    for (int i = 1; i < size; ++i) {
        for (int j = 0; j < i; ++j) {
            sum += matrix[i][j];
        }
    }
    cout << "����� ��������� ���� ������� ���������: " << sum << endl;
}

void sumAboveMainDiagonal(int matrix[][4], int size) {
    int sum = 0;
    for (int i = 0; i < size - 1; ++i) {
        for (int j = i + 1; j < size; ++j) {
            sum += matrix[i][j];
        }
    }
    cout << "����� ��������� ���� ������� ���������: " << sum << endl;
}

void productSecondaryDiagonal(int matrix[][4], int size) {
    int product = 1;
    for (int i = 0; i < size; ++i) {
        product *= matrix[i][size - i - 1];
    }
    cout << "������������ ��������� �� �������� ���������: " << product << endl;
}

void maxEvenRows(int matrix[][4], int rows, int cols) {
    for (int i = 0; i < rows; i += 2) {
        int maxElem = matrix[i][0];
        for (int j = 1; j < cols; ++j) {
            if (matrix[i][j] > maxElem) {
                maxElem = matrix[i][j];
            }
        }
        cout << "�������� � ������ ������ " << i << ": " << maxElem << endl;
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
        cout << "������� � �������� ������� " << j << ": " << minElem << endl;
    }
}

int main() {
    setlocale(LC_ALL, "Russian");
    srand(time(0));

    const int arrSize = 5;
    int arr[arrSize];
    int matrix[4][4];
    int matrixSize = 4;

    cout << "��������������� ���������� ������:" << endl;
    generateRandomArray(arr, arrSize);

    cout << endl << "��������������� �������:" << endl;
    generateRandomMatrix(matrix, matrixSize, matrixSize);

    string input;
    while (true) {
        cout << R"(
 1) ����� ����� ��������� ����������� �������;
 2) ����� ������������ ��������� ����������� �������;
 3) ����� ����� ��������� �������, ������������� �� ������� ���������;
 4) ����� ����� ��������� �������, ������������� ���� ������� ���������;
 5) ����� ����� ��������� �������, ������������� ���� ������� ���������;
 6) ����� ������������ ��������� �������, ������������� �� �������� ���������;
 7) ����� ��������� ������ ����� �������;
 8) ����� �������� �������� �������� �������;

������� ����� �������� (��� 'quit' ��� ������): )";
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
            cout << "�������� �����! ���������� �����." << endl;
        }
    }

    return 0;
}
