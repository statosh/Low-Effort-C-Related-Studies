#ifndef MAP_H
#define MAP_H

#include <vector>
#include <iostream>
#include <memory>
#include "Unit.h"

class Map {
private:
    std::vector<std::vector<char>> grid;
    int width, height;
public:
    Map(int w, int h);
    void generateRandomMap();
    void display() const;
    bool isCellAvailable(int x, int y) const;
    void placeUnit(int x, int y, char symbol);
    void clearUnit(int x, int y);
    void updateMap(const std::vector<std::shared_ptr<Unit>>& units, char symbol);
    int getWidth() const { return width; }
    int getHeight() const { return height; }
};

#endif // MAP_H