#include <iostream>
using namespace std;

void main(){
    setlocale(LC_ALL, "Russian");

    double x, y;
    int z;

    cout << "Введите первое число: ";
    cin >> x;
    cout << "Введите второе число: ";
    cin >> y;

    cout << R"(
Выберите действие которое нужно произвести с числами:
    1) Сложение
    2) Вычитание
    3) Умножение
    4) Деление
)";
    cin >> z;

    switch (z) {
        case 1:
            cout << "Результат сложения: " << x + y;
        break;

        case 2:
            cout << "Результат вычитания: " << x - y;
        break;

        case 3:
            cout << "Результат умножения: " << x * y;
        break;

        case 4:
            if (y != 0) {
                cout << "Результат деления: " << x / y;
            } else if (y == 0) {
                cout << "Нельзя делить на 0";
            }
        break;

        default:
            cout << R"(
Baddadan, baddadan, baddadan
Anywhere we see dem we ah bang pon another one
Buss up 45, 9, Colt and Remington
Any boy diss Balla tun him skeleton
Badman you know wie vibes can't dun
Vibes can't dun, we ah kill sound boy fi fun
Big bad man from outta England
Bassline drop, ah tear the whole place down
Nobody badder than we
Nobody badder than we
Nobody badder than we
Nobody badder than we
)";
        break;
    }

    /*
    if (z == 1) {
        cout << "Результат сложения: " << x + y;
    } else if (z == 2) {
        cout << "Результат вычитания: " << x - y;
    } else if (z == 3) {
        cout << "Результат умножения: " << x * y;
    } else if (z == 4 && y != 0) {
        cout << "Результат деления: " << x / y;
    } else if (z == 4 && y == 0) {
        cout << "Нельзя делить на 0";
    }
    */

}