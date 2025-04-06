#include <iostream>
#include <thread>
#include <mutex>
#include <condition_variable>
#include <stdexcept>
#include <cstdlib>
#include <ctime>

std::mutex mtx;
std::condition_variable cv_assembly, cv_painting, cv_packaging;

bool assembly_done = false;
bool painting_done = false;
bool error_occurred = false;

void assembly() {
    try {
        std::unique_lock<std::mutex> lock(mtx);
        std::cout << "Начало сборки...\n";
        std::this_thread::sleep_for(std::chrono::seconds(2));
        if (rand() % 5 == 0) {
            throw std::runtime_error("Ошибка на этапе сборки!");
        }
        std::cout << "Сборка завершена.\n";
        assembly_done = true;
    } catch (const std::exception& e) {
        std::cerr << e.what() << "\n";
        error_occurred = true;
    }
    cv_assembly.notify_one();
}

void painting() {
    std::unique_lock<std::mutex> lock(mtx);
    cv_assembly.wait(lock, [] { return assembly_done || error_occurred; });

    if (error_occurred) return;

    try {
        std::cout << "Начало покраски...\n";
        std::this_thread::sleep_for(std::chrono::seconds(2));
        if (rand() % 5 == 0) {
            throw std::runtime_error("Ошибка на этапе покраски!");
        }
        std::cout << "Покраска выполнена.\n";
        painting_done = true;
    } catch (const std::exception& e) {
        std::cerr << e.what() << "\n";
        error_occurred = true;
    }
    cv_painting.notify_one();
}

void packaging() {
    std::unique_lock<std::mutex> lock(mtx);
    cv_painting.wait(lock, [] { return painting_done || error_occurred; });

    if (error_occurred) return;

    try {
        std::cout << "Начало упаковки...\n";
        std::this_thread::sleep_for(std::chrono::seconds(2));
        if (rand() % 5 == 0) {
            throw std::runtime_error("Ошибка на этапе упаковки!");
        }
        std::cout << "Упаковка завершена.\n";
    } catch (const std::exception& e) {
        std::cerr << e.what() << "\n";
        error_occurred = true;
    }
}

int main() {
    setlocale(LC_ALL, "Russian");
    srand(static_cast<unsigned>(time(nullptr)));

    std::thread t1(assembly);
    std::thread t2(painting);
    std::thread t3(packaging);

    t1.join();
    t2.join();
    t3.join();

    if (!error_occurred) {
        std::cout << "Процесс завершен!\n";
    } else {
        std::cout << "Процесс остановлен из-за ошибки.\n";
    }

    return 0;
}