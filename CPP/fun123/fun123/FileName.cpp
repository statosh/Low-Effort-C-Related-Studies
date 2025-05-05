#include <iostream>
#include <string>

using namespace std;

int main() {
    setlocale(LC_ALL, "Russian");
    string romanInput;

    while (true) {
        cout << "Введите римское число (или 'quit' для завершения): ";
        cin >> romanInput;

        if (romanInput == "quit" || romanInput == "QUIT") {
            break;
        }

        int total = 0;
        int prevValue = 0;
        bool valid = true;

        for (char ch : romanInput) {
            int currentValue = 0;

            switch (ch) {
            case 'I':
                currentValue = 1;
                break;
            case 'V':
                currentValue = 5;
                break;
            case 'X':
                currentValue = 10;
                break;
            case 'L':
                currentValue = 50;
                break;
            case 'C':
                currentValue = 100;
                break;
            case 'D':
                currentValue = 500;
                break;
            case 'M':
                currentValue = 1000;
                break;
            default:
                cout << "Ошибка: неверный символ " << ch << endl;
                valid = false;
                break;
            }

            if (!valid) {
                break;
            }

            if (currentValue > prevValue) {
                total += currentValue - 2 * prevValue;
            } else {
                total += currentValue;
            }

            prevValue = currentValue;
        }

        if (valid) {
            cout << "Десятичное значение: " << total << endl;
        }
    }

    return 0;
}