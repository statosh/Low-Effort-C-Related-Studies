#include <iostream>
using namespace std;

int main() {
    setlocale(LC_ALL, "Russian");

    int a;
    cout << "¬ведите целое число a: ";
    cin >> a;

    int sum = 0;
    for (int i = a; i <= 500; i++) {
        sum += i;
    }

    cout << "—умма целых чисел от " << a << " до 500: " << sum << endl;
    return 0;
}