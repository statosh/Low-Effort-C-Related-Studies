#include "Player.h"

void Player::addUnit(std::shared_ptr<Unit> unit) {
    army.push_back(unit);
}

void Player::removeUnit(int x, int y) {
    for (auto it = army.begin(); it != army.end(); ++it) {
        if ((*it)->getX() == x && (*it)->getY() == y) {
            army.erase(it);
            return;
        }
    }
}

char Player::getSymbol() const {
    return symbol;
}

const std::vector<std::shared_ptr<Unit>>& Player::getArmy() const {
    return army;
}

std::shared_ptr<Unit> Player::findUnit(int x, int y) const {
    for (const auto& unit : army) {
        if (unit->getX() == x && unit->getY() == y) {
            return unit;
        }
    }
    return nullptr;
}