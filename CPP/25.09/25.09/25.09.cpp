#include <iostream>
using namespace std;

void main(){
	setlocale(LC_ALL, "Russian");

	int X; 

	cout << "Введите кол.во килобайт: ";
	cin >> X;
	cout << ( X * 1024 ) * 8;
}