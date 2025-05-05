#include <iostream>
#include <locale>
#include <limits>
#include "animal.h"
#include "zoo_shop.h"

int main() {
    setlocale(LC_ALL, "Russian");

    ZooShop zooShop;
    zooShop.loadFromFile("zoo_data.txt");

    int choice;
    do {
        std::cout << "\nМеню зоомагазина:\n";
        std::cout << "-----------------------------------\n";
        std::cout << "1. Добавить животное\n";
        std::cout << "-----------------------------------\n";
        std::cout << "2. Удалить животное по виду\n";
        std::cout << "3. Удалить животное по имени\n";
        std::cout << "-----------------------------------\n";
        std::cout << "4. Поиск животного по виду\n";
        std::cout << "5. Поиск животного по имени\n";
        std::cout << "6. Поиск животного по возрасту\n";
        std::cout << "7. Поиск животного по цене\n";
        std::cout << "-----------------------------------\n";
        std::cout << "8. Изменить цену животного\n";
        std::cout << "9. Просмотр всех животных\n";
        std::cout << "-----------------------------------\n";
        std::cout << "10. Сортировка животных по виду\n";
        std::cout << "11. Сортировка животных по возрасту\n";
        std::cout << "12. Сортировка животных по цене\n";
        std::cout << "13. Сохранить данные в файл\n";
        std::cout << "-----------------------------------\n";
        std::cout << "0. Выход\n";
        std::cout << "-----------------------------------\n";
        std::cout << "Введите номер операции: ";

        while (!(std::cin >> choice)) {
            std::cerr << "Неверный ввод. Пожалуйста, введите число: ";
            std::cin.clear();
            std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
        }

        switch (choice) {
        case 1: {
            std::string species, name, gender;
            int age;
            double price;
            std::cout << "Введите вид: ";
            std::cin.ignore();
            std::getline(std::cin, species);
            std::cout << "Введите имя: ";
            std::getline(std::cin, name);

            std::cout << "Введите возраст: ";
            while (!(std::cin >> age) || age < 0) {
                std::cerr << "Неверный ввод. Пожалуйста, введите положительное число для возраста: ";
                std::cin.clear();
                std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
            }

            std::cout << "Введите цену: ";
            while (!(std::cin >> price) || price < 0) {
                std::cerr << "Неверный ввод. Пожалуйста, введите положительное число для цены: ";
                std::cin.clear();
                std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
            }

            std::cout << "Введите пол: ";
            std::cin >> gender;
            zooShop.addAnimal(species, name, age, price, gender);
            break;
        }
        case 2: {
            std::string species;
            std::cout << "Введите вид: ";
            std::cin.ignore();
            std::getline(std::cin, species);
            zooShop.removeAnimalBySpecies(species);
            break;
        }
        case 3: {
            std::string name;
            std::cout << "Введите имя: ";
            std::cin.ignore();
            std::getline(std::cin, name);
            zooShop.removeAnimalByName(name);
            break;
        }
        case 4: {
            std::string species;
            std::cout << "Введите вид: ";
            std::cin.ignore();
            std::getline(std::cin, species);
            zooShop.findAnimalsBySpecies(species);
            break;
        }
        case 5: {
            std::string name;
            std::cout << "Введите имя: ";
            std::cin.ignore();
            std::getline(std::cin, name);
            zooShop.findAnimalsByName(name);
            break;
        }
        case 6: {
            int age;
            std::cout << "Введите возраст: ";
            while (!(std::cin >> age) || age < 0) {
                std::cerr << "Неверный ввод. Пожалуйста, введите положительное число для возраста: ";
                std::cin.clear();
                std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
            }
            zooShop.findAnimalsByAge(age);
            break;
        }
        case 7: {
            double price;
            std::cout << "Введите цену: ";
            while (!(std::cin >> price) || price < 0) {
                std::cerr << "Неверный ввод. Пожалуйста, введите положительное число для цены: ";
                std::cin.clear();
                std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
            }
            zooShop.findAnimalsByPrice(price);
            break;
        }
        case 8: {
            std::string name;
            double newPrice;
            std::cout << "Введите имя животного: ";
            std::cin.ignore();
            std::getline(std::cin, name);

            std::cout << "Введите новую цену: ";
            while (!(std::cin >> newPrice) || newPrice < 0) {
                std::cerr << "Неверный ввод. Пожалуйста, введите положительное число для цены: ";
                std::cin.clear();
                std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
            }

            zooShop.changeAnimalPrice(name, newPrice);
            break;
        }
        case 9:
            zooShop.displayAllAnimals();
            break;
        case 10:
            zooShop.sortAnimalsBySpecies();
            zooShop.displayAllAnimals();
            break;
        case 11:
            zooShop.sortAnimalsByAge();
            zooShop.displayAllAnimals();
            break;
        case 12:
            zooShop.sortAnimalsByPrice();
            zooShop.displayAllAnimals();
            break;
        case 13:
            zooShop.saveToFile("zoo_data.txt");
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