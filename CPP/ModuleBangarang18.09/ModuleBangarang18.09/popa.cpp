#include <iostream>
using namespace std;

int main() {
    setlocale(LC_ALL, "Russian");
    
    double x;

    cout << "¬ведите длину в сантиметрах: ";
    cin >> x;
    cout << "ƒлина в дюймах: " << x / 2.542;
}