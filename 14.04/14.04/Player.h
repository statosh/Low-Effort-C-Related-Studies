#ifndef PLAYER_H
#define PLAYER_H

#include <vector>
#include <memory>
#include "Unit.h"

class Player {
private:
    std::vector<std::shared_ptr<Unit>> army;
    char symbol;
public:
    Player(char sym) : symbol(sym) {}
    void addUnit(std::shared_ptr<Unit> unit);
    void removeUnit(int x, int y);
    char getSymbol() const;
    const std::vector<std::shared_ptr<Unit>>& getArmy() const;
    std::shared_ptr<Unit> findUnit(int x, int y) const;
};

#endif // PLAYER_H