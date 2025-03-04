#include "person.h"
#include "student.h"
#include <iostream>

using namespace std;

int main() {
    setlocale(LC_ALL, "Russian");
    Person person("Иван Иванов", 25, Gender::Male);
    Student student("Мария Петрова", 20, Gender::Female, "БСБО-01-20");

    cout << "Информация о человеке:" << endl;
    person.printInfo();
    cout << endl;

    cout << "Информация о студенте:" << endl;
    student.printInfo();

    return 0;
}