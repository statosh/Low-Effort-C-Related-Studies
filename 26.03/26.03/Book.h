#ifndef BOOK_H
#define BOOK_H

#include <string>

namespace Library {
    class Book {
    private:
        std::string title;
        std::string author;
        int year;
        std::string isbn;

    public:
        Book(const std::string& title, const std::string& author, int year, const std::string& isbn)
            : title(title), author(author), year(year), isbn(isbn) {
        }

        std::string getTitle() const { return title; }
        std::string getAuthor() const { return author; }
        int getYear() const { return year; }
        std::string getISBN() const { return isbn; }

        void setTitle(const std::string& title) { this->title = title; }
        void setAuthor(const std::string& author) { this->author = author; }
        void setYear(int year) { this->year = year; }
        void setISBN(const std::string& isbn) { this->isbn = isbn; }
    };
}

#endif // BOOK_H