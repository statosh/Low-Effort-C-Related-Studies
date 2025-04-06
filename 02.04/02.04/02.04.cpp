#include <iostream>
#include <memory>

class Resource {
public:
    explicit Resource(const std::string& name) : name(name) {
        std::cout << "\nРесурс создан: " << name << std::endl;
    }

    ~Resource() {
        std::cout << "Ресурс уничтожен: " << name << "\n" << std::endl;
    }

    void use() {
        std::cout << "Использование ресурса...\n" << std::endl;
    }

private:
    std::string name;
};

void generateFibonacci(int n) {
    std::cout << "\nПервые " << n << " чисел Фибоначчи:\n";

    int a = 0, b = 1;
    std::cout << a << " " << b << " ";

    auto nextFibonacci = [&]() {
        int temp = a + b;
        a = b;
        b = temp;
        std::cout << b << " ";
        };

    for (int i = 2; i < n; ++i) {
        nextFibonacci();
    }

    std::cout << "\n" << std::endl;
}

void manageResource() {
    std::unique_ptr<Resource> res = std::make_unique<Resource>("MyResource");
    res->use();
}

int main() {
    setlocale(LC_ALL, "Russian");

    while (true) {
        std::cout << "1 - Генерация чисел Фибоначчи\n";
        std::cout << "2 - Работа с ресурсом\n";
        std::cout << "0 - Выход\n";
        std::cout << "Введите номер операции: ";

        int choice;
        std::cin >> choice;

        if (std::cin.fail()) {
            std::cin.clear();
            std::cin.ignore(10000, '\n');
            std::cout << "\nОшибка ввода! Попробуйте снова.\n";
            continue;
        }

        switch (choice) {
        case 1:
            generateFibonacci(15);
            break;
        case 2:
            manageResource();
            break;
        case 0:
            std::cout << "\nЗавершение программы...\n";
            return 0;
        default:
            std::cout << "\nНекорректный ввод. Попробуйте снова.\n";
        }
    }
}
