using System;

class Program {
    static void Main() {
        Console.WriteLine("Задание 1:");
        IAnimal dog = new Dog("Барбос");
        AnimalWrapper wrapper = new AnimalWrapper(dog);

        Console.WriteLine("Имя: " + wrapper.GetName());
        wrapper.MakeSound();
        Console.WriteLine();

        Console.WriteLine("Задание 2:");
        IAnimal bird = new Bird("Синичка");

        if (bird is IFlyable) {
            Console.WriteLine("Это летающее животное.");
        } else {
            Console.WriteLine("Это животное не умеет летать.");
        }

        IFlyable flyableBird = bird as IFlyable;
        if (flyableBird != null) {
            flyableBird.Fly();
        } else {
            Console.WriteLine("Это животное не умеет летать.");
        }

        IFlyable explicitFlyableBird = (IFlyable)bird;
        explicitFlyableBird.Fly();
        Console.WriteLine();

        Console.WriteLine("Задание 3:");
        Robot robot = new Robot();

        robot.Move();

        ((IMovable2)robot).Move();
        Console.WriteLine();

        Console.WriteLine("Задание 4:");
        IRunnable runnableDog = new Dog("Рекс");
        runnableDog.Run();
        Console.WriteLine();

        Console.WriteLine("Задание 5:");
        IUserService userService = new UserService();

        Console.WriteLine(userService.GetUserInfo(1));

        Console.WriteLine(userService.GetUserInfo(2, "дополнительная информация"));
        Console.WriteLine();
    }
}