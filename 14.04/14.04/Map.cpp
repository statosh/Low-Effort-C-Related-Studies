#include "Map.h"
#include <cstdlib>
#include <ctime>

Map::Map(int w, int h) : width(w), height(h) {
    grid.resize(height, std::vector<char>(width, '.'));
}

void Map::generateRandomMap() {
    for (int i = 0; i < height; ++i) {
        for (int j = 0; j < width; ++j) {
            int r = rand() % 100;
            if (r < 10) grid[i][j] = '#';
            else if (r < 20) grid[i][j] = '~';
            else if (r < 30) grid[i][j] = '*';
            else grid[i][j] = '.';
        }
    }
}

void Map::display() const {
    std::cout << "   ";
    for (int j = 1; j <= width; ++j) {
        std::cout << j << " ";
    }
    std::cout << "\n";

    for (int i = 0; i < height; ++i) {
        std::cout << i + 1 << "  ";
        for (int j = 0; j < width; ++j) {
            std::cout << grid[i][j] << " ";
        }
        std::cout << "\n";
    }
}

bool Map::isCellAvailable(int x, int y) const {
    return x >= 0 && x < width && y >= 0 && y < height &&
        grid[y][x] == '.';
}

void Map::placeUnit(int x, int y, char symbol) {
    if (isCellAvailable(x, y)) {
        grid[y][x] = symbol;
    }
}

void Map::clearUnit(int x, int y) {
    if (x >= 0 && x < width && y >= 0 && y < height) {
        grid[y][x] = '.';
    }
}

void Map::updateMap(const std::vector<std::shared_ptr<Unit>>& units, char symbol) {
    for (int i = 0; i < height; ++i) {
        for (int j = 0; j < width; ++j) {
            if (grid[i][j] == symbol) {
                grid[i][j] = '.';
            }
        }
    }
    for (const auto& unit : units) {
        grid[unit->getY()][unit->getX()] = symbol;
    }
}