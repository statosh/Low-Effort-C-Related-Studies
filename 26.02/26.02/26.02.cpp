#include <iostream>
#include <string>
#include <windows.h>
using namespace std;

int countSpaces(const string& text) {
    int count = 0;
    for (char ch : text) {
        if (ch == ' ') {
            count++;
        }
    }
    return count;
}

void task1() {
    string text1, text2;
    cout << "Введите первый текст: ";
    cin.ignore();
    getline(cin, text1);
    cout << "Введите второй текст: ";
    getline(cin, text2);

    int words1 = countSpaces(text1) + 1;
    int words2 = countSpaces(text2) + 1;

    cout << "Количество слов в первом тексте: " << words1 << endl;
    cout << "Количество слов во втором тексте: " << words2 << endl;

    if (words1 > words2) {
        cout << "Первый текст содержит больше слов.\n";
    } else if (words1 < words2) {
        cout << "Второй текст содержит больше слов.\n";
    } else {
        cout << "Оба текста содержат одинаковое количество слов.\n";
    }
}

void task2() {
    string word1, word2, word3;
    cout << "Введите три слова: ";
    cin >> word1 >> word2 >> word3;

    string result = word1.back() + string(" ") + word2.back() + " " + word3.back();
    cout << "Результат: " << result << endl;
}

void task3() {
    string input, output;
    cout << "Введите последовательность символов: ";
    cin.ignore();
    getline(cin, input);

    for (char ch : input) {
        if (ch == ' ') {
            continue;
        } else if (ch == '=') {
            output += "==";
        } else {
            output += ch;
        }
    }

    cout << "Результат: " << output << endl;
}

void task4() {
    string number, reversed;
    cout << "Введите число: ";
    cin >> number;

    reversed = string(number.rbegin(), number.rend());

    cout << "Число в обратном порядке: " << reversed << endl;
    if (number == reversed) {
        cout << "Число является перевёртышем.\n";
    } else {
        cout << "Число не является перевёртышем.\n";
    }
}

void task5() {
    string text, result;
    cout << "Введите текст с фигурными скобками: ";
    cin.ignore();
    getline(cin, text);

    size_t start = text.find('{');
    size_t end = text.find('}');

    if (start != string::npos && end != string::npos && start < end) {
        result = text.substr(start + 1, end - start - 1);
        cout << "Текст внутри фигурных скобок: " << result << endl;
    } else {
        cout << "Фигурные скобки не найдены или расположены некорректно.\n";
    }
}

int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    while (true) {
        cout << R"(
Меню:
1. Подсчёт слов в двух текстах
2. Последние буквы трёх слов
3. Удвоение "==" и пропуск пробелов
4. Проверка числа на перевёртыш
5. Извлечение текста из фигурных скобок
0. Выход
Выберите действие: )";

        int choice;
        cin >> choice;

        switch (choice) {
        case 1:
            task1();
            break;
        case 2:
            task2();
            break;
        case 3:
            task3();
            break;
        case 4:
            task4();
            break;
        case 5:
            task5();
            break;
        case 0:
            cout << "Выход из программы." << endl;
            return 0;
        default:
            cout << "Неверный выбор. Попробуйте снова." << endl;
        }
    }
}
