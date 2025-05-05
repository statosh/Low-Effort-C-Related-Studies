#include "Utils.h"
#include <regex>

namespace Utils {
    bool isValidISBN(const std::string& isbn) {
        std::regex isbnPattern(R"(^97[89]-?\d{1,5}-?\d{1,7}-?\d{1,7}-?[\dXx]$)");
        return std::regex_match(isbn, isbnPattern);
    }
}