#ifndef GAME_H
#define GAME_H

#include "Map.h"
#include "Player.h"
#include <vector>
#include <memory>

class Game {
private:
    Map map;
    Player player1;
    bool currentPlayerIsPlayer1;

    bool isValidCoordinate(int x, int y) const;

public:
    Game(Map m, Player p1);
    void run();
    void addUnit(Player& player, int x, int y);
    void moveUnit(Player& player, int oldX, int oldY, int newX, int newY);
    void removeUnit(Player& player, int x, int y);
    void waitForNextTurn();
    void displayMenu() const;
    void clearScreen() const;
};

#endif // GAME_H