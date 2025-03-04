#include <iostream>

using namespace std;

class FactorialCalculator {
public:
    unsigned long long factorial(int n) {
        if (n < 0) {
            cerr << "Факториал не определен для отрицательных чисел." << endl;
            return 0;
        }
        unsigned long long result = 1;
        for (int i = 2; i <= n; ++i) {
            result *= i;
        }
        return result;
    }
};

int main() {
    setlocale(LC_ALL, "Russian");

    FactorialCalculator calculator;
    int number;

    cout << "Введите число для вычисления факториала: ";
    cin >> number;

    unsigned long long result = calculator.factorial(number);
    cout << "Факториал числа " << number << " равен " << result << endl;

    return 0;
}