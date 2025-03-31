#include <iostream>
#include <fstream>
#include <string>
#include <exception>
#include <locale>

class MyException : public std::exception {
public:
    const char* what() const noexcept override {
        return "Ошибка: Файл не найден!";
    }
};

double divide(double a, double b) {
    if (b == 0) throw std::runtime_error("Ошибка: Деление на ноль!");
    return a / b;
}

void openFile(const std::string& filename) {
    std::ifstream file(filename);
    if (!file) throw MyException();
    std::cout << "Файл успешно открыт!\n";
}

double safeDivide(int a, int b) {
    if (b == 0) throw std::runtime_error("Ошибка: Деление на ноль!");
    return static_cast<double>(a) / b;
}

void accessArray(int index) {
    int arr[] = { 1, 2, 3, 4, 5 };
    if (index < 0 || index >= 5) throw std::out_of_range("Ошибка: Индекс за границами массива!");
    std::cout << "Элемент по индексу " << index << ": " << arr[index] << std::endl;
}

void readFile(const std::string& filename) {
    std::ifstream file(filename);
    if (!file) throw std::runtime_error("Ошибка: Не удалось открыть файл!");

    try {
        std::string line;
        while (std::getline(file, line)) {
            std::cout << line << std::endl;
        }
    } catch (...) {
        std::cerr << "Ошибка при чтении файла!" << std::endl;
    }
}

int main() {
    setlocale(LC_ALL, "Russian");
    std::cout << "Программа обработки исключений\n";

    double num1, num2;
    std::cout << "\nВведите два числа для деления: ";
    std::cin >> num1 >> num2;

    try {
        std::cout << "Результат: " << divide(num1, num2) << std::endl;
    } catch (const std::runtime_error& e) {
        std::cerr << e.what() << std::endl;
    }

    std::string filename;
    std::cout << "\nВведите имя файла для открытия: ";
    std::cin >> filename;

    try {
        openFile(filename);
    } catch (const MyException& e) {
        std::cerr << e.what() << std::endl;
    }

    try {
        std::cout << "\nДеление 10 на 0: " << safeDivide(10, 0) << std::endl;
    } catch (const std::runtime_error& e) {
        std::cerr << e.what() << std::endl;
    }

    try {
        std::cout << "\nВведите индекс для массива (0-4): ";
        int index;
        std::cin >> index;
        accessArray(index);
    } catch (const std::out_of_range& e) {
        std::cerr << e.what() << std::endl;
    }

    std::cout << "\nВведите имя файла для чтения: ";
    std::cin >> filename;

    try {
        readFile(filename);
    } catch (const std::exception& e) {
        std::cerr << e.what() << std::endl;
    }

    return 0;
}
