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
//    cout << "������� ������� ����� �� ������ �� " << months << " �������:" << endl;
//    for (int i = 0; i < months; ++i) {
//        cout << "����� " << i + 1 << ": ";
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
//    cout << "������������ ������� ���� � ������ " << maxMonth + 1 << " � ��������� " << profit[maxMonth] << endl;
//    cout << "����������� ������� ���� � ������ " << minMonth + 1 << " � ��������� " << profit[minMonth] << endl;
//
//    return 0;
//}