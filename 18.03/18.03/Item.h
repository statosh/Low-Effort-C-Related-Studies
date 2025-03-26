#ifndef ITEM_H
#define ITEM_H

class Person;

class Item {
public:
    virtual void applyEffect(Person& person) = 0;
    virtual ~Item() = default;
};

#endif