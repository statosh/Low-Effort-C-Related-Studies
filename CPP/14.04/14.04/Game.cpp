#include "Game.h"
#include <iostream>
#include <cstdlib>

#ifdef _WIN32
#include <windows.h>
#else
#include <unistd.h>
#endif

Game::Game(Map m, Player p1) : map(m), player1(p1), currentPlayerIsPlayer1(true) {}

void Game::run() {
    bool running = true;
    while (running) {
        clearScreen();
        map.display();
        displayMenu();
        int choice;
        std::cin >> choice;

        Player& current = player1;

        switch (choice) {
        case 1: {
            int x, y;
            std::cout << "Введите координаты (x y): ";
            std::cin >> x >> y;
            if (isValidCoordinate(x, y)) {
                addUnit(current, x, y);
            } else {
                std::cout << "Некорректные координаты!\n";
            }
            break;
        }
        case 2: {
            int oldX, oldY, newX, newY;
            std::cout << "Введите текущие координаты юнита (x y): ";
            std::cin >> oldX >> oldY;
            std::cout << "Введите новые координаты (x y): ";
            std::cin >> newX >> newY;
            if (isValidCoordinate(oldX, oldY) && isValidCoordinate(newX, newY)) {
                moveUnit(current, oldX, oldY, newX, newY);
            } else {
                std::cout << "Некорректные координаты!\n";
            }
            break;
        }
        case 3: {
            int x, y;
            std::cout << "Введите координаты юнита (x y): ";
            std::cin >> x >> y;
            if (isValidCoordinate(x, y)) {
                removeUnit(current, x, y);
            } else {
                std::cout << "Некорректные координаты!\n";
            }
            break;
        }
        case 4: {
            waitForNextTurn();
            break;
        }
        case 5: {
            running = false;
            break;
        }
        default:
            std::cout << "Неверный выбор!\n";
        }
    }
}

void Game::addUnit(Player& player, int x, int y) {
    if (map.isCellAvailable(x - 1, y - 1)) {
        player.addUnit(std::make_shared<Unit>(x - 1, y - 1));
        map.placeUnit(x - 1, y - 1, player.getSymbol());
    } else {
        std::cout << "Клетка занята или недоступна!\n";
    }
}

void Game::moveUnit(Player& player, int oldX, int oldY, int newX, int newY) {
    auto unit = player.findUnit(oldX - 1, oldY - 1);
    if (!unit) {
        std::cout << "Юнит не найден!\n";
        return;
    }

    if (map.isCellAvailable(newX - 1, newY - 1)) {
        map.clearUnit(oldX - 1, oldY - 1);
        unit->setX(newX - 1);
        unit->setY(newY - 1);
        map.placeUnit(newX - 1, newY - 1, player.getSymbol());
    } else {
        std::cout << "Клетка занята или недоступна!\n";
    }
}

void Game::removeUnit(Player& player, int x, int y) {
    player.removeUnit(x - 1, y - 1);
    map.clearUnit(x - 1, y - 1);
}

void Game::waitForNextTurn() {
    map.generateRandomMap();
    map.updateMap(player1.getArmy(), player1.getSymbol());
}

void Game::displayMenu() const {
    std::cout << "\n1. Добавить юнита\n";
    std::cout << "2. Переместить юнита\n";
    std::cout << "3. Убрать юнита\n";
    std::cout << "4. Ожидание\n";
    std::cout << "5. Завершить игру\n";
}

bool Game::isValidCoordinate(int x, int y) const {
    return x >= 1 && x <= map.getWidth() && y >= 1 && y <= map.getHeight();
}

void Game::clearScreen() const {
#ifdef _WIN32
    system("cls");
#else
    system("clear");
#endif
}