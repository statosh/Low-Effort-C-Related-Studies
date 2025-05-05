#include "student.h"

Student::Student(const string& fullName, int age, Gender gender, const string& groupNumber)
    : Person(fullName, age, gender), groupNumber(groupNumber) {}

void Student::printInfo() const {
    Person::printInfo();
    cout << "Номер группы: " << groupNumber << endl;
}