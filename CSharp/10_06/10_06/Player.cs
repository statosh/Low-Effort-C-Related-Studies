using System;
using System.Collections.Generic;

[Serializable]
public class Player {
    public string Name { get; set; }
    public int Level { get; set; } = 1;
    public int Health { get; set; } = 100;
    public int Gold { get; set; } = 0;
    public List<string> Inventory { get; set; } = new List<string>();

    public int Attack() {
        Random rand = new Random();
        return rand.Next(10, 21);
    }

    public void TakeDamage(int damage) {
        Health -= damage;
        if (Health < 0) Health = 0;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Вы получили {damage} урона. Осталось здоровья: {Health}");
        Console.ResetColor();
    }

    public void HealWithPotion() {
        if (Inventory.Contains("Зелье здоровья")) {
            int healAmount = 30;
            Health = Math.Min(Health + healAmount, 100);
            Inventory.Remove("Зелье здоровья");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Вы использовали зелье и восстановили {healAmount} здоровья.");
            Console.ResetColor();
        } else {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("У вас нет зелья здоровья.");
            Console.ResetColor();
        }
    }

    public void ShowInventory() {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Ваш инвентарь:");
        Console.ResetColor();
        Console.WriteLine($"Золото: {Gold} монет");
        if (Inventory.Count > 0) {
            foreach (string item in Inventory) {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("- " + item);
                Console.ResetColor();
            }
        } else {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Инвентарь пуст.");
            Console.ResetColor();
        }
    }
}