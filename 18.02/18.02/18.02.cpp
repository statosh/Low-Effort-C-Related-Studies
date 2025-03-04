#include <iostream>
#include <stdexcept>

using namespace std;

class ComplexNumber {
private:
    double real;
    double imag;

public:
    ComplexNumber() : real(0), imag(0) {}
    ComplexNumber(double real, double imag) : real(real), imag(imag) {}

    double getReal() const { return real; }
    double getImag() const { return imag; }

    void setReal(double newReal) { real = newReal; }
    void setImag(double newImag) { imag = newImag; }

    ComplexNumber operator+(const ComplexNumber& other) const {
        return ComplexNumber(real + other.real, imag + other.imag);
    }

    ComplexNumber operator-(const ComplexNumber& other) const {
        return ComplexNumber(real - other.real, imag - other.imag);
    }

    ComplexNumber operator*(const ComplexNumber& other) const {
        double newReal = real * other.real - imag * other.imag;
        double newImag = real * other.imag + imag * other.real;
        return ComplexNumber(newReal, newImag);
    }

    ComplexNumber operator/(const ComplexNumber& other) const {
        double denominator = other.real * other.real + other.imag * other.imag;
        if (denominator == 0) {
            throw runtime_error("Ошибка: Деление на ноль.");
        }
        double newReal = (real * other.real + imag * other.imag) / denominator;
        double newImag = (imag * other.real - real * other.imag) / denominator;
        return ComplexNumber(newReal, newImag);
    }

    bool operator==(const ComplexNumber& other) const {
        return (real == other.real) && (imag == other.imag);
    }

    bool operator!=(const ComplexNumber& other) const {
        return !(*this == other);
    }

    friend ostream& operator<<(ostream& os, const ComplexNumber& num);
    friend istream& operator>>(istream& is, ComplexNumber& num);
};

ostream& operator<<(ostream& os, const ComplexNumber& num) {
    os << num.real;
    if (num.imag >= 0) {
        os << " + " << num.imag << "i";
    } else {
        os << " - " << -num.imag << "i";
    }
    return os;
}

istream& operator>>(istream& is, ComplexNumber& num) {
    cout << "Введите вещественную часть: ";
    is >> num.real;
    cout << "Введите мнимую часть: ";
    is >> num.imag;
    return is;
}

int main() {
    setlocale(LC_ALL, "Russian");

    try {
        ComplexNumber a, b;

        cout << "Введите первое комплексное число:" << endl;
        cin >> a;
        cout << "\nВведите второе комплексное число:" << endl;
        cin >> b;

        cout << "\na = " << a << endl;
        cout << "b = " << b << endl;

        ComplexNumber sum = a + b;
        ComplexNumber diff = a - b;
        ComplexNumber prod = a * b;

        cout << "a + b = " << sum << endl;
        cout << "a - b = " << diff << endl;
        cout << "a * b = " << prod << endl;

        try {
            ComplexNumber div = a / b;
            cout << "a / b = " << div << endl;
        } catch (const exception& e) {
            cout << e.what() << endl;
        }

        if (a == b) {
            cout << "a и b равны." << endl;
        } else {
            cout << "a и b не равны." << endl;
        }

    } catch (const exception& e) {
        cerr << "Ошибка: " << e.what() << endl;
    }

    return 0;
}