#ifndef UNIT_H
#define UNIT_H

class Unit {
private:
    int x, y;
public:
    Unit(int x, int y) : x(x), y(y) {}
    int getX() const { return x; }
    int getY() const { return y; }
    void setX(int newX) { x = newX; }
    void setY(int newY) { y = newY; }
};

#endif // UNIT_H