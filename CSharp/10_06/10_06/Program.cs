using System;

class Program {
    static void Main() {
        Console.WriteLine("Добро пожаловать в подземелье!");
        Console.ForegroundColor = ConsoleColor.White;

        Player player = SaveManager.Load();
        if (player == null) {
            Console.Write("Введите имя героя: ");
            string name = Console.ReadLine();
            player = new Player { Name = name };
        }

        while (true) {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Имя: {player.Name} | Уровень: {player.Level} | Здоровье: {player.Health} | Золото: {player.Gold}");
            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. Исследовать");
            Console.WriteLine("2. Открыть инвентарь");
            Console.WriteLine("3. Использовать зелье здоровья");
            Console.WriteLine("0. Сохранить и выйти");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("> ");
            Console.ResetColor();

            string choice = Console.ReadLine();

            switch (choice) {
                case "1":
                    Console.WriteLine("");
                    GameLogic.Explore(player);
                    break;
                case "2":
                    Console.WriteLine("");
                    player.ShowInventory();
                    break;
                case "3":
                    Console.WriteLine("");
                    player.HealWithPotion();
                    break;
                case "0":
                    Console.WriteLine("");
                    SaveManager.Save(player);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Игра сохранена. До новых встреч!");
                    Console.ResetColor();
                    return;
                default:
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный выбор.");
                    Console.ResetColor();
                    break;
            }

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}