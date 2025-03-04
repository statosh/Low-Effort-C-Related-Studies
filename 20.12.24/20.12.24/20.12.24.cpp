#include <iostream>
#include <string>
#include <windows.h>
using namespace std;

void ReplaceAndCountWords(string& text) {
    string target = "дублирование";
    string replacement = "копирование";
    size_t pos = 0, wordCount = 0;
    bool inWord = false;

    while (pos < text.length()) {
        if (isspace(static_cast<unsigned char>(text[pos])) || ispunct(static_cast<unsigned char>(text[pos]))) {
            if (inWord) wordCount++;
            inWord = false;
        } else {
            inWord = true;
        }

        if (text.substr(pos, target.length()) == target) {
            text.replace(pos, target.length(), replacement);
            pos += replacement.length();
        } else {
            pos++;
        }
    }

    if (inWord) wordCount++;

    cout << "Измененный текст: " << text << endl;
    cout << "Количество слов: " << wordCount << endl;
}

void RemoveSpacesInParentheses(string& text) {
    for (size_t i = 0; i < text.length(); i++) {
        if (text[i] == '(') {
            size_t j = i + 1;
            while (j < text.length() && text[j] == ' ') j++;
            text.erase(i + 1, j - (i + 1));
        }
        if (text[i] == ')') {
            size_t j = i - 1;
            while (j >= 0 && text[j] == ' ') j--;
            text.erase(j + 1, i - (j + 1));
            i = j + 1;
        }
    }
    cout << "Измененный текст: " << text << endl;
}

int main() {
    SetConsoleOutputCP(1251);
    SetConsoleCP(1251);
    string text, input;

    while (true) {
        cout << R"(
Выберите действие:
1) Заменить <дублирование> на <копирование> и подсчитать слова.
2) Удалить пробелы внутри скобок.
Введите "quit" для выхода.
)";
        cin >> input;
        if (input == "quit") break;

        int choice = input[0] - '0';
        cin.ignore();

        switch (choice) {
        case 1:
            cout << "Введите текст: ";
            getline(cin, text);
            ReplaceAndCountWords(text);
            break;
        case 2:
            cout << "Введите текст: ";
            getline(cin, text);
            RemoveSpacesInParentheses(text);
            break;
        default:
            cout << "Неверный выбор. Попробуйте снова.\n";
        }
    }

    return 0;
}
