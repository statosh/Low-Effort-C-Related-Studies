#include <iostream>
using namespace std;

class Base {
public:
    virtual void show() { cout << "Base class\n"; }
    virtual ~Base() = default;
};

class Derived : public Base {
public:
    void show() override { cout << "Derived class\n"; }
};

// 1. static_cast: Приведение int к double
void demo_static_cast() {
    int intValue = 42;
    double doubleValue = static_cast<double>(intValue);
    cout << "static_cast: " << intValue << " -> " << doubleValue << endl;
}

// 2. dynamic_cast: Динамическое приведение в иерархии классов
void demo_dynamic_cast() {
    Base* basePtr = new Derived();
    Derived* derivedPtr = dynamic_cast<Derived*>(basePtr);

    if (derivedPtr)
        derivedPtr->show();
    else
        cout << "dynamic_cast не удался\n";

    delete basePtr;
}

// 3. const_cast: Удаление константности
void demo_const_cast() {
    const int num = 10;
    const int* constPtr = &num;

    int* modifiablePtr = const_cast<int*>(constPtr);
    *modifiablePtr = 20;  // UB, но демонстрирует const_cast

    cout << "const_cast: " << num << " (потенциально UB, но показан принцип)\n";
}

// 4. reinterpret_cast: Низкоуровневое приведение указателей
void demo_reinterpret_cast() {
    int num = 12345;
    int* intPtr = &num;
    char* charPtr = reinterpret_cast<char*>(intPtr);

    cout << "reinterpret_cast: " << *intPtr << " -> " << *charPtr << " (первый байт)\n";
}

int main() {
    setlocale(LC_ALL, "Russian");
    demo_static_cast();
    demo_dynamic_cast();
    demo_const_cast();
    demo_reinterpret_cast();
    return 0;
}
