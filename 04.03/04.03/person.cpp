#include "person.h"

Person::Person(const string& fullName, int age, Gender gender)
    : fullName(fullName), age(age), gender(gender) {}

void Person::printInfo() const {
    cout << "���: " << fullName << endl;
    cout << "�������: " << age << endl;
    cout << "���: " << (gender == Gender::Male ? "�������" : "�������") << endl;
}