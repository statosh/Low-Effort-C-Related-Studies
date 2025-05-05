#ifndef FOOD_H
#define FOOD_H

#include "Item.h"

class Food : public Item {
protected:
    int hungerReduction;
public:
    Food(int hungerReduction);
    void applyEffect(Person& person) override;
};

#endif