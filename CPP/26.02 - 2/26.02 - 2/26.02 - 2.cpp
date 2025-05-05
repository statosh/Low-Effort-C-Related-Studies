#include <iostream>
using namespace std;

template <typename T>
class StackArray {
private:
    T* data;
    size_t capacity;
    size_t top;

    void resize() {
        capacity *= 2;
        T* newData = new T[capacity];
        for (size_t i = 0; i < top; ++i) {
            newData[i] = data[i];
        }
        delete[] data;
        data = newData;
    }

public:
    explicit StackArray(size_t max_size = 10) : capacity(max_size), top(0) {
        data = new T[capacity];
    }

    ~StackArray() {
        delete[] data;
    }

    void push(const T& item) {
        if (top == capacity) {
            resize();
        }
        data[top++] = item;
    }

    T pop() {
        if (is_empty()) {
            throw out_of_range("Стек пуст, невозможно удалить элемент!");
        }
        return data[--top];
    }

    const T& peek() const {
        if (is_empty()) {
            throw out_of_range("Стек пуст!");
        }
        return data[top - 1];
    }

    bool is_empty() const {
        return top == 0;
    }

    size_t size() const {
        return top;
    }

    void print() const {
        if (is_empty()) {
            cout << "[Пустой масс.стек]\n";
            return;
        }
        cout << "[Масс.стек]: ";
        for (size_t i = 0; i < top; ++i) {
            cout << data[i] << " ";
        }
        cout << endl;
    }
};

template <typename T>
class StackList {
private:
    struct Node {
        T data;
        Node* next;
        Node(const T& value, Node* nextNode = nullptr) : data(value), next(nextNode) {}
    };

    Node* head;
    size_t count;

public:
    StackList() : head(nullptr), count(0) {}

    ~StackList() {
        while (!is_empty()) {
            pop();
        }
    }

    void push(const T& item) {
        head = new Node(item, head);
        count++;
    }

    T pop() {
        if (is_empty()) {
            throw out_of_range("Стек пуст, невозможно удалить элемент!");
        }
        Node* temp = head;
        T value = temp->data;
        head = head->next;
        delete temp;
        count--;
        return value;
    }

    const T& peek() const {
        if (is_empty()) {
            throw out_of_range("Стек пуст!");
        }
        return head->data;
    }

    bool is_empty() const {
        return head == nullptr;
    }

    size_t size() const {
        return count;
    }

    void print() const {
        if (is_empty()) {
            cout << "[Пустой указ.стек]\n";
            return;
        }
        cout << "[Указ.стек]: ";
        Node* current = head;
        while (current) {
            cout << current->data << " ";
            current = current->next;
        }
        cout << endl;
    }
};

void safeInput(int& value) {
    while (!(cin >> value)) {
        cout << "Ошибка: введите целое число!" << endl;
        cin.clear();
        while (cin.get() != '\n');
    }
}

int main() {
    setlocale(LC_ALL, "Russian");

    StackArray<int> stackArray;
    StackList<int> stackList;

    while (true) {
        cout << R"(
Меню:

-----------[ Массив ]-----------
1. Добавить элемент в стек
2. Удалить элемент из стека
3. Посмотреть верхний элемент
4. Проверить, пуст ли стек
5. Вывести размер стека
6. Вывести стек

----------[ Указатели ]----------
7. Добавить элемент в стек
8. Удалить элемент из стека
9. Посмотреть верхний элемент
10. Проверить, пуст ли стек
11. Вывести размер стека
12. Вывести стек

0. Выход
Выберите действие: )";

        int choice, value;
        cin >> choice;

        try {
            switch (choice) {
            case 1:
                cout << "Введите число: ";
                safeInput(value);
                stackArray.push(value);
                stackArray.print();
                break;
            case 2:
                cout << "Удалён элемент: " << stackArray.pop() << endl;
                stackArray.print();
                break;
            case 3:
                cout << "Верхний элемент: " << stackArray.peek() << endl;
                break;
            case 4:
                cout << (stackArray.is_empty() ? "Стек пуст" : "Стек не пуст") << endl;
                break;
            case 5:
                cout << "Размер стека: " << stackArray.size() << endl;
                break;
            case 6:
                stackArray.print();
                break;
            case 7:
                cout << "Введите число: ";
                safeInput(value);
                stackList.push(value);
                stackList.print();
                break;
            case 8:
                cout << "Удалён элемент: " << stackList.pop() << endl;
                stackList.print();
                break;
            case 9:
                cout << "Верхний элемент: " << stackList.peek() << endl;
                break;
            case 10:
                cout << (stackList.is_empty() ? "Стек пуст" : "Стек не пуст") << endl;
                break;
            case 11:
                cout << "Размер стека: " << stackList.size() << endl;
                break;
            case 12:
                stackList.print();
                break;
            case 0:
                cout << "Выход из программы." << endl;
                return 0;
            default:
                cout << "Неверный выбор!" << endl;
            }
        } catch (const exception& e) {
            cout << "Ошибка: " << e.what() << endl;
        }
    }
}
