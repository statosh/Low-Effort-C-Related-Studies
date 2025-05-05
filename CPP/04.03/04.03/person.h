#pragma once
#include <string>
#include <iostream>

using namespace std;

enum class Gender {
    Male,
    Female
};

class Person {
protected:
    string fullName;
    int age;
    Gender gender;

public:
    Person(const string& fullName, int age, Gender gender);
    virtual void printInfo() const;
};