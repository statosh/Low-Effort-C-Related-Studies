#include <iostream>
using namespace std;

int main() {
    setlocale(LC_ALL, "Russian");

    int x, y;
    cout << "������� ����� ����� x: ";
    cin >> x;
    cout << "������� ����� ����� y: ";
    cin >> y;

    long long result = 1;
    for (int i = 0; i < y; i++) {
        result *= x;
    }

    cout << x << " � ������� " << y << " �����: " << result << endl;
    return 0;
}