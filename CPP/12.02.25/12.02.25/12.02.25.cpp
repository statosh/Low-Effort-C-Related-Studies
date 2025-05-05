//  Конструктор — метод класса, вызываемый при создании объекта для его инициализации.
// 
//  Деструктор — метод, вызываемый при уничтожении объекта для освобождения ресурсов.Параметры передавать нельзя.
// 
//  Статические переменные - члены — общие для всех объектов класса переменные, хранящие одно значение на весь класс.
// 
//  Указатель this — указывает на текущий объект класса, используется для доступа к его членам или возврата самого объекта.
// 
//  Конструктор копирования — специальный конструктор для создания нового объекта как копии существующего.Вызывается при передаче объекта по значению или явном создании копии.

#include <iostream>
#include <cstring>

using namespace std;

class Student {
private:
    char* name;
    int age;
    double gpa;

    static int studentCount;

public:
    Student() : name(nullptr), age(0), gpa(0.0) {
        studentCount++;
    }

    Student(const char* name, int age, double gpa) {
        this->name = new char[strlen(name) + 1];
        strcpy_s(this->name, strlen(name) + 1, name);
        this->age = age;
        this->gpa = gpa;
        studentCount++;
    }

    Student(const Student& other) {
        this->name = new char[strlen(other.name) + 1];
        strcpy_s(this->name, strlen(other.name) + 1, other.name);
        this->age = other.age;
        this->gpa = other.gpa;
        studentCount++;
    }

    ~Student() {
        delete[] name;
        studentCount--;
    }

    void setName(const char* name) {
        if (this->name != nullptr) {
            delete[] this->name;
        }
        this->name = new char[strlen(name) + 1];
        strcpy_s(this->name, strlen(name) + 1, name);
    }

    const char* getName() const {
        return name;
    }

    void setAge(int age) {
        this->age = age;
    }

    int getAge() const {
        return age;
    }

    void setGPA(double gpa) {
        this->gpa = gpa;
    }

    double getGPA() const {
        return gpa;
    }

    static int getTotalStudents() {
        return studentCount;
    }

    Student& updateInfo(const char* name, int age, double gpa) {
        this->setName(name);
        this->setAge(age);
        this->setGPA(gpa);
        return *this;
    }
};

int Student::studentCount = 0;

void printStudent(Student student) {
    cout << "Имя: " << student.getName() << ", Возраст: " << student.getAge()
        << ", Средний балл: " << student.getGPA() << endl;
}

int main() {
    setlocale(LC_ALL, "Russian");

    Student student1("Иван", 20, 4.5);
    Student student2("Мария", 19, 4.8);

    Student student3 = student1;
    printStudent(student3);

    student1.updateInfo("Петр", 21, 4.7).setAge(22);
    cout << "Обновленные данные студента 1: "
        << "Имя: " << student1.getName() << ", Возраст: " << student1.getAge()
        << ", Средний балл: " << student1.getGPA() << endl;

    cout << "Общее количество студентов: " << Student::getTotalStudents() << endl;

    return 0;
}