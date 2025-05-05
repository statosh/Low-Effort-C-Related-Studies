#include <iostream>
#include <cstdlib>
#include "Person.h"
#include "Apple.h"
#include "Steak.h"
#include "Antibiotic.h"
#include "Vitamins.h"
#include "EnergyDrink.h"

using namespace std;

int main() {
    setlocale(LC_ALL, "Russian");

    Person hero(100, 100, 0);

    auto apple = make_shared<Apple>();
    auto steak = make_shared<Steak>();
    auto antibiotic = make_shared<Antibiotic>();
    auto vitamins = make_shared<Vitamins>();
    auto energyDrink = make_shared<EnergyDrink>();

    vector<shared_ptr<Item>> items = { apple, steak, antibiotic, vitamins, energyDrink };

    while (true) {
        system("cls");

        cout << R"(
==========================================
1. Использовать яблоко (Голод -10)
2. Использовать стейк (Голод -20)
3. Использовать антибиотик (Здоровье +30)
4. Использовать витамины (Здоровье +15)
5. Использовать энергетик (Энергия +25)
6. Пропустить действие (Голод +5, Энергия -2)
0. Выход
==========================================
)" << endl;

        cout << "Текущее состояние персонажа:" << endl;
        hero.printStatus();

        hero.update();

        int choice;
        cout << "Выберите действие: ";
        cin >> choice;

        switch (choice) {
        case 1:
            hero.useItem(items[0]);
            cout << "Использовано яблоко!" << endl;
            break;
        case 2:
            hero.useItem(items[1]);
            cout << "Использован стейк!" << endl;
            break;
        case 3:
            hero.useItem(items[2]);
            cout << "Использован антибиотик!" << endl;
            break;
        case 4:
            hero.useItem(items[3]);
            cout << "Использованы витамины!" << endl;
            break;
        case 5:
            hero.useItem(items[4]);
            cout << "Использован энергетик!" << endl;
            break;
        case 6:
            cout << "Действие пропущено." << endl;
            break;
        case 0:
            cout << "Выход..." << endl;
            return 0;
        default:
            cout << "Неверный выбор! Попробуйте снова." << endl;
            break;
        }

    }

    return 0;
}