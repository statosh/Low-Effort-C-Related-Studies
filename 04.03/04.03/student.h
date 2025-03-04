#pragma once
#include "person.h"

using namespace std;

class Student : public Person {
private:
    string groupNumber;

public:
    Student(const string& fullName, int age, Gender gender, const string& groupNumber);
    void printInfo() const override;
};