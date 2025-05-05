#include <iostream>
#include <fstream>
#include <string>
#include <windows.h>
using namespace std;

struct Student {
    string name;
    string group;
    double averageGrade;
};

void addStudent(const string& filename) {
    ofstream file(filename, ios::app);
    if (!file.is_open()) {
        cerr << "Ошибка открытия файла для записи." << endl;
        return;
    }

    Student student;
    cout << "Введите ФИО: ";
    cin.ignore();
    getline(cin, student.name);

    cout << "Введите номер группы: ";
    getline(cin, student.group);

    cout << "Введите средний балл: ";
    cin >> student.averageGrade;

    file << student.name << "|" << student.group << "|" << student.averageGrade << endl;
    file.close();

    cout << "Запись добавлена успешно!" << endl;
}

void viewStudents(const string& filename) {
    ifstream file(filename);
    if (!file.is_open()) {
        cerr << "Ошибка открытия файла для чтения." << endl;
        return;
    }

    cout << "Список студентов:" << endl;
    string line;
    while (getline(file, line)) {
        size_t pos1 = line.find('|');
        size_t pos2 = line.find('|', pos1 + 1);

        if (pos1 != string::npos && pos2 != string::npos) {
            string name = line.substr(0, pos1);
            string group = line.substr(pos1 + 1, pos2 - pos1 - 1);
            double averageGrade = stod(line.substr(pos2 + 1));

            cout << "ФИО: " << name << ", Группа: " << group << ", Средний балл: " << averageGrade << endl;
        }
    }

    file.close();
}

void findStudent(const string& filename) {
    ifstream file(filename); 
    if (!file.is_open()) {
        cerr << "Ошибка открытия файла для чтения." << endl;
        return;
    }

    cout << "Введите ФИО студента для поиска: ";
    cin.ignore();
    string searchName;
    getline(cin, searchName);

    string line;
    bool found = false;

    while (getline(file, line)) {
        size_t pos1 = line.find('|');
        size_t pos2 = line.find('|', pos1 + 1);

        if (pos1 != string::npos && pos2 != string::npos) {
            string name = line.substr(0, pos1);
            string group = line.substr(pos1 + 1, pos2 - pos1 - 1);
            double averageGrade = stod(line.substr(pos2 + 1));

            if (name == searchName) {
                cout << "Студент найден!" << endl;
                cout << "ФИО: " << name << ", Группа: " << group << ", Средний балл: " << averageGrade << endl;
                found = true;
                break;
            }
        }
    }

    if (!found) {
        cout << "Студент с именем \"" << searchName << "\" не найден." << endl;
    }

    file.close();
}

int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    const string filename = "students.txt";

    cout << "Добро пожаловать в систему учета студентов!" << endl;

    while (true) {
        cout << R"(
Меню:
1. Добавить нового студента
2. Просмотреть список студентов
3. Найти студента по ФИО
4. Выход
Ваш выбор: )";

        int choice;
        cin >> choice;

        switch (choice) {
        case 1:
            addStudent(filename);
            break;
        case 2:
            viewStudents(filename);
            break;
        case 3:
            findStudent(filename);
            break;
        case 4:
            cout << "Выход из программы." << endl;
            return 0;
        default:
            cout << "Неверный выбор. Попробуйте снова." << endl;
        }
    }

    return 0;
}
