#include <iostream>
#include "task5.h"

// Вопрос 1: Ключевое слово explicit перед конструктором предотвращает неявные преобразования типов. 
// Решает проблему нежелательного вызова конструктора при передаче аргумента.
// 
// Вопрос 2: Рекомендуется использовать, когда конструктор принимает один аргумент и преобразование может быть непреднамеренным.
// 
// Вопрос 3: Да, может принимать несколько аргументов. 
// Пример: explicit Fraction(int num, int denom) : numerator(num), denominator(denom) {}
// 
// Вопрос 4: Наличие explicit запрещает неявное преобразование типов, требует явного вызова конструктора.
// 
// Вопрос 5: Явная конвертация требует явного указания типа, предпочтительна, когда необходимо точно указать преобразование. 
// Неявная конвертация происходит автоматически, предпочтительна, когда преобразование очевидно и безопасно.

class Fraction {
private:
    int numerator, denominator;

    int gcd(int a, int b) {
        while (b != 0) {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

public:
    explicit Fraction(int num, int denom) : numerator(num), denominator(denom) {
        simplify();
    }

    void simplify() {
        int gcdValue = gcd(numerator, denominator);
        numerator /= gcdValue;
        denominator /= gcdValue;
    }

    friend std::ostream& operator<<(std::ostream& os, const Fraction& f) {
        os << f.numerator << "/" << f.denominator;
        return os;
    }
};

void task5() {
    Fraction f1(3, 5);
    Fraction f2(6, 15);

    f2.simplify();

    std::cout << "f1: " << f1 << std::endl;
    std::cout << "Упростили f2: " << f2 << std::endl;
}