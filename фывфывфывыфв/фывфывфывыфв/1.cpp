#include <iostream>
using namespace std;

int main() {
    setlocale(LC_ALL, "Russian");

    int a;
    cout << "������� ����� ����� a: ";
    cin >> a;

    int sum = 0;
    for (int i = a; i <= 500; i++) {
        sum += i;
    }

    cout << "����� ����� ����� �� " << a << " �� 500: " << sum << endl;
    return 0;
}