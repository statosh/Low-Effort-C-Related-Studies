#include "Library.h"
#include <iostream>

namespace Library {
    void Library::addBook(const Book& book) {
        if (Utils::isValidISBN(book.getISBN())) {
            books.push_back(book);
            std::cout << "Книга добавлена!\n";
        } else {
            std::cout << "Неверный формат ISBN. Книга не добавлена.\n";
        }
    }

    void Library::removeBook(const std::string& isbn) {
        for (auto it = books.begin(); it != books.end(); ++it) {
            if (it->getISBN() == isbn) {
                books.erase(it);
                std::cout << "Книга удалена!\n";
                return;
            }
        }
        std::cout << "Книга с ISBN " << isbn << " не найдена.\n";
    }

    void Library::displayBooks() const {
        if (books.empty()) {
            std::cout << "Нет доступных книг.\n";
            return;
        }
        for (size_t i = 0; i < books.size(); ++i) {
            std::cout << i + 1 << ". " << books[i].getTitle() << " (" << books[i].getAuthor() << ", "
                << books[i].getYear() << ", ISBN: " << books[i].getISBN() << ")\n";
        }
    }

    void Library::editBook(const std::string& isbn) {
        for (auto& book : books) {
            if (book.getISBN() == isbn) {
                std::string newTitle, newAuthor;
                int newYear;
                std::string newISBN;

                std::cout << "Введите новое название книги: ";
                std::getline(std::cin, newTitle);
                std::cout << "Введите нового автора: ";
                std::getline(std::cin, newAuthor);
                std::cout << "Введите новый год издания: ";
                std::cin >> newYear;
                std::cin.ignore();
                std::cout << "Введите новый ISBN: ";
                std::getline(std::cin, newISBN);

                if (Utils::isValidISBN(newISBN)) {
                    book.setTitle(newTitle);
                    book.setAuthor(newAuthor);
                    book.setYear(newYear);
                    book.setISBN(newISBN);
                    std::cout << "Изменения сохранены!\n";
                } else {
                    std::cout << "Неверный формат ISBN. Изменения не сохранены.\n";
                }
                return;
            }
        }
        std::cout << "Книга с ISBN " << isbn << " не найдена.\n";
    }
}