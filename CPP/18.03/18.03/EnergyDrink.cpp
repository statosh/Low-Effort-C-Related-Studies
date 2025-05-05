#include "EnergyDrink.h"
#include "Person.h"

EnergyDrink::EnergyDrink() {}

void EnergyDrink::applyEffect(Person& person) {
    person.increaseEnergy(25);
}