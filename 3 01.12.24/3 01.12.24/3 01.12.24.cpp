#include <iostream>
using namespace std;

void CopyArray(int* source, int* destination, int size) {
    int* srcPtr = source;
    int* destPtr = destination;

    for (int i = 0; i < size; ++i) {
        *(destPtr++) = *(srcPtr++);
    }
}

int main() {
    setlocale(LC_ALL, "Russian");

    const int size = 5;
    int source[size] = { 1, 2, 3, 4, 5 };
    int destination[size] = {};

    cout << "Исходный массив: ";
    for (int i = 0; i < size; ++i) {
        cout << source[i] << " ";
    }
    cout << endl;

    CopyArray(source, destination, size);

    cout << "Скопированный массив: ";
    for (int i = 0; i < size; ++i) {
        cout << destination[i] << " ";
    }
    cout << endl;

    return 0;
}
