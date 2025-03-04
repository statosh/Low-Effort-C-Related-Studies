#include "person.h"

Person::Person(const string& fullName, int age, Gender gender)
    : fullName(fullName), age(age), gender(gender) {}

void Person::printInfo() const {
    cout << "ФИО: " << fullName << endl;
    cout << "Возраст: " << age << endl;
    cout << "Пол: " << (gender == Gender::Male ? "Мужской" : "Женский") << endl;
}