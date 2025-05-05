#include "zoo_shop.h"

void ZooShop::addAnimal(const std::string& species, const std::string& name, int age, double price, const std::string& gender) {
    animals.emplace_back(species, name, age, price, gender);
    std::cout << "Животное добавлено.\n";
}

void ZooShop::removeAnimalBySpecies(const std::string& species) {
    auto it = std::remove_if(animals.begin(), animals.end(), [&](const Animal& animal) {
        return animal.getSpecies() == species;
        });
    if (it != animals.end()) {
        animals.erase(it, animals.end());
        std::cout << "Животные удалены.\n";
    } else {
        std::cout << "Животные с видом " << species << " не найдены.\n";
    }
}

void ZooShop::removeAnimalByName(const std::string& name) {
    auto it = std::remove_if(animals.begin(), animals.end(), [&](const Animal& animal) {
        return animal.getName() == name;
        });
    if (it != animals.end()) {
        animals.erase(it, animals.end());
        std::cout << "Животные удалены.\n";
    } else {
        std::cout << "Животные с именем " << name << " не найдены.\n";
    }
}

void ZooShop::findAnimalsBySpecies(const std::string& species) const {
    bool found = false;
    for (const auto& animal : animals) {
        if (animal.getSpecies() == species) {
            animal.display();
            found = true;
        }
    }
    if (!found) {
        std::cout << "Животные с видом " << species << " не найдены.\n";
    }
}

void ZooShop::findAnimalsByName(const std::string& name) const {
    bool found = false;
    for (const auto& animal : animals) {
        if (animal.getName() == name) {
            animal.display();
            found = true;
        }
    }
    if (!found) {
        std::cout << "Животные с именем " << name << " не найдены.\n";
    }
}

void ZooShop::findAnimalsByAge(int age) const {
    bool found = false;
    for (const auto& animal : animals) {
        if (animal.getAge() == age) {
            animal.display();
            found = true;
        }
    }
    if (!found) {
        std::cout << "Животные с возрастом " << age << " не найдены.\n";
    }
}

void ZooShop::findAnimalsByPrice(double price) const {
    bool found = false;
    for (const auto& animal : animals) {
        if (animal.getPrice() == price) {
            animal.display();
            found = true;
        }
    }
    if (!found) {
        std::cout << "Животные с ценой " << price << " не найдены.\n";
    }
}

void ZooShop::changeAnimalPrice(const std::string& name, double newPrice) {
    for (auto& animal : animals) {
        if (animal.getName() == name) {
            animal.setPrice(newPrice);
            std::cout << "Цена животного " << name << " изменена на " << newPrice << ".\n";
            return;
        }
    }
    std::cout << "Животное с именем " << name << " не найдено.\n";
}

void ZooShop::displayAllAnimals() const {
    if (animals.empty()) {
        std::cout << "В зоомагазине нет животных.\n";
        return;
    }
    for (const auto& animal : animals) {
        animal.display();
    }
}

void ZooShop::sortAnimalsBySpecies() {
    std::sort(animals.begin(), animals.end(), [](const Animal& a, const Animal& b) {
        return a.getSpecies() < b.getSpecies();
        });
    std::cout << "Животные отсортированы по виду.\n";
}

void ZooShop::sortAnimalsByAge() {
    std::sort(animals.begin(), animals.end(), [](const Animal& a, const Animal& b) {
        return a.getAge() < b.getAge();
        });
    std::cout << "Животные отсортированы по возрасту.\n";
}

void ZooShop::sortAnimalsByPrice() {
    std::sort(animals.begin(), animals.end(), [](const Animal& a, const Animal& b) {
        return a.getPrice() > b.getPrice();
        });
    std::cout << "Животные отсортированы по цене.\n";
}

void ZooShop::saveToFile(const std::string& filename) const {
    std::ofstream outFile(filename);
    if (!outFile) {
        std::cerr << "Не удалось открыть файл для записи.\n";
        return;
    }
    for (const auto& animal : animals) {
        outFile << animal.getSpecies() << "," << animal.getName() << ","
            << animal.getAge() << "," << animal.getPrice() << ","
            << animal.getGender() << std::endl;
    }
    outFile.close();
    std::cout << "Данные сохранены в файл " << filename << ".\n";
}

void ZooShop::loadFromFile(const std::string& filename) {
    std::ifstream inFile(filename);
    if (!inFile) {
        std::cerr << "Не удалось открыть файл для чтения.\n";
        return;
    }
    std::string line;
    while (std::getline(inFile, line)) {
        std::string species, name, gender;
        int age;
        double price;
        size_t pos1 = line.find(',');
        size_t pos2 = line.find(',', pos1 + 1);
        size_t pos3 = line.find(',', pos2 + 1);
        size_t pos4 = line.find(',', pos3 + 1);
        species = line.substr(0, pos1);
        name = line.substr(pos1 + 1, pos2 - pos1 - 1);
        age = std::stoi(line.substr(pos2 + 1, pos3 - pos2 - 1));
        price = std::stod(line.substr(pos3 + 1, pos4 - pos3 - 1));
        gender = line.substr(pos4 + 1);
        animals.emplace_back(species, name, age, price, gender);
    }
    inFile.close();
    std::cout << "Данные загружены из файла " << filename << ".\n";
}