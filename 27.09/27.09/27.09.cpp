#include <iostream>
using namespace std;

int main() {
    setlocale(LC_ALL, "Russian");

    int n, m, k;
    cin >> n >> m >> k;

    if ((k % m == 0 && k / m <= n) || (k % n == 0 && k / n <= m)) {
        cout << "Можно разделить\n";
    }
    else {
        cout << "Нельзя разделить\n";
    }

    cout << "----------------------------------\n";

    int kz;
    cin >> kz;

    if (kz >= 0 && (kz % 3 == 0 || kz % 5 == 0 || (kz >= 5 && (kz - 5) % 3 == 0))) {
        cout << "Можно купить\n";
    }
    else {
        cout << "Нельзя купить\n";
    }

}