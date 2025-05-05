#ifndef ENERGYDRINK_H
#define ENERGYDRINK_H

#include "Item.h"

class EnergyDrink : public Item {
public:
    EnergyDrink();
    void applyEffect(Person& person) override;
};

#endif