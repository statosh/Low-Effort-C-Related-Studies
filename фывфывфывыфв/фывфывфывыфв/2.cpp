#include <iostream>
using namespace std;

int main() {
    setlocale(LC_ALL, "Russian");

    int x, y;
    cout << "¬ведите целое число x: ";
    cin >> x;
    cout << "¬ведите целое число y: ";
    cin >> y;

    long long result = 1;
    for (int i = 0; i < y; i++) {
        result *= x;
    }

    cout << x << " в степени " << y << " равно: " << result << endl;
    return 0;
}