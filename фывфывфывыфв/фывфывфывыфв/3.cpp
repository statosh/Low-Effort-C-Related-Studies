#include <iostream>
using namespace std;

int main() {
    setlocale(LC_ALL, "Russian");

    int sum = 0;
    int count = 1000;

    for (int i = 1; i <= count; i++) {
        sum += i;
    }

    double average = static_cast<double>(sum) / count;
    cout << "������� �������������� ���� ����� ����� �� 1 �� 1000: " << average << endl;
    return 0;
}