#ifndef PERSON_H
#define PERSON_H

#include <vector>
#include <memory>
#include "Item.h"

class Person {
private:
    int health;
    int energy;
    int hunger;
public:
    Person(int health, int energy, int hunger);
    void useItem(std::shared_ptr<Item> item);
    void increaseHealth(int amount);
    void reduceHunger(int amount);
    void increaseEnergy(int amount);
    void decreaseEnergy(int amount);
    void update();
    void printStatus() const;
};

#endif