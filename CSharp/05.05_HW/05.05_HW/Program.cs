using System;

class Program {

    static void Task5() {
        Console.Write("Введите дату в формате ДД.ММ.ГГГГ: ");
        string input = Console.ReadLine();

        if (DateTime.TryParse(input, out DateTime date)) {
            string season;
            int month = date.Month;

            switch (month) {
                case 12:
                case 1:
                case 2:
                    season = "Winter";
                    break;
                case 3:
                case 4:
                case 5:
                    season = "Spring";
                    break;
                case 6:
                case 7:
                case 8:
                    season = "Summer";
                    break;
                default:
                    season = "Autumn";
                    break;
            }

            string dayOfWeek = date.DayOfWeek.ToString();
            Console.WriteLine($"{season} {dayOfWeek}");
        } else {
            Console.WriteLine("Некорректная дата!");
        }
    }

    static void Task6() {
        Console.WriteLine("Выберите направление перевода:");
        Console.WriteLine("1 - Цельсий в Фаренгейт");
        Console.WriteLine("2 - Фаренгейт в Цельсий");
        Console.Write("Ваш выбор: ");

        int choice = int.Parse(Console.ReadLine());

        Console.Write("Введите температуру: ");
        double temp = double.Parse(Console.ReadLine());

        if (choice == 1) {
            double result = temp * 9 / 5 + 32;
            Console.WriteLine($"{temp}°C = {result:F2}°F");
        } else if (choice == 2) {
            double result = (temp - 32) * 5 / 9;
            Console.WriteLine($"{temp}°F = {result:F2}°C");
        } else {
            Console.WriteLine("Неверный выбор.");
        }
    }

    static void Task7() {
        Console.Write("Введите первое число: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Введите второе число: ");
        int b = int.Parse(Console.ReadLine());

        int start = Math.Min(a, b);
        int end = Math.Max(a, b);

        Console.WriteLine($"Четные числа в диапазоне от {start} до {end}:");
        for (int i = start; i <= end; i++) {
            if (i % 2 == 0) {
                Console.Write(i + " ");
            }
        }
        Console.WriteLine();
    }

    static void Main() {
        int choice;
        do {
            Console.WriteLine("1. Определение сезона и дня недели (Задание 5)");
            Console.WriteLine("2. Перевод температуры (Задание 6)");
            Console.WriteLine("3. Четные числа в диапазоне (Задание 7)");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите задание: ");

            while (!int.TryParse(Console.ReadLine(), out choice)) {
                Console.Write("Некорректный ввод. Повторите: ");
            }

            switch (choice) {
                case 1:
                    Task5();
                    break;
                case 2:
                    Task6();
                    break;
                case 3:
                    Task7();
                    break;
                case 0:
                    Console.WriteLine("Выход из программы.");
                    break;
                default:
                    Console.WriteLine("Такого пункта нет.");
                    break;
            }

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.Clear();

        } while (choice != 0);
    }
}