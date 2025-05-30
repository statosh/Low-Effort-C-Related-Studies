using System;
using System.Collections.Generic;

public class Person {
    public string Name { get; set; }
    public int Age { get; set; }
    public override string ToString() => $"Имя: {Name}, Возраст: {Age}";
}

public interface IIdentifiable {
    int GetId();
}

public class User : IIdentifiable {
    public int Id { get; set; }
    public string Name { get; set; }
    public int GetId() => Id;
}

public class Repository<T> where T : IIdentifiable {
    private List<T> items = new List<T>();
    public void Add(T item) => items.Add(item);
    public T GetById(int id) => items.Find(item => item.GetId() == id);
}

public class MyCollection<T> {
    private T[] _items;
    private int _count;

    public MyCollection(int capacity) {
        _items = new T[capacity];
        _count = 0;
    }

    public void Add(T item) {
        if (_count < _items.Length) {
            _items[_count++] = item;
        } else {
            Console.WriteLine("Коллекция заполнена.");
        }
    }

    public T Get(int index) {
        if (index >= 0 && index < _count)
            return _items[index];
        throw new IndexOutOfRangeException("Неверный индекс.");
    }

    public void Remove(int index) {
        if (index < 0 || index >= _count) return;
        for (int i = index; i < _count - 1; i++)
            _items[i] = _items[i + 1];
        _count--;
    }
}

public delegate TOutput Transformer<TInput, TOutput>(TInput input);

public class Program {
    public static void Swap<T>(ref T a, ref T b) {
        T temp = a;
        a = b;
        b = temp;
    }

    public static TOutput[] TransformArray<TInput, TOutput>(TInput[] array, Transformer<TInput, TOutput> transformer) {
        TOutput[] result = new TOutput[array.Length];
        for (int i = 0; i < array.Length; i++)
            result[i] = transformer(array[i]);
        return result;
    }

    static void Main() {
        while (true) {
            Console.WriteLine("1. Swap<T>: Обмен значениями");
            Console.WriteLine("2. Обобщённая коллекция MyCollection<T>");
            Console.WriteLine("3. Ограничения обобщений и Repository<T>");
            Console.WriteLine("4. Преобразование массива с помощью делегата");
            Console.WriteLine("0. Выход");
            Console.WriteLine("Выберите задание: ");
            Console.Write("> ");
            string choice = Console.ReadLine();

            switch (choice) {
                case "1": DemoSwap(); break;
                case "2": DemoCollection(); break;
                case "3": DemoRepository(); break;
                case "4": DemoTransform(); break;
                case "0": return;
                default: Console.WriteLine("Неверный ввод.\n"); break;
            }
        }
    }

    static void DemoSwap() {
        Console.WriteLine("\nОбмен значениями (Swap<T>)");
        Console.WriteLine("1. int");
        Console.WriteLine("2. string");
        Console.WriteLine("3. Person");
        Console.Write("> ");
        string typeChoice = Console.ReadLine();

        switch (typeChoice) {
            case "1":
                int a, b;
                Console.Write("Введите первое число: ");
                while (!int.TryParse(Console.ReadLine(), out a)) Console.Write("Неверный ввод. Введите число: ");
                Console.Write("Введите второе число: ");
                while (!int.TryParse(Console.ReadLine(), out b)) Console.Write("Неверный ввод. Введите число: ");
                Swap(ref a, ref b);
                Console.WriteLine($"После обмена: a = {a}, b = {b}\n");
                break;
            case "2":
                Console.Write("Введите первую строку: ");
                string s1 = Console.ReadLine();
                Console.Write("Введите вторую строку: ");
                string s2 = Console.ReadLine();
                Swap(ref s1, ref s2);
                Console.WriteLine($"После обмена: s1 = {s1}, s2 = {s2}\n");
                break;
            case "3":
                Console.Write("Введите имя первого человека: ");
                string name1 = Console.ReadLine();
                Console.Write("Введите возраст: ");
                int age1;
                while (!int.TryParse(Console.ReadLine(), out age1)) Console.Write("Неверный ввод. Введите возраст: ");
                var p1 = new Person { Name = name1, Age = age1 };

                Console.Write("Введите имя второго человека: ");
                string name2 = Console.ReadLine();
                Console.Write("Введите возраст: ");
                int age2;
                while (!int.TryParse(Console.ReadLine(), out age2)) Console.Write("Неверный ввод. Введите возраст: ");
                var p2 = new Person { Name = name2, Age = age2 };

                Swap(ref p1, ref p2);
                Console.WriteLine("После обмена:");
                Console.WriteLine($"Первый: {p1}");
                Console.WriteLine($"Второй: {p2}\n");
                break;
            default:
                Console.WriteLine("Неверный выбор.\n");
                break;
        }
    }

