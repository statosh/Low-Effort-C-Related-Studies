#include <iostream>
using namespace std;

int PowerRecursive(int base, int exponent) {
    if (exponent == 0) return 1;
    return base * PowerRecursive(base, exponent - 1);
}

void PrintStars(int n) {
    if (n <= 0) return;
    cout << "*";
    PrintStars(n - 1);
}

int SumInRange(int a, int b) {
    if (a > b) return 0;
    return a + SumInRange(a + 1, b);
}

int main() {
    setlocale(LC_ALL, "Russian");
    string input;

    while (true) {
        cout << R"(
�������� �������:
1) ���������� ������� ����� (����������)
2) ������� N ���� � ��� (����������)
3) ����� ���� ����� � ��������� [a, b] (����������)
������� "quit" ��� ������.
)";

        cin >> input;
        if (input == "quit") break;

        int choice = input[0] - '0';
        switch (choice) {
        case 1: {
            int base, exponent;
            cout << "������� ��������� � ���������� �������: ";
            cin >> base >> exponent;
            cout << "���������: " << PowerRecursive(base, exponent) << endl;
            break;
        }
        case 2: {
            int n;
            cout << "������� ���������� ����: ";
            cin >> n;
            PrintStars(n);
            cout << endl;
            break;
        }
        case 3: {
            int a, b;
            cout << "������� ��� ����� (a � b): ";
            cin >> a >> b;
            if (a > b) swap(a, b);
            cout << "����� ����� � ��������� [" << a << ", " << b << "]: " << SumInRange(a, b) << endl;
            break;
        }
        default:
            cout << "�������� �����. ���������� �����." << endl;
        }
    }
    return 0;
}
