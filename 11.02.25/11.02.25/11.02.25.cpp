#include <iostream>
#include <string>
using namespace std;

class House {
private:
    string address;
    int floor;
    int rooms;
    double area;

public:
    House(string addr, int fl, int rm, double ar) : address(addr), floor(fl), rooms(rm), area(ar) {}

    ~House() {}

    void setAddress(string addr) { address = addr; }
    void setFloor(int fl) { floor = fl; }
    void setRooms(int rm) { rooms = rm; }
    void setArea(double ar) { area = ar; }

    string getAddress() const { return address; }
    int getFloor() const { return floor; }
    int getRooms() const { return rooms; }
    double getArea() const { return area; }

    void print() const {
        cout << "Адрес: " << address << ", Этаж: " << floor << ", Комнат: " << rooms << ", Площадь: " << area << " кв.м" << endl;
    }
};

void listByRooms(House* houses, int size, int roomCount) {
    cout << "Квартиры с " << roomCount << " комнатами:\n";
    for (int i = 0; i < size; ++i) {
        if (houses[i].getRooms() == roomCount) {
            houses[i].print();
        }
    }
}

void listByArea(House* houses, int size, double minArea) {
    cout << "Квартиры с площадью больше " << minArea << " кв.м:\n";
    for (int i = 0; i < size; ++i) {
        if (houses[i].getArea() > minArea) {
            houses[i].print();
        }
    }
}

int main() {
    setlocale(LC_ALL, "Russian");

    const int size = 5;
    House houses[size] = {
        House("ул. Ленина, д.1", 2, 3, 60.5),
        House("ул. Советская, д.10", 5, 2, 45.3),
        House("ул. Победы, д.7", 3, 4, 75.0),
        House("ул. Гагарина, д.15", 7, 3, 65.8),
        House("ул. Кирова, д.5", 1, 1, 30.2)
    };

    while (true) {
        cout << R"(
Меню:
1. Вывести список всех квартир
2. Найти квартиры по количеству комнат
3. Найти квартиры по минимальной площади
0. Выход
Выберите действие: )";

        int choice;
        cin >> choice;

        switch (choice) {
        case 1:
            for (int i = 0; i < size; ++i) {
                houses[i].print();
            }
            break;
        case 2: {
            int rooms;
            cout << "Введите количество комнат: ";
            cin >> rooms;
            listByRooms(houses, size, rooms);
            break;
        }
        case 3: {
            double minArea;
            cout << "Введите минимальную площадь: ";
            cin >> minArea;
            listByArea(houses, size, minArea);
            break;
        }
        case 0:
            cout << "Выход из программы." << endl;
            return 0;
        default:
            cout << "Неверный выбор. Попробуйте снова." << endl;
        }
    }
}
