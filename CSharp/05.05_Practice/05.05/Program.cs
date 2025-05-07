using System;

class Program {

    static void Task4() {
        Console.Write("Введите начало диапазона: ");
        int start = int.Parse(Console.ReadLine());

        Console.Write("Введите конец диапазона: ");
        int end = int.Parse(Console.ReadLine());

        int a = 0;
        int b = 1;

        Console.WriteLine($"Числа Фибоначчи в диапазоне от {start} до {end}: ");

        while (a <= end) {
            if (a >= start) {
                Console.Write(a + " ");
            }

            int temp = a + b;
            a = b;
            b = temp;
        }

        Console.WriteLine();
    }

    static void Task5() {
        Console.Write("Введите число A: ");
        int A = int.Parse(Console.ReadLine());

        Console.Write("Введите число B: ");
        int B = int.Parse(Console.ReadLine());

        for (int i = A; i <= B; i++) {
            for (int j = 0; j < i; j++) {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }

    static void Task6() {
        Console.Write("Введите длину линии: ");
        int length = int.Parse(Console.ReadLine());

        Console.Write("Введите символ заполнения: ");
        char symbol = Console.ReadKey().KeyChar;
        Console.WriteLine();

        Console.WriteLine("Выберите направление линии:");
        Console.WriteLine("1 - Горизонтальная");
        Console.WriteLine("2 - Вертикальная");
        int direction = int.Parse(Console.ReadLine());

        if (direction == 1) {
            for (int i = 0; i < length; i++) {
                Console.Write(symbol);
            }
            Console.WriteLine();
        } else if (direction == 2) {
            for (int i = 0; i < length; i++) {
                Console.WriteLine(symbol);
            }
        } else {
            Console.WriteLine("Неверное направление!");
        }
    }

    static void Main() {
        int choice;
        do {
            Console.WriteLine("1. Числа Фибоначчи в диапазоне (Задание 4)");
            Console.WriteLine("2. Вывод чисел A-B с повторением (Задание 5)");
            Console.WriteLine("3. Отображение линии (Задание 6)");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите задание: ");

            while (!int.TryParse(Console.ReadLine(), out choice)) {
                Console.Write("Некорректный ввод. Повторите: ");
            }

            switch (choice) {
                case 1:
                    Task4();
                    break;
                case 2:
                    Task5();
                    break;
                case 3:
                    Task6();
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