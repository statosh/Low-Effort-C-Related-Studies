#include <iostream>
#include "task6.h"

// Вопрос 1: Перегрузка операторов в C++ позволяет определить пользовательское поведение стандартных операторов для своих классов.
// 
// Вопрос 2: Можно перегружать большинство операторов, кроме некоторых системных. 
// Примеры: +, -, *, /, [], <<, >>.
// 
// Вопрос 3: Глобальная функция может быть другом класса и получать доступ к его приватным членам, в то время как член класса имеет доступ только к своим объектам.
// 
// Вопрос 4: Перегрузка operator[] обычно возвращает ссылку на элемент контейнера, что позволяет как читать, так и записывать значения. 
// Пример: T& operator[](size_t index) { return data[index]; }
// 
// Вопрос 5: Перегрузка operator<< позволяет определить, как объект будет выводиться в поток. 
// Пример: friend std::ostream& operator<<(std::ostream& os, const MyClass& obj) { os << obj.value; return os; }

class ComplexNumber {
private:
    double real, imag;

public:
    ComplexNumber(double r, double i) : real(r), imag(i) {}

    ComplexNumber operator+(const ComplexNumber& other) const {
        return ComplexNumber(real + other.real, imag + other.imag);
    }

    ComplexNumber operator-(const ComplexNumber& other) const {
        return ComplexNumber(real - other.real, imag - other.imag);
    }

    ComplexNumber operator*(const ComplexNumber& other) const {
        return ComplexNumber(real * other.real - imag * other.imag, real * other.imag + imag * other.real);
    }

    friend std::ostream& operator<<(std::ostream& os, const ComplexNumber& c) {
        os << "(" << c.real << " + " << c.imag << "i)";
        return os;
    }
};

void task6() {
    ComplexNumber c1(1, 2);
    ComplexNumber c2(3, 4);

    ComplexNumber sum = c1 + c2;
    ComplexNumber diff = c1 - c2;
    ComplexNumber prod = c1 * c2;

    std::cout << "Сумма: " << sum << std::endl;
    std::cout << "Разность: " << diff << std::endl;
    std::cout << "Произведение: " << prod << std::endl;
}