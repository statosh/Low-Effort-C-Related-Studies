#include <iostream>
using namespace std;

int main() {
    setlocale(LC_ALL, "Russian");
    const int size = 5;
    int parapam[size] = {5, 123, 54, -23, 1};
    int sum = 0;
    for (int i = 0; i < size; i++) {
        sum = sum + parapam[i];
    }    
    cout << "Среднее арифметическое: " << sum / size;
    return 0;
}

