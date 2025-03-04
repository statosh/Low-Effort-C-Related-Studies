#include <iostream>
#include <fstream>
#include <string>
#include <windows.h>
using namespace std;

struct Student {
    string name;
    int id;
    Student* next;
};

void addStudent(Student*& head, const string& name, int id) {
    Student* newStudent = new Student{ name, id, nullptr };
    if (!head) {
        head = newStudent;
    } else {
        Student* temp = head;
        while (temp->next) {
            temp = temp->next;
        }
        temp->next = newStudent;
    }
    cout << "Студент добавлен." << endl;
}

void deleteStudent(Student*& head, int id) {
    if (!head) {
        cout << "Список пуст." << endl;
        return;
    }
    if (head->id == id) {
        Student* temp = head;
        head = head->next;
        delete temp;
        cout << "Студент удалён." << endl;
        return;
    }
    Student* current = head;
    while (current->next && current->next->id != id) {
        current = current->next;
    }
    if (current->next) {
        Student* temp = current->next;
        current->next = current->next->next;
        delete temp;
        cout << "Студент удалён." << endl;
    } else {
        cout << "Студент с номером зачётной книжки " << id << " не найден." << endl;
    }
}

void findStudent(Student* head, int id) {
    while (head) {
        if (head->id == id) {
            cout << "Студент найден: " << head->name << ", номер зачётной книжки: " << head->id << endl;
            return;
        }
        head = head->next;
    }
    cout << "Студент с номером зачётной книжки " << id << " не найден." << endl;
}

void displayStudents(Student* head) {
    if (!head) {
        cout << "Список пуст." << endl;
        return;
    }
    while (head) {
        cout << "ФИО: " << head->name << ", номер зачётной книжки: " << head->id << endl;
        head = head->next;
    }
}

void saveToFile(Student* head, const string& filename) {
    ofstream file(filename);
    if (!file.is_open()) {
        cerr << "Ошибка открытия файла для записи." << endl;
        return;
    }
    while (head) {
        file << head->name << ";" << head->id << endl;
        head = head->next;
    }
    file.close();
    cout << "Список сохранён в файл." << endl;
}

void loadFromFile(Student*& head, const string& filename) {
    ifstream file(filename);
    if (!file.is_open()) {
        cerr << "Ошибка открытия файла для чтения." << endl;
        return;
    }
    string name;
    int id;
    while (getline(file, name, ';') && file >> id) {
        file.ignore();
        addStudent(head, name, id);
    }
    file.close();
    cout << "Список загружен из файла." << endl;
}

void clearList(Student*& head) {
    while (head) {
        Student* temp = head;
        head = head->next;
        delete temp;
    }
}

int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    Student* head = nullptr;
    const string filename = "students.txt";

    while (true) {
        cout << R"(
Меню:
1. Добавить студента
2. Удалить студента
3. Найти студента
4. Вывести всех студентов
5. Сохранить список в файл
6. Загрузить список из файла
0. Выход
Ваш выбор: )";
        int choice;
        cin >> choice;

        switch (choice) {
        case 1: {
            cout << "Введите ФИО: ";
            cin.ignore();
            string name;
            getline(cin, name);
            cout << "Введите номер зачётной книжки: ";
            int id;
            cin >> id;
            addStudent(head, name, id);
            break;
        }
        case 2: {
            cout << "Введите номер зачётной книжки: ";
            int id;
            cin >> id;
            deleteStudent(head, id);
            break;
        }
        case 3: {
            cout << "Введите номер зачётной книжки: ";
            int id;
            cin >> id;
            findStudent(head, id);
            break;
        }
        case 4:
            displayStudents(head);
            break;
        case 5:
            saveToFile(head, filename);
            break;
        case 6:
            clearList(head);
            loadFromFile(head, filename);
            break;
        case 0:
            clearList(head);
            cout << "Выход из программы." << endl;
            return 0;
        default:
            cout << "Неверный выбор. Попробуйте снова." << endl;
        }
    }
}
