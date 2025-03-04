// Что такое структура?
// - Структура — это тип данных в C++, который объединяет в себе множество переменных разного или 
// - одинакового типа, собранных под одним именем. Это позволяет логически объединять данные, 
// - относящиеся к одному объекту, в единую сущность.
//
// Могут ли структуры быть вложенными?
// - Да.
// 
// Какое слово является ключевым для объявления структур?
// - struct.
// 
// Как обращаться к полям структуры?
// - К полям структуры можно обращаться через оператор точки для обычных переменных структуры или оператор стрелки для указателей на структуру.

#include <iostream>
#include <string>
using namespace std;

struct Employee {
    int id;
    string name;
    double salary;
    string position;
    char gender;
};

void FillEmployees(Employee employees[], int size) {
    for (int i = 0; i < size; ++i) {
        cout << "Введите данные для работника #" << i + 1 << ":\n";
        cout << "Табельный номер: ";
        while (!(cin >> employees[i].id)) {
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(), '\n');
            cout << "Некорректный ввод. Введите числовое значение: ";
        }
        cin.ignore();

        cout << "ФИО: ";
        getline(cin, employees[i].name);

        cout << "Оклад: ";
        while (!(cin >> employees[i].salary)) {
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(), '\n');
            cout << "Некорректный ввод. Введите числовое значение: ";
        }
        cin.ignore();

        cout << "Должность: ";
        getline(cin, employees[i].position);

        cout << "Пол (M/F): ";
        cin >> employees[i].gender;
        cin.ignore();
    }
}

double CalculateTotalSalary(const Employee employees[], int size) {
    double totalSalary = 0;
    for (int i = 0; i < size; ++i) {
        totalSalary += employees[i].salary;
    }
    return totalSalary;
}

void CountByGender(const Employee employees[], int size, int& maleCount, int& femaleCount) {
    maleCount = 0;
    femaleCount = 0;
    for (int i = 0; i < size; ++i) {
        if (employees[i].gender == 'M' || employees[i].gender == 'm') {
            maleCount++;
        } else if (employees[i].gender == 'F' || employees[i].gender == 'f') {
            femaleCount++;
        }
    }
}

void CalculateSalaryByGender(const Employee employees[], int size, double& maleSalary, double& femaleSalary) {
    maleSalary = 0;
    femaleSalary = 0;
    for (int i = 0; i < size; ++i) {
        if (employees[i].gender == 'M' || employees[i].gender == 'm') {
            maleSalary += employees[i].salary;
        } else if (employees[i].gender == 'F' || employees[i].gender == 'f') {
            femaleSalary += employees[i].salary;
        }
    }
}

int main() {
    setlocale(LC_ALL, "Russian");

    int size;
    cout << "Введите количество работников: ";
    while (!(cin >> size) || size <= 0) {
        cin.clear();
        cin.ignore(numeric_limits<streamsize>::max(), '\n');
        cout << "Некорректный ввод. Введите положительное числовое значение: ";
    }
    cin.ignore();

    Employee* employees = new Employee[size];
    FillEmployees(employees, size);

    while (true) {
        cout << R"(
Выберите действие:
1) Посчитать фонд зарплаты фирмы
2) Посчитать количество женщин и мужчин
3) Посчитать фонд зарплаты отдельно для мужчин и женщин
Введите "quit" для выхода.
)";
        string input;
        cin >> input;

        if (input == "quit") break;

        if (input.length() != 1 || input[0] < '1' || input[0] > '3') {
            cout << "Некорректный выбор. Попробуйте снова.\n";
            continue;
        }

        int choice = input[0] - '0';

        switch (choice) {
        case 1: {
            double totalSalary = CalculateTotalSalary(employees, size);
            cout << "Фонд зарплаты фирмы: " << totalSalary << endl;
            break;
        }
        case 2: {
            int maleCount, femaleCount;
            CountByGender(employees, size, maleCount, femaleCount);
            cout << "Мужчин: " << maleCount << ", Женщин: " << femaleCount << endl;
            break;
        }
        case 3: {
            double maleSalary, femaleSalary;
            CalculateSalaryByGender(employees, size, maleSalary, femaleSalary);
            cout << "Фонд зарплаты для мужчин: " << maleSalary << ", для женщин: " << femaleSalary << endl;
            break;
        }
        }
    }

    delete[] employees;
    return 0;
}
