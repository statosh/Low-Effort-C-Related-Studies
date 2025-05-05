#include <iostream>
#include <vector>
#include <string>

using namespace std;

class Item {
private:
    int itemId;
    string name;
    double price;

public:
    Item(int itemId, const string& name, double price)
        : itemId(itemId), name(name), price(price) {}

    double getTotalPrice(int quantity) const {
        return price * quantity;
    }

    // Геттеры
    int getItemId() const { return itemId; }
    string getName() const { return name; }
    double getPrice() const { return price; }
};

class Order {
protected:
    int orderId;
    string customerName;
    vector<Item> items;

public:
    Order(int orderId, const string& customerName, const vector<Item>& items)
        : orderId(orderId), customerName(customerName), items(items) {}

    virtual double calculateTotalPrice() const {
        double total = 0.0;
        for (const auto& item : items) {
            total += item.getTotalPrice(1);
        }
        return total;
    }

    virtual void printOrderDetails() const {
        cout << "Order ID: " << orderId << endl;
        cout << "Customer Name: " << customerName << endl;
        cout << "Items:" << endl;
        for (const auto& item : items) {
            cout << "  Item ID: " << item.getItemId() << ", Name: " << item.getName() << ", Price: " << item.getPrice() << endl;
        }
        cout << "Total Price: " << calculateTotalPrice() << endl;
    }
};

class OnlineOrder : public Order {
private:
    string shippingAddress;

public:
    OnlineOrder(int orderId, const string& customerName, const vector<Item>& items, const string& shippingAddress)
        : Order(orderId, customerName, items), shippingAddress(shippingAddress) {}

    void applyDiscount(double discountPercentage) {
        double discount = calculateTotalPrice() * (discountPercentage / 100.0);
        double discountedPrice = calculateTotalPrice() - discount;
        cout << "Discount Applied: " << discountPercentage << "%" << endl;
        cout << "Discounted Total Price: " << discountedPrice << endl;
    }

    void printOrderDetails() const override {
        Order::printOrderDetails();
        cout << "Shipping Address: " << shippingAddress << endl;
    }

    double calculateTotalPrice() const override {
        return Order::calculateTotalPrice();
    }
};

class ExpressOrder : public OnlineOrder {
private:
    string deliveryTime;
    double expressFee;

public:
    ExpressOrder(int orderId, const string& customerName, const vector<Item>& items, const string& shippingAddress, double expressFee)
        : OnlineOrder(orderId, customerName, items, shippingAddress), deliveryTime(""), expressFee(expressFee) {}

    double calculateTotalPrice() const override {
        return OnlineOrder::calculateTotalPrice() + expressFee;
    }

    void scheduleDelivery(const string& timeSlot) {
        deliveryTime = timeSlot;
        cout << "Delivery Scheduled at: " << deliveryTime << endl;
    }

    void printOrderDetails() const override {
        OnlineOrder::printOrderDetails();
        cout << "Express Fee: " << expressFee << endl;
        cout << "Delivery Time: " << deliveryTime << endl;
    }
};

int main() {
    setlocale(LC_ALL, "Russian");

    Item item1(1, "Ноутбук", 1000.0);
    Item item2(2, "Мышь", 25.0);
    Item item3(3, "Клавиатура", 50.0);

    vector<Item> items = { item1, item2, item3 };

    OnlineOrder onlineOrder(101, "Иван Иванов", items, "ул. Ленина, д. 1");

    onlineOrder.printOrderDetails();

    onlineOrder.applyDiscount(10.0);

    ExpressOrder expressOrder(102, "Мария Петрова", items, "ул. Пушкина, д. 2", 50.0);

    expressOrder.printOrderDetails();

    expressOrder.scheduleDelivery("12:00");

    expressOrder.printOrderDetails();

    return 0;
}