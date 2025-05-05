#include <iostream>

namespace SpaceA {
    int variableA = 10;
    void functionA() {
        std::cout << "Функция A вызвана. Переменная A: " << variableA << std::endl;
    }
}

namespace SpaceB {
    double variableB = 3.14;
    void functionB() {
        std::cout << "Функция B вызвана. Переменная B: " << variableB << std::endl;
    }
}

int main() {
    setLocale(LC_ALL, "Russian");
    std::cout << "Доступ к элементам из пространства имен SpaceA:" << std::endl;
    SpaceA::functionA();
    std::cout << "Переменная A напрямую: " << SpaceA::variableA << std::endl;

    std::cout << "\nДоступ к элементам из пространства имен SpaceB:" << std::endl;
    SpaceB::functionB();
    std::cout << "Переменная B напрямую: " << SpaceB::variableB << std::endl;

    return 0;
}