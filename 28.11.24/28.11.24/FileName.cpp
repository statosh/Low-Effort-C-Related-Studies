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



// �������� � ���������� �������
int findMax(int arr[], int size) {
    int maxVal = arr[0];
    for (int i = 1; i < size; ++i) {
        if (arr[i] > maxVal) {
            maxVal = arr[i];
        }
    }
    return maxVal;
}

// �������� � ��������� �������
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

// �������� � ��������� �������
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

// �������� ����� ���� �����
int findMax(int a, int b) {
    return (a > b) ? a : b;
}

// �������� ����� ��� �����
int findMax(int a, int b, int c) {
    return findMax(findMax(a, b), c);
}



int main() {
    setlocale(LC_ALL, "Russian");
    char input[10];
    while (true) {
        cout << R"(
1) ������� ����� (����������)
2) ������� N ����
3) ����� ����� �� A �� B
4) ����� �������� � �������

������� ����� �������� (��� 'quit' ��� ������): )";
        cin >> input;

        if (strcmp(input, "quit") == 0) break;

        int choice = atoi(input);
        switch (choice) {
        case 1: {
            int base, exponent;
            cout << endl << "������� ��������� � ���������� �������: ";
            cin >> base >> exponent;
            cout << "���������: " << PowerRecursive(base, exponent) << endl;
            break;
        }
        case 2: {
            int n;
            cout << endl << "������� ���������� ����: ";
            cin >> n;
            PrintStars(n);
            cout << endl;
            break;
        }
        case 3: {
            int a, b;
            cout << endl << "������� ��� ����� (A � B): ";
            cin >> a >> b;
            cout << "����� ����� �� " << a << " �� " << b << ": " << SumInRange(a, b) << endl;
            break;
        }
        case 4: {

            int arr1[] = { 1, 5, 3, 9, 2 };
            cout << endl << "�������� � ���������� ������� { 1, 5, 3, 9, 2 }\n--------------------\n" << findMax(arr1, 5) << endl;

            int arr2[2][3] = { {1, 2, 3}, {7, 5, 6} };
            cout << endl << "�������� � ��������� ������� { {1, 2, 3}, {7, 5, 6} }\n--------------------\n" << findMax(arr2, 2, 3) << endl;

            int arr3[2][3][3] = { {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}}, {{10, 11, 12}, {13, 14, 15}, {16, 17, 18}} };
            cout << endl << "�������� � ��������� ������� { {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}}, {{10, 11, 12}, {13, 14, 15}, {16, 17, 18}} }\n--------------------\n" << findMax(arr3, 2, 3, 3) << endl;

            cout << endl << "�������� �� ���� ����� (10 � 20): " << findMax(10, 20) << endl;

            cout << "�������� �� ��� ����� (10, 20 � 15): " << findMax(10, 20, 15) << endl;

            break;
        }
        default:
            cout << "�������� �����!" << endl;
        }
    }
    return 0;
}
