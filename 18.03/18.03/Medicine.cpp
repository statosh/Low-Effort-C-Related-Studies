#include "Medicine.h"
#include "Person.h"

Medicine::Medicine(int healthBoost) : healthBoost(healthBoost) {}

void Medicine::applyEffect(Person& person) {
    person.increaseHealth(healthBoost);
}