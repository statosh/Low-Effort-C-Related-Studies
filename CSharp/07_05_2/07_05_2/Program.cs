using System;

class Program {

    // Задание 1: Метод отображает квадрат из символа
    static void DrawSquare(int size, char symbol) {
        for (int i = 0; i < size; i++) {
            for (int j = 0; j < size; j++) {
                Console.Write(symbol + " ");
            }
            Console.WriteLine();
        }
    }

    // Задание 2: Проверка, является ли число палиндромом
    static bool IsPalindrome(int number) {
        int original = number;
        int reversed = 0;

        while (number > 0) {
            int digit = number % 10;
            reversed = reversed * 10 + digit;
            number /= 10;
        }

        return original == reversed;
    }

    // Задание 3: Фильтрация массива по второму массиву
    static int[] FilterArray(int[] source, int[] exclude) {
        int count = 0;
        foreach (int s in source) {
            bool found = false;
            foreach (int e in exclude) {
                if (s == e) {
                    found = true;
                    break;
                }
            }
            if (!found) {
                count++;
            }
        }

        int[] result = new int[count];
        int index = 0;

        foreach (int s in source) {
            bool found = false;
            foreach (int e in exclude) {
                if (s == e) {
                    found = true;
                    break;
                }
            }
            if (!found) {
                result[index++] = s;
            }
        }

        return result;
    }

    // Задание 4: Класс "Веб-сайт"
    class WebSite {
        private string name;
        private string url;
        private string description;
        private string ip;

        public void Input() {
            Console.Write("Название сайта: ");
            name = Console.ReadLine();

            Console.Write("URL сайта: ");
            url = Console.ReadLine();

            Console.Write("Описание сайта: ");
            description = Console.ReadLine();

            Console.Write("IP адрес сайта: ");
            ip = Console.ReadLine();
        }

        public void Output() {
            Console.WriteLine($"Сайт: {name}");
            Console.WriteLine($"URL: {url}");
            Console.WriteLine($"Описание: {description}");
            Console.WriteLine($"IP: {ip}");
        }

        public string GetName() => name;
        public string GetUrl() => url;
    }
    // Задание 5: Класс "Журнал"
    class Magazine {
        private string title;
        private int yearFounded;
        private string description;
        private string phone;
        private string email;

        public void Input() {
            Console.Write("Название журнала: ");
            title = Console.ReadLine();

            Console.Write("Год основания: ");
            yearFounded = int.Parse(Console.ReadLine());

            Console.Write("Описание журнала: ");
            description = Console.ReadLine();

            Console.Write("Телефон: ");
            phone = Console.ReadLine();

            Console.Write("Email: ");
            email = Console.ReadLine();
        }

        public void Output() {
            Console.WriteLine($"Название: {title}");
            Console.WriteLine($"Год основания: {yearFounded}");
            Console.WriteLine($"Описание: {description}");
            Console.WriteLine($"Телефон: {phone}");
            Console.WriteLine($"Email: {email}");
        }
    }

    // Задание 6: Класс "Магазин"
    class Store {
        private string name;
        private string address;
        private string description;
        private string phone;
        private string email;

        public void Input() {
            Console.Write("Название магазина: ");
            name = Console.ReadLine();

            Console.Write("Адрес: ");
            address = Console.ReadLine();

            Console.Write("Описание: ");
            description = Console.ReadLine();

            Console.Write("Телефон: ");
            phone = Console.ReadLine();

            Console.Write("Email: ");
            email = Console.ReadLine();
        }

        public void Output() {
            Console.WriteLine($"Название: {name}");
            Console.WriteLine($"Адрес: {address}");
            Console.WriteLine($"Описание: {description}");
            Console.WriteLine($"Телефон: {phone}");
            Console.WriteLine($"Email: {email}");
        }
    }

    static void Task1() {
        Console.Write("Введите размер стороны квадрата: ");
        int size = int.Parse(Console.ReadLine());

        Console.Write("Введите символ: ");
        char symbol = Console.ReadKey().KeyChar;
        Console.WriteLine();

        DrawSquare(size, symbol);
    }

    static void Task2() {
        Console.Write("Введите число для проверки на палиндром: ");
        int num = int.Parse(Console.ReadLine());

        Console.WriteLine(IsPalindrome(num) ? "Это палиндром" : "Не палиндром");
    }

    static void Task3() {
        Console.Write("Введите размер оригинального массива: ");
        int sizeSource = int.Parse(Console.ReadLine());

        int[] source = new int[sizeSource];
        Console.WriteLine("Введите элементы оригинального массива:");
        for (int i = 0; i < sizeSource; i++) {
            Console.Write($"Элемент {i}: ");
            source[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Введите размер массива для фильтрации: ");
        int sizeExclude = int.Parse(Console.ReadLine());

        int[] exclude = new int[sizeExclude];
        Console.WriteLine("Введите элементы массива для фильтрации:");
        for (int i = 0; i < sizeExclude; i++) {
            Console.Write($"Элемент {i}: ");
            exclude[i] = int.Parse(Console.ReadLine());
        }

        int[] result = FilterArray(source, exclude);

        Console.WriteLine("Результат после фильтрации:");
        foreach (int x in result) {
            Console.Write(x + " ");
        }
        Console.WriteLine();
    }

    static void Task4() {
        WebSite site = new WebSite();
        site.Input();
        site.Output();
    }

    static void Task5() {
        Magazine mag = new Magazine();
        mag.Input();
        mag.Output();
    }

    static void Task6() {
        Store store = new Store();
        store.Input();
        store.Output();
    }

    static void Main() {
        int choice;
        do {
            Console.WriteLine("1. Нарисовать квадрат из символа");
            Console.WriteLine("2. Проверить, является ли число палиндромом");
            Console.WriteLine("3. Отфильтровать массив");
            Console.WriteLine("4. Класс \"Веб-сайт\"");
            Console.WriteLine("5. Класс \"Журнал\"");
            Console.WriteLine("6. Класс \"Магазин\"");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите задание: ");

            while (!int.TryParse(Console.ReadLine(), out choice)) {
                Console.Write("Некорректный ввод. Повторите: ");
            }

            switch (choice) {
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    Task3();
                    break;
                case 4:
                    Task4();
                    break;
                case 5:
                    Task5();
                    break;
                case 6:
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