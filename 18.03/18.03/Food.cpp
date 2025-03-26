#include "Food.h"
#include "Person.h"

Food::Food(int hungerReduction) : hungerReduction(hungerReduction) {}

void Food::applyEffect(Person& person) {
    person.reduceHunger(hungerReduction);
}