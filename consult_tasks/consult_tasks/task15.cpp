#include <iostream>
#include <vector>
#include <algorithm>
#include "task15.h"

// Вопрос 1: Лямбда-функция в C++ - это анонимная функция, которая может быть определена в месте использования.
// Синтаксис: [захват](параметры) -> возвращаемый_тип { тело }
//
// Вопрос 2: Типы захвата: [=] (по значению), [&] (по ссылке), [this] (текущий объект), [a, &b] (конкретные переменные).
// Примеры: [=]() { std::cout << a << std::endl; }, [&](int x) { b += x; }
//
// Вопрос 3: Захват по ссылке позволяет изменять внешние переменные, захват по значению - только читать.
// Предпочтительно использовать захват по ссылке, если нужно изменять внешние переменные, и по значению - если только читать.
//
// Вопрос 4: Лямбда-функции можно использовать с алгоритмами стандартной библиотеки, такими как std::for_each, std::find_if, std::sort.
// Пример: std::sort(vec.begin(), vec.end(), [](int a, int b) { return a < b; });
//
// Вопрос 5: Ограничения: лямбда-функции не могут быть виртуальными, не могут содержать статические данные-члены.
// Неэффективность: использование большого количества захваченных переменных может увеличить размер лямбда-функции.

void task15() {
    std::vector<int> numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    std::vector<int> evenNumbers;
    std::copy_if(numbers.begin(), numbers.end(), std::back_inserter(evenNumbers), [](int x) { return x % 2 == 0; });

    std::cout << "Четные числа: ";
    for (int num : evenNumbers) {
        std::cout << num << " ";
    }
    std::cout << std::endl;

    std::sort(numbers.begin(), numbers.end(), [](int a, int b) { return a < b; });

    std::cout << "Отсортированные числа: ";
    for (int num : numbers) {
        std::cout << num << " ";
    }
    std::cout << std::endl;

    int sumOfSquares = 0;
    std::for_each(numbers.begin(), numbers.end(), [&sumOfSquares](int x) { sumOfSquares += x * x; });

    std::cout << "Сумма квадратов: " << sumOfSquares << std::endl;
}