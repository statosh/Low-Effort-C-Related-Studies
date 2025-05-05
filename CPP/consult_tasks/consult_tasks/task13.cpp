#include <iostream>
#include <thread>
#include <mutex>
#include "task13.h"

// Вопрос 1: Многопоточность в C++ позволяет выполнять несколько потоков одновременно. Основные библиотеки: <thread>, <mutex>, <condition_variable>.
//
// Вопрос 2: Способы создания потоков: std::thread, std::async.
// Примеры: std::thread t(task); std::future<int> result = std::async(std::launch::async, task);
//
// Вопрос 3: Синхронизация потоков - координация работы потоков, защита критических секций - предотвращение одновременного доступа к общим ресурсам.
// Инструменты: std::mutex, std::lock_guard, std::unique_lock.
//
// Вопрос 4: Проблемы: гонки данных, мертвыеlocks, утечки ресурсов.
// Примеры: гонка данных - одновременное изменение одной переменной несколькими потоками.
//
// Вопрос 5: Мьютекс - объект, который предотвращает одновременный доступ к ресурсу. Семафор - счетчик, который контролирует доступ к ресурсу.
// Мьютекс: std::mutex, Семафор: std::counting_semaphore (C++20).

std::mutex mtx;
int sharedResource = 0;

void worker(int id) {
    std::lock_guard<std::mutex> lock(mtx);
    for (int i = 0; i < 1000; ++i) {
        sharedResource++;
    }
    std::cout << "Worker " << id << " завершил работу. Ресурс: " << sharedResource << std::endl;
}

void task13() {
    std::thread t1(worker, 1);
    std::thread t2(worker, 2);

    t1.join();
    t2.join();

    std::cout << "Финальное значение ресурса: " << sharedResource << std::endl;
}