using System;

public class Bird : IAnimal, IFlyable {
    private string name;

    public Bird(string name) {
        this.name = name;
    }

    public string GetName() {
        return name;
    }

    public void MakeSound() {
        Console.WriteLine("Чирик-чирик!");
    }

    public void Fly() {
        Console.WriteLine("Птица летит.");
    }
}