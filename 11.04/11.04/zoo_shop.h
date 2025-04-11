#ifndef ZOO_SHOP_H
#define ZOO_SHOP_H

#include <iostream>
#include <vector>
#include <fstream>
#include <algorithm>
#include "animal.h"

class ZooShop {
private:
    std::vector<Animal> animals;

public:
    void addAnimal(const std::string& species, const std::string& name, int age, double price, const std::string& gender);
    void removeAnimalBySpecies(const std::string& species);
    void removeAnimalByName(const std::string& name);
    void findAnimalsBySpecies(const std::string& species) const;
    void findAnimalsByName(const std::string& name) const;
    void findAnimalsByAge(int age) const;
    void findAnimalsByPrice(double price) const;
    void changeAnimalPrice(const std::string& name, double newPrice);
    void displayAllAnimals() const;
    void sortAnimalsBySpecies();
    void sortAnimalsByAge();
    void sortAnimalsByPrice();
    void saveToFile(const std::string& filename) const;
    void loadFromFile(const std::string& filename);
};

#endif // ZOO_SHOP_H