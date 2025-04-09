#include <iostream>
#include "task12.h"

// Вопрос 1: Способы приведения типов в C++: static_cast, dynamic_cast, reinterpret_cast, const_cast.
// Примеры: static_cast<int>(3.14), dynamic_cast<Derived*>(basePtr), reinterpret_cast<char*>(intPtr), const_cast<char*>(constCharPtr)
//
// Вопрос 2: Статическое приведение типов выполняется во время компиляции, динамическое - во время выполнения.
// Статическое приведение: преобразование между родительскими и производными классами, арифметические типы.
// Динамическое приведение: преобразование между родительскими и производными классами с полиморфизмом.
//
// Вопрос 3: Явное приведение типов требует явного указания типа, неявное - происходит автоматически.
// Примеры явного: static_cast<int>(3.14), dynamic_cast<Derived*>(basePtr)
// Примеры неявного: int a = 3.14; Base* basePtr = new Derived();
//
// Вопрос 4: Опасности: неправильное приведение может привести к повреждению данных, ошибкам доступа.
// Минимизация рисков: использовать правильные типы приведения, проверять условия перед приведением.
//
// Вопрос 5: dynamic_cast используется для безопасного преобразования между родительскими и производными классами с полиморфизмом.
// Пример: Derived* derivedPtr = dynamic_cast<Derived*>(basePtr);

struct Person {
    std::string name;
    int age;

    Person(std::string n, int a) : name(n), age(a) {}
    virtual ~Person() {}
};

struct Employee : public Person {
    std::string position;

    Employee(std::string n, int a, std::string p) : Person(n, a), position(p) {}
};

void task12() {
    Employee emp("John Doe", 30, "Engineer");

    Person* personPtr = static_cast<Person*>(&emp);
    std::cout << "Имя: " << personPtr->name << ", Возраст: " << personPtr->age << std::endl;

    Employee* empPtr = dynamic_cast<Employee*>(personPtr);
    if (empPtr) {
        std::cout << "Должность: " << empPtr->position << std::endl;
    } else {
        std::cout << "Приведение типа не удалось" << std::endl;
    }

    Person* anotherPersonPtr = reinterpret_cast<Person*>(&emp);
    std::cout << "Имя: " << anotherPersonPtr->name << ", Возраст: " << anotherPersonPtr->age << std::endl;

    // Пример const_cast
    const Person* constPersonPtr = &emp;
    Person* modifiablePersonPtr = const_cast<Person*>(constPersonPtr);
    modifiablePersonPtr->age = 31;
    std::cout << "Новый возраст: " << modifiablePersonPtr->age << std::endl;
}