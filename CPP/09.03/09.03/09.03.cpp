#include <iostream>
using namespace std;

struct Node {
    int key;
    Node* left;
    Node* right;

    Node(int value) : key(value), left(nullptr), right(nullptr) {}
};

class BinarySearchTree {
private:
    Node* root;

    void destroyTree(Node* node) {
        if (node) {
            destroyTree(node->left);
            destroyTree(node->right);
            delete node;
        }
    }

    Node* insert(Node* node, int key) {
        if (!node) return new Node(key);
        if (key < node->key) node->left = insert(node->left, key);
        else if (key > node->key) node->right = insert(node->right, key);
        return node;
    }

    Node* findMin(Node* node) {
        while (node && node->left) node = node->left;
        return node;
    }

    Node* remove(Node* node, int key) {
        if (!node) return nullptr;
        if (key < node->key) node->left = remove(node->left, key);
        else if (key > node->key) node->right = remove(node->right, key);
        else {
            if (!node->left) {
                Node* temp = node->right;
                delete node;
                return temp;
            }
            if (!node->right) {
                Node* temp = node->left;
                delete node;
                return temp;
            }
            Node* temp = findMin(node->right);
            node->key = temp->key;
            node->right = remove(node->right, temp->key);
        }
        return node;
    }

    bool find(Node* node, int key) {
        if (!node) return false;
        if (key == node->key) return true;
        return key < node->key ? find(node->left, key) : find(node->right, key);
    }

    void inOrderTraversal(Node* node) {
        if (node) {
            inOrderTraversal(node->left);
            cout << node->key << " ";
            inOrderTraversal(node->right);
        }
    }

    void preOrderTraversal(Node* node) {
        if (node) {
            cout << node->key << " ";
            preOrderTraversal(node->left);
            preOrderTraversal(node->right);
        }
    }

    void postOrderTraversal(Node* node) {
        if (node) {
            postOrderTraversal(node->left);
            postOrderTraversal(node->right);
            cout << node->key << " ";
        }
    }

    int height(Node* node) {
        if (!node) return 0;
        return 1 + max(height(node->left), height(node->right));
    }

    bool isBalanced(Node* node) {
        if (!node) return true;
        int leftHeight = height(node->left);
        int rightHeight = height(node->right);
        return abs(leftHeight - rightHeight) <= 1 && isBalanced(node->left) && isBalanced(node->right);
    }

public:
    BinarySearchTree() : root(nullptr) {}

    ~BinarySearchTree() {
        destroyTree(root);
    }

    void insert(int key) {
        root = insert(root, key);
    }

    void remove(int key) {
        root = remove(root, key);
    }

    bool find(int key) {
        return find(root, key);
    }

    void inOrderTraversal() {
        inOrderTraversal(root);
        cout << endl;
    }

    void preOrderTraversal() {
        preOrderTraversal(root);
        cout << endl;
    }

    void postOrderTraversal() {
        postOrderTraversal(root);
        cout << endl;
    }

    bool isBalanced() {
        return isBalanced(root);
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
    BinarySearchTree bst;

    while (true) {
        cout << R"(
Меню:
1. Добавить элемент
2. Удалить элемент
3. Найти элемент
4. Прямой обход (in-order)
5. Симметричный обход (pre-order)
6. Обратный обход (post-order)
7. Проверить сбалансированность
0. Выход
Выберите действие: )";

        int choice, value;
        safeInput(choice);

        switch (choice) {
        case 1:
            cout << "Введите значение: ";
            safeInput(value);
            bst.insert(value);
            cout << "Элемент добавлен.\n";
            break;
        case 2:
            cout << "Введите значение: ";
            safeInput(value);
            bst.remove(value);
            cout << "Элемент удалён.\n";
            break;
        case 3:
            cout << "Введите значение: ";
            safeInput(value);
            cout << (bst.find(value) ? "Элемент найден.\n" : "Элемент не найден.\n");
            break;
        case 4:
            cout << "Прямой обход: ";
            bst.inOrderTraversal();
            break;
        case 5:
            cout << "Симметричный обход: ";
            bst.preOrderTraversal();
            break;
        case 6:
            cout << "Обратный обход: ";
            bst.postOrderTraversal();
            break;
        case 7:
            cout << (bst.isBalanced() ? "Дерево сбалансировано.\n" : "Дерево не сбалансировано.\n");
            break;
        case 0:
            cout << "Выход из программы.\n";
            return 0;
        default:
            cout << "Неверный выбор!\n";
        }
    }
}
