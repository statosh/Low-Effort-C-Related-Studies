#ifndef ANIMAL_H
#define ANIMAL_H

#include <string>
#include <iostream>

class Animal {
private:
    std::string species;
    std::string name;
    int age;
    double price;
    std::string gender;

public:
    Animal(const std::string& species, const std::string& name, int age, double price, const std::string& gender)
        : species(species), name(name), age(age), price(price), gender(gender) {
    }

    std::string getSpecies() const { return species; }
    std::string getName() const { return name; }
    int getAge() const { return age; }
    double getPrice() const { return price; }
    std::string getGender() const { return gender; }

    void setPrice(double price) { this->price = price; }

    void display() const {
        std::cout << "Вид: " << species << ", Имя: " << name << ", Возраст: " << age
            << ", Цена: " << price << ", Пол: " << gender << std::endl;
    }
};

#endif // ANIMAL_H