using System;
using System.Collections.Generic;

class Program {

    // === Задание 1: Класс Magazine (Журнал) ===
    class Magazine {
        private string title;
        private string country;
        private int staffCount;
        private string contactPhone;
        private string email;

        public string Title {
            get => title;
            set => title = value;
        }
        public string Country {
            get => country;
            set => country = value;
        }
        public int StaffCount {
            get => staffCount;
            set => staffCount = value;
        }
        public string ContactPhone {
            get => contactPhone;
            set => contactPhone = value;
        }
        public string Email {
            get => email;
            set => email = value;
        }

        public Magazine(string title, string country, int staffCount, string phone, string email) {
            Title = title;
            Country = country;
            StaffCount = staffCount;
            ContactPhone = phone;
            Email = email;
        }

        public static Magazine operator +(Magazine m, int add) {
            m.staffCount += add;
            return m;
        }

        public static Magazine operator -(Magazine m, int sub) {
            if (m.staffCount - sub < 0)
                throw new InvalidOperationException("Количество сотрудников не может быть отрицательным.");
            m.staffCount -= sub;
            return m;
        }

        public static bool operator ==(Magazine a, Magazine b) {
            return a.staffCount == b.staffCount;
        }

        public static bool operator !=(Magazine a, Magazine b) {
            return a.staffCount != b.staffCount;
        }

        public static bool operator >(Magazine a, Magazine b) {
            return a.staffCount > b.staffCount;
        }

        public static bool operator <(Magazine a, Magazine b) {
            return a.staffCount < b.staffCount;
        }

        public override bool Equals(object obj) {
            if (!(obj is Magazine)) return false;
            return ((Magazine)obj).staffCount == this.staffCount;
        }

        public override int GetHashCode() {
            return staffCount.GetHashCode();
        }

        public override string ToString() {
            return $"\"{Title}\", Сотрудников: {StaffCount}";
        }
    }

    // === Задание 2: Класс Shop (Магазин) ===
    class Shop {
        private string name;
        private string address;
        private string profile;
        private string phone;
        private string email;
        private decimal area;

        public string Name {
            get => name;
            set => name = value;
        }
        public string Address {
            get => address;
            set => address = value;
        }
        public string Profile {
            get => profile;
            set => profile = value;
        }
        public string Phone {
            get => phone;
            set => phone = value;
        }
        public string Email {
            get => email;
            set => email = value;
        }
        public decimal Area {
            get => area;
            set => area = value;
        }

        public Shop(string name, string address, string profile, string phone, string email, decimal area) {
            Name = name;
            Address = address;
            Profile = profile;
            Phone = phone;
            Email = email;
            Area = area;
        }

        public static Shop operator +(Shop s, decimal add) {
            s.area += add;
            return s;
        }

        public static Shop operator -(Shop s, decimal sub) {
            if (s.area - sub < 0)
                throw new InvalidOperationException("Площадь не может быть отрицательной.");
            s.area -= sub;
            return s;
        }

        public static bool operator ==(Shop a, Shop b) {
            return a.area == b.area;
        }

        public static bool operator !=(Shop a, Shop b) {
            return a.area != b.area;
        }

        public static bool operator >(Shop a, Shop b) {
            return a.area > b.area;
        }

        public static bool operator <(Shop a, Shop b) {
            return a.area < b.area;
        }

        public override bool Equals(object obj) {
            if (!(obj is Shop)) return false;
            return ((Shop)obj).area == this.area;
        }

        public override int GetHashCode() {
            return Area.GetHashCode();
        }

        public override string ToString() {
            return $"{Name}, Площадь: {Area} м²";
        }
    }

    // === Задание 3: Приложение «Список книг для прочтения» ===
    class Book {
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(string title, string author) {
            Title = title;
            Author = author;
        }

        public override string ToString() {
            return $"{Author} — {Title}";
        }

        public override bool Equals(object obj) {
            if (!(obj is Book)) return false;
            var other = (Book)obj;
            return Title == other.Title && Author == other.Author;
        }

        public override int GetHashCode() {
            unchecked {
                return Title?.GetHashCode() * 13 + Author?.GetHashCode() ?? 0;
            }
        }
    }

    class ReadingList {
        private List<Book> books = new List<Book>();

        public int Count => books.Count;

        public Book this[int index] {
            get {
                if (index >= 0 && index < books.Count)
                    return books[index];
                else
                    throw new IndexOutOfRangeException();
            }
        }

        public void Add(Book book) {
            if (!books.Contains(book))
                books.Add(book);
        }

        public void Remove(Book book) {
            books.Remove(book);
        }

        public bool Contains(Book book) {
            return books.Contains(book);
        }

        public static ReadingList operator +(ReadingList list, Book book) {
            list.Add(book);
            return list;
        }

