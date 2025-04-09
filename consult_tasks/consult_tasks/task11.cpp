#include <iostream>
#include <stdexcept>
#include "task11.h"

// Вопрос 1: Исключения, выбрасываемые стандартными библиотеками C++: std::out_of_range, std::invalid_argument, std::runtime_error, std::logic_error и др.
// Примеры: throw std::out_of_range("Индекс вне диапазона"); throw std::invalid_argument("Неверный аргумент");
//
// Вопрос 2: Механизм перехвата исключений в C++ реализуется с помощью блоков try-catch. Блок try содержит код, который может выбросить исключение, а блок catch обрабатывает его.
// Пример: try { /* код */ } catch (const std::exception& e) { std::cerr << e.what() << std::endl; }
//
// Вопрос 3: Собственные типы исключений можно задать, создав классы, наследующие от std::exception или других стандартных классов исключений.
// Пример: class MyException : public std::exception { public: const char* what() const noexcept override { return "Мое исключение"; } };
//
// Вопрос 4: Вложенное пространство имен используется для организации кода в больших проектах, чтобы избежать конфликтов имен.
// Пример: namespace Outer { namespace Inner { int value = 42; } }
//
// Вопрос 5: Преимущества использования пространств имен в крупных приложениях: избежание конфликтов имен, улучшение читаемости кода, модульность.

namespace MyMathLibrary {
    int divide(int a, int b) {
        if (b == 0) {
            throw std::runtime_error("Деление на ноль");
        }
        return a / b;
    }
}

void task11() {
    try {
        int result = MyMathLibrary::divide(10, 2);
        std::cout << "Результат деления: " << result << std::endl;
        result = MyMathLibrary::divide(10, 0);
        std::cout << "Результат деления: " << result << std::endl;
    } catch (const std::runtime_error& e) {
        std::cerr << "Ошибка: " << e.what() << std::endl;
    }
}