#include <iostream>
using namespace std;

void Sort(int mas[], int size, bool sort = false) {
    if (sort) {
        for (int i = 0; i < size - 1; ++i) {
            for (int j = 0; j < size - i - 1; ++j) {
                if (mas[j] < mas[j + 1]) {
                    int temp = mas[j];
                    mas[j] = mas[j + 1];
                    mas[j + 1] = temp;
                }
            }
        }
    } else {
        for (int i = 0; i < size - 1; ++i) {
            for (int j = 0; j < size - i - 1; ++j) {
                if (mas[j] > mas[j + 1]) {
                    int temp = mas[j];
                    mas[j] = mas[j + 1];
                    mas[j + 1] = temp;
                }
            }
        }
    }
}

int main() {
    int mas[10] = { 23, 5, 1, 655, 23, 6, 34, 44, 6, 2 };

    Sort(mas, 10, true);
    for (int i = 0; i < 10; ++i) {
        cout << mas[i] << " ";
    }
    cout << endl;


    Sort(mas, 10);
    for (int i = 0; i < 10; ++i) {
        cout << mas[i] << " ";
    }
    cout << endl;

    return 0;
}
