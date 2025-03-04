//#include <iostream>
//using namespace std;
//
//int main() {
//    setlocale(LC_ALL, "Russian");
//
//    const int months = 12;
//    double profit[months];
//    int maxMonth = 0, minMonth = 0;
//
//    cout << "¬ведите прибыль фирмы за каждый из " << months << " мес€цев:" << endl;
//    for (int i = 0; i < months; ++i) {
//        cout << "ћес€ц " << i + 1 << ": ";
//        cin >> profit[i];
//
//        if (profit[i] > profit[maxMonth]) {
//            maxMonth = i;
//        }
//        if (profit[i] < profit[minMonth]) {
//            minMonth = i;
//        }
//    }
//
//    cout << "ћаксимальна€ прибыль была в мес€це " << maxMonth + 1 << " и составила " << profit[maxMonth] << endl;
//    cout << "ћинимальна€ прибыль была в мес€це " << minMonth + 1 << " и составила " << profit[minMonth] << endl;
//
//    return 0;
//}