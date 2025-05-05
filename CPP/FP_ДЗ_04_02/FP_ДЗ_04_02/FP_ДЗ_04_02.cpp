#include <iostream>
using namespace std;

void main() {
    setlocale(LC_ALL, "Russian");

    string pizzaNames[] = { "Маргарита", "Пепперони", "Гавайская", "Четыре сыра" };
    double pizzaPrices[] = { 10.0, 12.0, 11.0, 13.0 };

    string drinkNames[] = { "Кола", "Сок", "Чай" };
    double drinkPrices[] = { 1.5, 2.5, 3.0 };

    int pizzaQuantity[4] = { 0 };
    int drinkQuantity[3] = { 0 };

    cout << "Меню пиццы:\n";
    for (int i = 0; i < 4; ++i) {
        cout << i + 1 << ". " << pizzaNames[i] << " - $" << pizzaPrices[i] << endl;
    }

    cout << "\nМеню напитков:\n";
    for (int i = 0; i < 3; ++i) {
        cout << i + 5 << ". " << drinkNames[i] << " - $" << drinkPrices[i] << endl;
    }

    int code, quantity;
    double totalPizzaPrice = 0.0, totalDrinkPrice = 0.0, totalPrice = 0.0;

    while (true) {
        cout << "\nВведите код продукта (0 для завершения заказа): ";
        cin >> code;

        if (code == 0) break;

        cout << "Введите количество: ";
        cin >> quantity;

        if (code >= 1 && code <= 4) {
            pizzaQuantity[code - 1] += quantity;
        } else if (code >= 5 && code <= 7) {
            drinkQuantity[code - 5] += quantity;
        } else {
            cout << "Неверный код продукта, попробуйте снова." << endl;
        }
    }

    for (int i = 0; i < 4; ++i) {
        int freePizzas = pizzaQuantity[i] / 5;
        totalPizzaPrice += pizzaPrices[i] * (pizzaQuantity[i] - freePizzas);
    }

    for (int i = 0; i < 3; ++i) {
        double drinkCost = drinkPrices[i] * drinkQuantity[i];
        if (drinkPrices[i] > 2.0 && drinkQuantity[i] > 3) {
            drinkCost -= drinkCost * 0.15;
        }
        totalDrinkPrice += drinkCost;
    }

    totalPrice = totalPizzaPrice + totalDrinkPrice;

    if (totalPrice > 50) {
        totalPrice -= totalPrice * 0.20;
    }

    cout << "\nВаш заказ:\n";

    for (int i = 0; i < 4; ++i) {
        if (pizzaQuantity[i] > 0) {
            cout << pizzaNames[i] << " - " << pizzaQuantity[i] << " шт. (оплачиваемых: "
                << pizzaQuantity[i] - pizzaQuantity[i] / 5 << ") - $"
                << pizzaPrices[i] * (pizzaQuantity[i] - pizzaQuantity[i] / 5) << endl;
        }
    }

    for (int i = 0; i < 3; ++i) {
        if (drinkQuantity[i] > 0) {
            cout << drinkNames[i] << " - " << drinkQuantity[i] << " шт. - $"
                << drinkPrices[i] * drinkQuantity[i] << endl;
        }
    }

    cout << "\nИтого к оплате: $" << totalPrice << endl;
}