    static void DemoCollection() {
        Console.WriteLine("\nРабота с обобщенной коллекцией");
        Console.Write("Введите размер коллекции: ");
        int size;
        while (!int.TryParse(Console.ReadLine(), out size) || size <= 0) Console.Write("Введите положительное число: ");

        Console.WriteLine("1. int");
        Console.WriteLine("2. string");
        Console.Write("> ");
        string typeChoice = Console.ReadLine();

        if (typeChoice == "1") {
            var collection = new MyCollection<int>(size);
            while (true) {
                Console.WriteLine("1. Добавить");
                Console.WriteLine("2. Получить");
                Console.WriteLine("3. Удалить");
                Console.WriteLine("0. Назад");
                Console.Write("> ");
                string act = Console.ReadLine();
                if (act == "0") break;

                switch (act) {
                    case "1":
                        Console.Write("Введите число: ");
                        if (int.TryParse(Console.ReadLine(), out int item))
                            collection.Add(item);
                        else Console.WriteLine("Неверный ввод.");
                        break;
                    case "2":
                        Console.Write("Индекс: ");
                        if (int.TryParse(Console.ReadLine(), out int idx))
                            Console.WriteLine($"Элемент: {collection.Get(idx)}");
                        else Console.WriteLine("Неверный индекс.");
                        break;
                    case "3":
                        Console.Write("Индекс: ");
                        if (int.TryParse(Console.ReadLine(), out int rmIdx))
                            collection.Remove(rmIdx);
                        else Console.WriteLine("Неверный индекс.");
                        break;
                    default: Console.WriteLine("Неверный ввод."); break;
                }
            }
        } else if (typeChoice == "2") {
            var collection = new MyCollection<string>(size);
            while (true) {
                Console.WriteLine("1. Добавить");
                Console.WriteLine("2. Получить");
                Console.WriteLine("3. Удалить");
                Console.WriteLine("0. Назад");
                Console.Write("> ");
                string act = Console.ReadLine();
                if (act == "0") break;

                switch (act) {
                    case "1":
                        Console.Write("Введите строку: ");
                        collection.Add(Console.ReadLine());
                        break;
                    case "2":
                        Console.Write("Индекс: ");
                        if (int.TryParse(Console.ReadLine(), out int idx))
                            Console.WriteLine($"Элемент: {collection.Get(idx)}");
                        else Console.WriteLine("Неверный индекс.");
                        break;
                    case "3":
                        Console.Write("Индекс: ");
                        if (int.TryParse(Console.ReadLine(), out int rmIdx))
                            collection.Remove(rmIdx);
                        else Console.WriteLine("Неверный индекс.");
                        break;
                    default: Console.WriteLine("Неверный ввод."); break;
                }
            }
        } else {
            Console.WriteLine("Неверный выбор.\n");
        }
    }

    static void DemoRepository() {
        var repo = new Repository<User>();
        Console.WriteLine("\nРабота с Repository<User>");

        while (true) {
            Console.WriteLine("1. Добавить пользователя");
            Console.WriteLine("2. Найти по ID");
            Console.WriteLine("0. Назад");
            Console.Write("> ");
            string act = Console.ReadLine();

            if (act == "0") break;

            switch (act) {
                case "1":
                    Console.Write("ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int id)) {
                        Console.WriteLine("Неверный ID.");
                        break;
                    }
                    Console.Write("Имя: ");
                    string name = Console.ReadLine();
                    repo.Add(new User { Id = id, Name = name });
                    break;
                case "2":
                    Console.Write("Введите ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int searchId)) {
                        Console.WriteLine("Неверный ID.");
                        break;
                    }
                    var user = repo.GetById(searchId);
                    Console.WriteLine(user != null ? $"Найден: {user.Name}" : "Пользователь не найден.");
                    break;
                default:
                    Console.WriteLine("Неверный ввод.");
                    break;
            }
        }
    }

    static void DemoTransform() {
        Console.WriteLine("\nПреобразование int[] в string[]");
        Console.Write("Введите числа через пробел: ");
        string[] parts = Console.ReadLine().Split();
        int[] nums = new int[parts.Length];
        for (int i = 0; i < parts.Length; i++) {
            if (!int.TryParse(parts[i], out nums[i])) {
                Console.WriteLine("Ошибка ввода. Преобразование прервано.");
                return;
            }
        }

        string[] results = TransformArray(nums, x => x.ToString());
        Console.WriteLine("Результат: " + string.Join(", ", results) + "\n");
    }
}
