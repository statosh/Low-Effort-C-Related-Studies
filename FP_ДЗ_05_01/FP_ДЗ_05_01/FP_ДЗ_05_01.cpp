#include <iostream>
using namespace std;

void main() {
    setlocale(LC_ALL, "Russian");
    char input_char;

    cout << "������� ������: ";
    cin >> input_char;

    if ((input_char >= 'A' && input_char <= 'Z') || (input_char >= 'a' && input_char <= 'z') || 
        (input_char >= '�' && input_char <= '�') || (input_char >= '�' && input_char <= '�')) {
        cout << "��� �����." << endl;
    } else if (input_char >= '0' && input_char <= '9') {
        cout << "��� �����." << endl;
    } else if ((input_char >= 33 && input_char <= 47) ||
        (input_char >= 58 && input_char <= 64) ||
        (input_char >= 91 && input_char <= 96) ||
        (input_char >= 123 && input_char <= 126)) {
        cout << "��� ���� ����������." << endl;
    } else {
        cout << "��� ������ ������." << endl;
    }
}