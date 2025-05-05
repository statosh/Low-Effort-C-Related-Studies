#include "Person.h"
#include <iostream>

Person::Person(int health, int energy, int hunger)
    : health(health), energy(energy), hunger(hunger) {
}

void Person::useItem(std::shared_ptr<Item> item) {
    item->applyEffect(*this);
}

void Person::increaseHealth(int amount) {
    health += amount;
    if (health > 100) health = 100;
}

void Person::reduceHunger(int amount) {
    hunger -= amount;
    if (hunger < 0) hunger = 0;
}

void Person::increaseEnergy(int amount) {
    energy += amount;
    if (energy > 100) energy = 100;
}

void Person::decreaseEnergy(int amount) {
    energy -= amount;
    if (energy < 0) energy = 0;
}

void Person::update() {
    hunger += 5;
    if (hunger > 100) hunger = 100;
    energy -= 2;
    if (energy < 0) energy = 0;
    if (hunger >= 80) health -= 5;
    if (health < 0) health = 0;
}

void Person::printStatus() const {
    std::cout << "Здоровье: " << health << ", Энергия: " << energy << ", Голод: " << hunger << std::endl;
}