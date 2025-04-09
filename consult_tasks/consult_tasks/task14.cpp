#include <iostream>
#include <memory>
#include "task14.h"

// Вопрос 1: Умные указатели в C++: std::unique_ptr, std::shared_ptr, std::weak_ptr.
// std::unique_ptr - владеет объектом и удаляет его при уничтожении.
// std::shared_ptr - совместное владение объектом, поддерживает несколько указателей.
// std::weak_ptr - не владеет объектом, но может наблюдать за ним.
//
// Вопрос 2: Преимущества: автоматическое управление памятью, предотвращение утечек памяти.
// Примеры: std::unique_ptr<Resource> ptr(new Resource()); std::shared_ptr<Resource> sharedPtr(new Resource());
//
// Вопрос 3: std::unique_ptr владеет объектом исключительно. Используется, когда объект должен быть владеем только одним указателем.
// Пример: std::unique_ptr<Resource> ptr(new Resource());
//
// Вопрос 4: std::shared_ptr поддерживает несколько указателей на один объект, используя счетчик ссылок.
// Управление ссылками: при создании нового std::shared_ptr счетчик увеличивается, при уничтожении - уменьшается.
// Пример: std::shared_ptr<Resource> sharedPtr1(new Resource()); std::shared_ptr<Resource> sharedPtr2 = sharedPtr1;
//
// Вопрос 5: Проблемы: циклические ссылки с std::shared_ptr, неправильное использование std::unique_ptr.
// Избежание: использовать std::weak_ptr для разрыва циклических ссылок, правильно передавать std::unique_ptr.

class Resource {
public:
    Resource() { std::cout << "Resource создан" << std::endl; }
    ~Resource() { std::cout << "Resource уничтожен" << std::endl; }
    void doSomething() { std::cout << "Doing something with Resource" << std::endl; }
};

void task14() {
    std::unique_ptr<Resource> uniquePtr(new Resource());
    uniquePtr->doSomething();

    std::shared_ptr<Resource> sharedPtr1(new Resource());
    std::shared_ptr<Resource> sharedPtr2 = sharedPtr1;
    sharedPtr1->doSomething();
    sharedPtr2->doSomething();

    std::cout << "Количество ссылок: " << sharedPtr1.use_count() << std::endl;
}