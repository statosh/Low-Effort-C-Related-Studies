#include <iostream>
#include <cctype>
using namespace std;

void checkEvenOdd() {
    int num;
    cout << "\nВведите целое число: ";
    cin >> num;
    cout << "Число " << (num % 2 == 0 ? "четное" : "нечетное") << endl;
}

void checkLeapYear() {
    int year;
    cout << "\nВведите год: ";
    cin >> year;
    cout << "Год " << (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0) ? "високосный" : "невисокосный") << endl;
}

void checkVowelOrConsonant() {
    char letter;
    cout << "\nВведите букву: ";
    cin >> letter;
    letter = tolower(letter);
    if (!isalpha(letter)) {
        cout << "Не является буквой" << endl;
    } else if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u') {
        cout << "Гласная" << endl;
    } else {
        cout << "Согласная" << endl;
    }
}

void monthName() {
    int month;
    cout << "\nВведите номер месяца: ";
    cin >> month;
    const char* months[] = {
        "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
        "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
    };
    if (month >= 1 && month <= 12) {
        cout << months[month - 1] << endl;
    } else {
        cout << "Неверный номер месяца" << endl;
    }
}

void checkPointInCircle() {
    double x, y, r;
    cout << "\nВведите координату X: ";
    cin >> x;
    cout << "Введите координату Y: ";
    cin >> y;
    cout << "Введите радиус R: ";
    cin >> r;
    double distance = x * x + y * y;
    double radiusSquared = r * r;
    if (distance < radiusSquared) {
        cout << "Точка внутри круга" << endl;
    } else if (distance > radiusSquared) {
        cout << "Точка вне круга" << endl;
    } else {
        cout << "Точка на границе круга" << endl;
    }
}

int main() {
    setlocale(LC_ALL, "Russian");

    int choice;
    while (true) {
        cout << R"(
Выберите действие:
1) Проверить четность числа
2) Проверить високосный год
3) Определить гласную или согласную букву
4) Вывести название месяца по номеру
5) Проверить попадание точки в круг
0) Выход
Введите номер действия: )";
        cin >> choice;

        switch (choice) {
        case 1: checkEvenOdd(); break;
        case 2: checkLeapYear(); break;
        case 3: checkVowelOrConsonant(); break;
        case 4: monthName(); break;
        case 5: checkPointInCircle(); break;
        case 0:
            cout << "Выход из программы.\n";
            return 0;
        default:
            cout << "Неверный выбор! Попробуйте снова." << endl;
        }
    }

    return 0;
}
