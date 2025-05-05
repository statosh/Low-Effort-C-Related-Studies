//#include <iostream>
//
//using namespace std;
//
//int main() {
//    setlocale(LC_ALL, "Russian");
//
//    const int rows = 3; 
//    const int cols = 4; 
//
//    int array[rows][cols] = {
//        {3, 5, 7, 2},
//        {8, 6, 4, 9},
//        {1, 2, 11, 3}
//    };
//
//    int sum = 0;
//    int totalElements = rows * cols;
//
//    int minElem = array[0][0];
//    int maxElem = array[0][0];
//
//    for (int i = 0; i < rows; ++i) {
//        for (int j = 0; j < cols; ++j) {
//            sum += array[i][j];
//            if (array[i][j] < minElem) {
//                minElem = array[i][j];
//            }
//            if (array[i][j] > maxElem) {
//                maxElem = array[i][j];
//            }
//        }
//    }
//
//    double average = sum / (totalElements * 1.0);
//
//    cout << "Сумма всех элементов массива: " << sum << endl;
//    cout << "Среднее арифметическое всех элементов массива: " << average << endl;
//    cout << "Минимальный элемент: " << minElem << endl;
//    cout << "Максимальный элемент: " << maxElem << endl;
//
//    return 0;
//}