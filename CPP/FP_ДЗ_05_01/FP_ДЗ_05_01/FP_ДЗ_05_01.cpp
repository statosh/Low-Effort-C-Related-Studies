#include <iostream>
using namespace std;

void main() {
    setlocale(LC_ALL, "Russian");
    char input_char;

    cout << "Введите символ: ";
    cin >> input_char;

    if ((input_char >= 'A' && input_char <= 'Z') || (input_char >= 'a' && input_char <= 'z') || 
        (input_char >= 'А' && input_char <= 'Я') || (input_char >= 'а' && input_char <= 'я')) {
        cout << "Это буква." << endl;
    } else if (input_char >= '0' && input_char <= '9') {
        cout << "Это цифра." << endl;
    } else if ((input_char >= 33 && input_char <= 47) ||
        (input_char >= 58 && input_char <= 64) ||
        (input_char >= 91 && input_char <= 96) ||
        (input_char >= 123 && input_char <= 126)) {
        cout << "Это знак препинания." << endl;
    } else {
        cout << "Это другой символ." << endl;
    }
}