        public static ReadingList operator -(ReadingList list, Book book) {
            list.Remove(book);
            return list;
        }

        public void Print() {
            if (books.Count == 0) {
                Console.WriteLine("Список пуст.");
                return;
            }

            for (int i = 0; i < books.Count; i++) {
                Console.WriteLine($"{i + 1}. {books[i]}");
            }
        }
    }

    // === Main и меню ===
    static void Main() {
        List<Magazine> magazines = new List<Magazine>() {
            new Magazine("Наука и Жизнь", "Россия", 50, "+7 999 888 7766", "mag@example.com"),
            new Magazine("Тема", "Украина", 20, "+380 99 88 77", "tema@ukr.net")
        };

        List<Shop> shops = new List<Shop>() {
            new Shop("Книжный Ряд", "ул. Литературы д. 5", "Книги", "+7 495 123-45-67", "shop@example.com", 150),
            new Shop("Мини-магазин", "ул. Короткая д. 3", "Малая литература", "+7 495 987-65-43", "mini@example.com", 80)
        };

        ReadingList readingList = new ReadingList();

        while (true) {
            Console.WriteLine();
            Console.WriteLine("1. Тестировать класс Magazine");
            Console.WriteLine("2. Тестировать класс Shop");
            Console.WriteLine("3. Управление списком книг");
            Console.WriteLine("0. Выход");

            Console.Write("Выберите действие: ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice)) {
                Console.Write("Некорректный ввод. Повторите: ");
            }

            switch (choice) {
                case 1:
                    TestMagazine(magazines);
                    break;
                case 2:
                    TestShop(shops);
                    break;
                case 3:
                    TestReadingList(readingList);
                    break;
                case 0:
                    Console.WriteLine("Выход из программы.");
                    return;
                default:
                    Console.WriteLine("Такого пункта нет.");
                    break;
            }

        }
    }

    // === Тестирование Magazine ===
    static void TestMagazine(List<Magazine> magazines) {
        PrintList(magazines, "Журналы", x => x.ToString());

        int a = GetIndex(magazines.Count, "Индекс первого журнала: ");
        int b = GetIndex(magazines.Count, "Индекс второго журнала: ");

        var magA = magazines[a];
        var magB = magazines[b];

        Console.WriteLine("\nДоступные операции:");
        Console.WriteLine("1. Добавить сотрудников к журналу");
        Console.WriteLine("2. Удалить сотрудников у журнала");
        Console.WriteLine("3. Сравнить количество сотрудников (==)");
        Console.WriteLine("4. Сравнить количество сотрудников (!=)");
        Console.WriteLine("5. Сравнить >");
        Console.WriteLine("6. Сравнить <");

        Console.Write("Выберите операцию: ");
        int op;
        while (!int.TryParse(Console.ReadLine(), out op) || op < 1 || op > 6) {
            Console.Write("Неверная операция. Повторите: ");
        }

        Console.Write("Какой объект редактировать? (1 или 2): ");
        int target;
        while (!int.TryParse(Console.ReadLine(), out target) || target < 1 || target > 2) {
            Console.Write("Введите 1 или 2: ");
        }

        var selected = target == 1 ? magA : magB;
        var other = target == 1 ? magB : magA;

        Console.WriteLine("\nВы выбрали: " + selected);

        switch (op) {
            case 1:
                int add = ReadInt("Сколько добавить сотрудников? ", x => x > 0);
                selected += add;
                Console.WriteLine("Новое количество сотрудников: " + selected.StaffCount);
                break;

            case 2:
                int sub = ReadInt("Сколько удалить сотрудников? ", x => x > 0 && x <= selected.StaffCount);
                selected -= sub;
                Console.WriteLine("Новое количество сотрудников: " + selected.StaffCount);
                break;

            case 3:
                Console.WriteLine(selected == other ? "Равное число сотрудников" : "Число отличается");
                break;

            case 4:
                Console.WriteLine(selected != other ? "Число отличается" : "Равное число сотрудников");
                break;

            case 5:
                Console.WriteLine(selected > other ? "Больше сотрудников" : "Не больше");
                break;

            case 6:
                Console.WriteLine(selected < other ? "Меньше сотрудников" : "Не меньше");
                break;
        }
    }

