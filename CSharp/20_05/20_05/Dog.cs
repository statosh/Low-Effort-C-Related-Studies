using System;

public class Dog : IAnimal, IRunnable {
    private string name;

    public Dog(string name) {
        this.name = name;
    }

    public string GetName() {
        return name;
    }

    public void MakeSound() {
        Console.WriteLine("Гав!");
    }

    public void Run() {
        StartRunning();
    }

    public void StartRunning() {
        Console.WriteLine("Собака начинает бегать.");
    }
}