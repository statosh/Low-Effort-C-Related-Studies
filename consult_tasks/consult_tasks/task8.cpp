#include <iostream>
#include "task8.h"

// ������ 1: ������������ ��������� ������ - ��� ��������� ������, ������ ������� ����� �������� �� ����� ���������� ���������.
// �������� ������������: �������� � ����������� ������������� ������.
//
// ������ 2: �������� ����: ��������� ������, �����, �������, �������, �����, ���-�������.
//
// ������ 3: ������� ������ ���������� ������: �������� �������� � �����, ������ �� ������� �������� ������ �� ��������� ����.
// ��������: ����������, ��������, �����.
//
// ������ 4: �������� ������ ������ - ��������� ������, ��� ������ ���� ����� �� ����� ���� ��������,
// � ��� ������� ���� �������� � ����� ��������� ������, ��� �������� ����, � � ������ - ������. �������� ��������: ������� �����, ������� � ��������.
//
// ������ 5: ���-������� - ��������� ������, ���������� �� ���-�������� ��� �������� ������� � ���������.
// ��������: �������� (�������� �������� ������� ��� �������� ���������).

class Node {
public:
    int data;
    Node* prev;
    Node* next;

    Node(int val) : data(val), prev(nullptr), next(nullptr) {}
};

class DoublyLinkedList {
private:
    Node* head;
    Node* tail;
    size_t size;

public:
    DoublyLinkedList() : head(nullptr), tail(nullptr), size(0) {}

    ~DoublyLinkedList() {
        Node* current = head;
        while (current != nullptr) {
            Node* next = current->next;
            delete current;
            current = next;
        }
    }

    void add(int value) {
        Node* newNode = new Node(value);
        if (tail == nullptr) {
            head = tail = newNode;
        } else {
            tail->next = newNode;
            newNode->prev = tail;
            tail = newNode;
        }
        size++;
    }

    void removeAtIndex(size_t index) {
        if (index >= size) {
            std::cerr << "������ ��� ���������!" << std::endl;
            return;
        }
        Node* current = head;
        for (size_t i = 0; i < index; ++i) {
            current = current->next;
        }
        if (current->prev) {
            current->prev->next = current->next;
        } else {
            head = current->next;
        }
        if (current->next) {
            current->next->prev = current->prev;
        } else {
            tail = current->prev;
        }
        delete current;
        size--;
    }

    void print() const {
        Node* current = head;
        while (current != nullptr) {
            std::cout << current->data << " ";
            current = current->next;
        }
        std::cout << std::endl;
    }

    bool search(int value) const {
        Node* current = head;
        while (current != nullptr) {
            if (current->data == value) {
                return true;
            }
            current = current->next;
        }
        return false;
    }
};

void task8() {
    DoublyLinkedList list;
    list.add(10);
    list.add(20);
    list.add(30);
    std::cout << "������: ";
    list.print();
    list.removeAtIndex(1);
    std::cout << "����� �������� ������� ��������: ";
    list.print();
    int value = 30;
    if (list.search(value)) {
        std::cout << "������� " << value << " ������." << std::endl;
    } else {
        std::cout << "������� " << value << " �� ������." << std::endl;
    }
}