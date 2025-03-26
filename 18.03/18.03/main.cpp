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
1. ������������ ������ (����� -10)
2. ������������ ����� (����� -20)
3. ������������ ���������� (�������� +30)
4. ������������ �������� (�������� +15)
5. ������������ ��������� (������� +25)
6. ���������� �������� (����� +5, ������� -2)
0. �����
==========================================
)" << endl;

        cout << "������� ��������� ���������:" << endl;
        hero.printStatus();

        hero.update();

        int choice;
        cout << "�������� ��������: ";
        cin >> choice;

        switch (choice) {
        case 1:
            hero.useItem(items[0]);
            cout << "������������ ������!" << endl;
            break;
        case 2:
            hero.useItem(items[1]);
            cout << "����������� �����!" << endl;
            break;
        case 3:
            hero.useItem(items[2]);
            cout << "����������� ����������!" << endl;
            break;
        case 4:
            hero.useItem(items[3]);
            cout << "������������ ��������!" << endl;
            break;
        case 5:
            hero.useItem(items[4]);
            cout << "����������� ���������!" << endl;
            break;
        case 6:
            cout << "�������� ���������." << endl;
            break;
        case 0:
            cout << "�����..." << endl;
            return 0;
        default:
            cout << "�������� �����! ���������� �����." << endl;
            break;
        }

    }

    return 0;
}