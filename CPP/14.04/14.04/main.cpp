#include <iostream>
#include <cstdlib>
#include <ctime>
#include <locale>
#include "Game.h"

int main() {
    setlocale(LC_ALL, "Russian");

    srand(static_cast<unsigned int>(time(nullptr)));

    Map map(10, 10);
    map.generateRandomMap();

    Player player1('Z');

    Game game(map, player1);
    game.run();

    return 0;
}