    // === Тестирование Shop ===
    static void TestShop(List<Shop> shops) {
        PrintList(shops, "Магазины", x => x.ToString());

        int a = GetIndex(shops.Count, "Индекс первого магазина: ");
        int b = GetIndex(shops.Count, "Индекс второго магазина: ");

        var shopA = shops[a];
        var shopB = shops[b];

        Console.WriteLine("\nДоступные операции:");
        Console.WriteLine("1. Увеличить площадь магазина");
        Console.WriteLine("2. Уменьшить площадь магазина");
        Console.WriteLine("3. Проверить равенство площадей (==)");
        Console.WriteLine("4. Проверить неравенство (≠)");
        Console.WriteLine("5. Проверить > (площадь)");
        Console.WriteLine("6. Проверить < (площадь)");

        Console.Write("Выберите операцию: ");
        int op;
        while (!int.TryParse(Console.ReadLine(), out op) || op < 1 || op > 6) {
            Console.Write("Неверная операция. Повторите: ");
        }

        Console.Write("Какой объект редактировать? (1 или 2): ");
        int target;
        while (!int.TryParse(Console.ReadLine(), out target) || target < 1 || target > 2) {
            Console.Write("Укажите 1 или 2: ");
        }

        var selected = target == 1 ? shopA : shopB;
        var other = target == 1 ? shopB : shopA;

        Console.WriteLine("\nВы выбрали: " + selected);

        switch (op) {
            case 1:
                decimal add = ReadDecimal("На сколько увеличить площадь? ", x => x > 0);
                selected += add;
                Console.WriteLine("Новая площадь: " + selected.Area);
                break;

            case 2:
                decimal sub = ReadDecimal("На сколько уменьшить? ", x => x > 0 && x <= selected.Area);
                selected -= sub;
                Console.WriteLine("Новая площадь: " + selected.Area);
                break;

            case 3:
                Console.WriteLine(selected == other ? "Площади равны" : "Площади не равны");
                break;

            case 4:
                Console.WriteLine(selected != other ? "Площади не равны" : "Площади равны");
                break;

            case 5:
                Console.WriteLine(selected > other ? "Площадь больше" : "Площадь не больше");
                break;

            case 6:
                Console.WriteLine(selected < other ? "Площадь меньше" : "Площадь не меньше");
                break;
        }
    }

    // === Тестирование ReadingList ===
    static void TestReadingList(ReadingList list) {
        while (true) {
            Console.WriteLine("\n=== Список книг ===");
            list.Print();

            Console.WriteLine("\n1. Добавить книгу");
            Console.WriteLine("2. Удалить книгу");
            Console.WriteLine("3. Искать по индексу");
            Console.WriteLine("4. Проверить наличие книги");
            Console.WriteLine("5. Назад");
            Console.Write("Выберите действие: ");

            int op;
            while (!int.TryParse(Console.ReadLine(), out op) || op < 1 || op > 5) {
                Console.Write("Неверно. Повторите: ");
            }

            if (op == 5) break;

            switch (op) {
                case 1:
                    string title = ReadNonEmpty("Название книги: ");
                    string author = ReadNonEmpty("Автор: ");
                    list += new Book(title, author);
                    Console.WriteLine("Книга добавлена.");
                    break;

                case 2:
                    if (list.Count == 0) {
                        Console.WriteLine("Список пуст.");
                        continue;
                    }
                    int index = GetIndex(list.Count, "Номер книги для удаления: ");
                    list -= list[index];
                    Console.WriteLine("Книга удалена.");
                    break;

                case 3:
                    if (list.Count == 0) {
                        Console.WriteLine("Список пуст.");
                        continue;
                    }
                    int idx = GetIndex(list.Count, "Введите номер книги: ");
                    Console.WriteLine("Книга под номером " + (idx + 1) + ": " + list[idx]);
                    break;

                case 4:
                    string t = ReadNonEmpty("Название книги: ");
                    string a = ReadNonEmpty("Автор: ");
                    Book search = new Book(t, a);
                    Console.WriteLine(list.Contains(search) ? "Книга есть в списке." : "Книги нет.");
                    break;
            }
        }
    }

    // === Вспомогательные методы вывода и ввода ===
    static void PrintList<T>(List<T> list, string title, Func<T, string> toString) {
        Console.WriteLine(title + ":");
        for (int i = 0; i < list.Count; i++) {
            Console.WriteLine($"{i}: {toString(list[i])}");
        }
    }

    static string ReadNonEmpty(string prompt) {
        string input;
        do {
            Console.Write(prompt);
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) {
                Console.WriteLine("Поле не может быть пустым.");
            }
        } while (string.IsNullOrWhiteSpace(input));
        return input;
    }

    static int ReadInt(string prompt, Func<int, bool> isValid) {
        int val;
        do {
            Console.Write(prompt);
        } while (!int.TryParse(Console.ReadLine(), out val) || !isValid(val));
        return val;
    }

    static decimal ReadDecimal(string prompt, Func<decimal, bool> isValid) {
        decimal val;
        do {
            Console.Write(prompt);
        } while (!decimal.TryParse(Console.ReadLine(), out val) || !isValid(val));
        return val;
    }

    static int GetIndex(int max, string prompt) {
        int i;
        do {
            Console.Write(prompt);
        } while (!int.TryParse(Console.ReadLine(), out i) || i < 0 || i >= max);
        return i;
    }
}