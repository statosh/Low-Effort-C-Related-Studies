#include <iostream>
using namespace std;

int main() {
    setlocale(LC_ALL, "Russian");
    
    double x;

    cout << "������� ����� � �����������: ";
    cin >> x;
    cout << "����� � ������: " << x / 2.542;
}