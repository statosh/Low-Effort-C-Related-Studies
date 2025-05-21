using System;

public class Robot : IMovable1, IMovable2 {
    public void Move() {
        Console.WriteLine("Робот движется (IMovable1).");
    }

    void IMovable2.Move() {
        Console.WriteLine("Робот движется (IMovable2).");
    }
}