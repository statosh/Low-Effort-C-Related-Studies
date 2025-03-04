#include <iostream>

using namespace std;

int main() {
    setlocale(LC_ALL, "Russian");

    const int rows = 3; 
    const int cols = 4; 

    int array[rows][cols] = {
        {1, 4, 8, 8},
        {12, 1, 1, 1},
        {0, 7, 12, 1}
    };

    int rowSums[rows] = { 0 }; 
    int colSums[cols] = { 0 }; 
    int totalSum = 0;

    for (int i = 0; i < rows; ++i) {
        for (int j = 0; j < cols; ++j) {
            rowSums[i] += array[i][j];
            colSums[j] += array[i][j];
            totalSum += array[i][j];
        }
    }

    for (int i = 0; i < rows; ++i) {
        for (int j = 0; j < cols; ++j) {
            cout << array[i][j] << "\t";
        }
        cout << "| " << rowSums[i] << endl;
    }

    for (int j = 0; j < cols; ++j) {
        cout << "---------";
    }
    cout << endl;

    for (int j = 0; j < cols; ++j) {
        cout << colSums[j] << "\t";
    }
    cout << "| " << totalSum << endl;

    return 0;
}