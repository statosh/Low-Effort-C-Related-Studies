#include <iostream>
#include <string>
#include "Library.h"
#include "Utils.h"
#include <windows.h>

int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    Library::Library library;
    std::string command;

    while (true) {
        std::cout << "> ";
        std::getline(std::cin, command);


        if (command == "exit") {
            std::cout << "Программа завершена.\n";
            break;
        }

        if (command == "add") {
            std::string title, author, isbn;
            int year;

            std::cout << "Введите название книги: ";
            std::getline(std::cin, title);
            std::cout << "Введите автора: ";
            std::getline(std::cin, author);
            std::cout << "Введите год издания: ";
            std::cin >> year;
            std::cin.ignore();
            std::cout << "Введите ISBN: ";
            std::getline(std::cin, isbn);

            Library::Book book(title, author, year, isbn);
            library.addBook(book);
        } else if (command == "remove") {
            std::string isbn;
            std::cout << "Введите ISBN книги для удаления: ";
            std::getline(std::cin, isbn);
            library.removeBook(isbn);
        } else if (command == "display") {
            library.displayBooks();
        } else if (command == "edit") {
            std::string isbn;
            std::cout << "Введите ISBN книги для редактирования: ";
            std::getline(std::cin, isbn);
            library.editBook(isbn);
        } else {
            std::cout << "Неверная команда. Попробуйте снова.\n";
        }
    }

    return 0;
}