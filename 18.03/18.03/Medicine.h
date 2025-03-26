#ifndef MEDICINE_H
#define MEDICINE_H

#include "Item.h"

class Medicine : public Item {
protected:
    int healthBoost;
public:
    Medicine(int healthBoost);
    void applyEffect(Person& person) override;
};

#endif