using System;
using System.Threading;

class GameLogic {
    private static Random rand = new Random();

    public static void Explore(Player player) {
        int eventNumber = rand.Next(1, 4);

        switch (eventNumber) {
            case 1:
                int goldFound = rand.Next(5, 21);
                player.Gold += goldFound;
                Console.WriteLine($"Вы нашли {goldFound} золотых монет!");
                break;

            case 2:
                Console.WriteLine("Вы встретили монстра!");
                Fight(player);
                break;

            case 3:
                string item = "Зелье здоровья";
                player.Inventory.Add(item);
                Console.WriteLine($"Вы нашли предмет: {item}!");
                break;
        }
    }

    private static void Fight(Player player) {
        int monsterHealth = 50;
        Console.WriteLine("Бой начался!");

        while (player.Health > 0 && monsterHealth > 0) {
            int playerDmg = player.Attack();
            monsterHealth -= playerDmg;
            Console.WriteLine($"Вы ударили монстра и нанесли {playerDmg} урона. У монстра осталось {monsterHealth} здоровья.");

            if (monsterHealth <= 0) {
                Console.WriteLine("Вы победили монстра!");
                player.Level++;
                player.Gold += 20;
                Console.WriteLine("Вы получили 20 золота и повысили уровень!");
                return;
            }

            int monsterDmg = 15;
            player.TakeDamage(monsterDmg);

            if (player.Health <= 0) {
                Console.WriteLine("Вы были побеждены...");
                Environment.Exit(0);
            }

            Thread.Sleep(800);
        }
    }
}