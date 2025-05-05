#include <iostream>
using namespace std;
int main() {
    int age = 30;
    if (age < 18) {
        cout << "You are underage" << endl;
    } else if (age >= 65) {
        cout << "You are retired" << endl;
    } else {
        cout << "You are in your working years" << endl;
    }
}