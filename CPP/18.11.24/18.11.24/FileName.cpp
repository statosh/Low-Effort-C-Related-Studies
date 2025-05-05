#include <iostream>
using namespace std;

void drawRectangle(int height, int width) {
    cout << endl;
    for (int i = 0; i < height; ++i) {
        for (int j = 0; j < width; ++j) {
            cout << "*";
        }
        cout << endl;
    }
}

int factorial(int num) {
    cout << endl;
    int result = 1;
    for (int i = 1; i <= num; ++i) {
        result *= i;
    }
    return result;
}

bool isPrime(int num) {
    cout << endl;
    if (num < 2) {
        return false;
    }
    for (int i = 2; i * i <= num; ++i) {
        if (num % i == 0) {
            return false;
        }
    }
    return true;
}

int cube(int num) {
    cout << endl;
    return num * num * num;
}

int maxOfTwo(int a = 6, int b) {
    cout << endl;
    return (a > b) ? a : b;
}

bool isPositive(int num) {
    cout << endl;
    return num > 0;
}

int main() {
    setlocale(LC_ALL, "Russian");
    string input;
    while (true) {
        cout << R"(
 1) ������� ������������� � �������� ������� � �������;
 2) ��������� ��������� �����;
 3) ���������, �������� �� ����� �������;
 4) ����� ��� �����;
 5) ����� ������� �� ���� �����;
 6) ���������, ������������� �� �����;

������� ����� �������� (��� 'quit' ��� ������): )";
        cin >> input;

        if (input == "quit") {
            break;
        }

        int choice = input[0] - '0';
        switch (choice) {
        case 1: {
            int height, width;
            cout << endl << "������� ������: ";
            cin >> height;
            cout << "������� ������: ";
            cin >> width;
            drawRectangle(height, width);
            break;
        }
        case 2: {
            int num;
            cout << endl << "������� �����: ";
            cin >> num;
            cout << "��������� ����� " << num << ": " << factorial(num) << endl;
            break;
        }
        case 3: {
            int num;
            cout << endl << "������� �����: ";
            cin >> num;
            if (isPrime(num)) {
                cout << num << " �������� ������� ������." << endl;
            } else {
                cout << num << " �� �������� ������� ������." << endl;
            }
            break;
        }
        case 4: {
            int num;
            cout << endl << "������� �����: ";
            cin >> num;
            cout << "��� ����� " << num << ": " << cube(num) << endl;
            break;
        }
        case 5: {
            int a, b;
            cout << endl << "������� ������ �����: ";
            cin >> a;
            cout << "������� ������ �����: ";
            cin >> b;
            cout << "���������� �� ���� �����: " << maxOfTwo(a, b) << endl;
            break;
        }
        case 6: {
            int num;
            cout << endl << "������� �����: ";
            cin >> num;
            if (isPositive(num)) {
                cout << num << " �������� �������������." << endl;
            } else {
                cout << num << " �������� �������������." << endl;
            }
            break;
        }
        default:
            cout << endl << "�������� �����! ���������� �����." << endl;
        }
    }
    return 0;
}