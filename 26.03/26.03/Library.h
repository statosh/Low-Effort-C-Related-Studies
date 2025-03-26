#ifndef LIBRARY_H
#define LIBRARY_H

#include <vector>
#include <string>
#include "Book.h"
#include "Utils.h"

namespace Library {
    class Library {
    private:
        std::vector<Book> books;

    public:
        void addBook(const Book& book);
        void removeBook(const std::string& isbn);
        void displayBooks() const;
        void editBook(const std::string& isbn);
    };
}

#endif // LIBRARY_H