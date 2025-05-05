#include "Library.h"
#include <iostream>

namespace Library {
    void Library::addBook(const Book& book) {
        if (Utils::isValidISBN(book.getISBN())) {
            books.push_back(book);
            std::cout << "����� ���������!\n";
        } else {
            std::cout << "�������� ������ ISBN. ����� �� ���������.\n";
        }
    }

    void Library::removeBook(const std::string& isbn) {
        for (auto it = books.begin(); it != books.end(); ++it) {
            if (it->getISBN() == isbn) {
                books.erase(it);
                std::cout << "����� �������!\n";
                return;
            }
        }
        std::cout << "����� � ISBN " << isbn << " �� �������.\n";
    }

    void Library::displayBooks() const {
        if (books.empty()) {
            std::cout << "��� ��������� ����.\n";
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

                std::cout << "������� ����� �������� �����: ";
                std::getline(std::cin, newTitle);
                std::cout << "������� ������ ������: ";
                std::getline(std::cin, newAuthor);
                std::cout << "������� ����� ��� �������: ";
                std::cin >> newYear;
                std::cin.ignore();
                std::cout << "������� ����� ISBN: ";
                std::getline(std::cin, newISBN);

                if (Utils::isValidISBN(newISBN)) {
                    book.setTitle(newTitle);
                    book.setAuthor(newAuthor);
                    book.setYear(newYear);
                    book.setISBN(newISBN);
                    std::cout << "��������� ���������!\n";
                } else {
                    std::cout << "�������� ������ ISBN. ��������� �� ���������.\n";
                }
                return;
            }
        }
        std::cout << "����� � ISBN " << isbn << " �� �������.\n";
    }
}