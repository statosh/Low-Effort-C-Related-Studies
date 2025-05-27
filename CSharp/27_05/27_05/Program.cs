using System;
using System.Collections.Generic;

delegate double MathOperation(double x, double y);

class Product : EventArgs {
    public string Name { get; set; }
    public double Price { get; set; }

    public Product(string name, double price) {
        Name = name;
        Price = price;
    }
}

class Store {
    public event EventHandler<Product> ProductAdded;

    public void AddProduct(Product product) {
        ProductAdded?.Invoke(this, product);
    }
}

class Customer {
    public string Name { get; }

    public Customer(string name) {
        Name = name;
    }

    public void OnProductAdded(object sender, Product product) {
        Console.WriteLine($"Уведомление для {Name}: добавлен товар \"{product.Name}\" по цене {product.Price}р.");
    }
}

class Program {
    static Dictionary<string, MathOperation> operations = new Dictionary<string, MathOperation>() {
        { "+", (x, y) => x + y },
        { "-", (x, y) => x - y },
        { "*", (x, y) => x * y },
        { "/", (x, y) => {
            if (y == 0) throw new DivideByZeroException("Деление на ноль невозможно.");
            return x / y;
        }},
        { "^", (x, y) => Math.Pow(x, y) }
    };

    static void RunCalculator() {
        try {
            Console.WriteLine("Введите первое число:");
            Console.Write("> ");
            double a = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите второе число:");
            Console.Write("> ");
            double b = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите операцию (+, -, *, /, ^):");
            Console.Write("> ");
            string op = Console.ReadLine();

            if (!operations.ContainsKey(op)) {
                Console.WriteLine("Неизвестная операция.");
                return;
            }

            double result = operations[op](a, b);
            Console.WriteLine($"Результат: {result}");
        } catch (DivideByZeroException ex) {
            Console.WriteLine($"Ошибка: {ex.Message}");
        } catch (FormatException) {
            Console.WriteLine("Ошибка: Введите корректные числа.");
        } catch (Exception ex) {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    static void RunStoreDemo() {
        Store store = new Store();

        Customer c1 = new Customer("Клиент 1");
        Customer c2 = new Customer("Клиент 2");
        Customer c3 = new Customer("Клиент 3");

        store.ProductAdded += c1.OnProductAdded;
        store.ProductAdded += c2.OnProductAdded;
        store.ProductAdded += c3.OnProductAdded;

        while (true) {
            Console.WriteLine("\nДобавить товар? (да/нет)");
            Console.Write("> ");
            string answer = Console.ReadLine().ToLower();

            if (answer != "да") break;

            Console.WriteLine("Введите название товара:");
            Console.Write("> ");
            string name = Console.ReadLine();

            Console.WriteLine("Введите цену товара:");
            Console.Write("> ");
            if (!double.TryParse(Console.ReadLine(), out double price)) {
                Console.WriteLine("Ошибка: Введите корректную цену.");
                continue;
            }

            store.AddProduct(new Product(name, price));
        }
    }

    static void Main() {
        while (true) {
            Console.WriteLine("\n1. Калькулятор с делегатами");
            Console.WriteLine("2. Система уведомлений (события)");
            Console.WriteLine("0. Выход");
            Console.WriteLine("Выберите задание: ");
            Console.Write("> ");

            string choice = Console.ReadLine();

            switch (choice) {
                case "1":
                    RunCalculator();
                    break;
                case "2":
                    RunStoreDemo();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Повторите попытку.");
                    break;
            }
        }
    }
}
