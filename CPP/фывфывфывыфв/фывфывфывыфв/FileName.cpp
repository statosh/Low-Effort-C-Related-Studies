#include <iostream>
using namespace std;

int main() {
    setlocale(LC_ALL, "Russian");

    char roman[100]; 

    while (true) {
        cout << "������� ������� ����� (��� 'quit' ��� ������): ";
        cin >> roman;

        if (strcmp(roman, "quit") == 0) {
            break;
        }

        int state = 1; 
        int n = 0;     
        bool error = false; 

        for (int i = 0; roman[i] != '\0'; ++i) {
            char symbol = roman[i];
            switch (symbol) {
            case 'X':
                switch (state) {
                case 1:
                    n = 10;
                    state = 2;
                    break;
                case 2:
                    n += 10;
                    state = 2;
                    break;
                case 3:
                case 4:
                case 5:
                    cout << "������: �������� ������� ��������\n";
                    error = true;
                    break;
                case 6:
                    n += 8;
                    state = 7;
                    break;
                case 7:
                    cout << "������: �������� ������� ��������\n";
                    error = true;
                    break;
                default:
                    cout << "������: �������� ���������\n";
                    error = true;
                    break;
                }
                break;
            case 'V':
                switch (state) {
                case 1:
                    n = 5;
                    state = 3;
                    break;
                case 2:
                    n += 5;
                    state = 3;
                    break;
                case 3:
                case 4:
                case 5:
                    cout << "������: �������� ������� ��������\n";
                    error = true;
                    break;
                case 6:
                    n += 3;
                    state = 7;
                    break;
                case 7:
                    cout << "������: �������� ������� ��������\n";
                    error = true;
                    break;
                default:
                    cout << "������: �������� ���������\n";
                    error = true;
                    break;
                }
                break;
            case 'I':
                switch (state) {
                case 1:
                    n = 1;
                    state = 6;
                    break;
                case 2:
                    n += 1;
                    state = 6;
                    break;
                case 3:
                    n += 1;
                    state = 4;
                    break;
                case 4:
                    n += 1;
                    state = 5;
                    break;
                case 5:
                    cout << "������: �������� ������� ��������\n";
                    error = true;
                    break;
                case 6:
                case 7:
                    n += 1;
                    state = 7;
                    break;
                default:
                    cout << "������: �������� ���������\n";
                    error = true;
                    break;
                }
                break;

            default:
                cout << "������: �������� ������ '" << symbol << "'\n";
                error = true;
                break;
            }
            if (error) {
                break;
            }
        }
        if (!error) {
            cout << "���������� ��������: " << n << endl;
        }
    }
    cout << "��������� ���������." << endl;
    return 0;
}