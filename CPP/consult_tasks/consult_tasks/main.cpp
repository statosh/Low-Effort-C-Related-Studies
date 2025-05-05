#include <iostream>
#include <locale>
#include "task1.h"
#include "task2.h"
#include "task3.h"
#include "task4.h"
#include "task5.h"
#include "task6.h"
#include "task7.h"
#include "task8.h"
#include "task9.h"
#include "task10.h"
#include "task11.h"
#include "task12.h"
#include "task13.h"
#include "task14.h"
#include "task15.h"

int main() {
    setlocale(LC_ALL, "Russian");

    int choice;
    do {
        std::cout << "\nВыберите задание:\n";
        std::cout << "1. Задание 1\n";
        std::cout << "2. Задание 2\n";
        std::cout << "3. Задание 3\n";
        std::cout << "4. Задание 4\n";
        std::cout << "5. Задание 5\n";
        std::cout << "6. Задание 6\n";
        std::cout << "7. Задание 7\n";
        std::cout << "8. Задание 8\n";
        std::cout << "9. Задание 9\n";
        std::cout << "10. Задание 10\n";
        std::cout << "11. Задание 11\n";
        std::cout << "12. Задание 12\n";
        std::cout << "13. Задание 13\n";
        std::cout << "14. Задание 14\n";
        std::cout << "15. Задание 15\n";
        std::cout << "0. Выход\n";
        std::cout << "Введите номер задания: ";
        std::cin >> choice;

        switch (choice) {
        case 1:
            task1();
            break;
        case 2:
            task2();
            break;
        case 3:
            task3();
            break;
        case 4:
            task4();
            break;
        case 5:
            task5();
            break;
        case 6:
            task6();
            break;
        case 7:
            task7();
            break;
        case 8:
            task8();
            break;
        case 9:
            task9();
            break;
        case 10:
            task10();
            break;
        case 11:
            task11();
            break;
        case 12:
            task12();
            break;
        case 13:
            task13();
            break;
        case 14:
            task14();
            break;
        case 15:
            task15();
            break;
        case 0:
            std::cout << "Выход из программы.\n";
            break;
        default:
            std::cout << "Неверный выбор. Попробуйте снова.\n";
        }
    } while (choice != 0);

    return 0;
}