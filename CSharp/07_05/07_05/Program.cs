using System;

class Program {

    // Задание 1: Произведение чисел в диапазоне
    static long MultiplyRange(int start, int end) {
        long product = 1;
        for (int i = start; i <= end; i++) {
            product *= i;
        }
        return product;
    }

    // Задание 2: Проверка, является ли число простым
    static bool IsPrime(int number) {
        if (number < 2) return false;
        for (int i = 2; i * i <= number; i++) {
            if (number % i == 0) return false;
        }
        return true;
    }

    // Задание 3: Сортировка массива пузырьком
    static void SortArray(int[] arr, bool ascending) {
        for (int i = 0; i < arr.Length - 1; i++) {
            for (int j = 0; j < arr.Length - i - 1; j++) {
                bool swap = ascending ? arr[j] > arr[j + 1] : arr[j] < arr[j + 1];
                if (swap) {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    // Задание 4: Класс "Город"
    class City {
        private string name;
        private string country;
        private int population;
        private string phoneCode;
        private string[] districts;

        public void Input() {
            Console.Write("Введите название города: ");
            name = Console.ReadLine();

            Console.Write("Введите страну: ");
            country = Console.ReadLine();

            Console.Write("Введите количество жителей: ");
            population = int.Parse(Console.ReadLine());

            Console.Write("Введите телефонный код: ");
            phoneCode = Console.ReadLine();

            Console.Write("Сколько районов? ");
            int count = int.Parse(Console.ReadLine());
            districts = new string[count];
            for (int i = 0; i < count; i++) {
                Console.Write($"Район {i + 1}: ");
                districts[i] = Console.ReadLine();
            }
        }

        public void Output() {
            Console.WriteLine($"Город: {name}, Страна: {country}, Жители: {population}");
            Console.WriteLine("Телефонный код: " + phoneCode);
            Console.WriteLine("Районы:");
            foreach (string d in districts) {
                Console.WriteLine("- " + d);
            }
        }

        public string GetName() => name;
        public void SetName(string value) => name = value;
    }

    // Задание 5: Класс "Сотрудник"
    class Employee {
        private string fullName;
        private string birthDate;
        private string phone;
        private string email;
        private string position;
        private string duties;

        public void Input() {
            Console.Write("ФИО: ");
            fullName = Console.ReadLine();

            Console.Write("Дата рождения: ");
            birthDate = Console.ReadLine();

            Console.Write("Телефон: ");
            phone = Console.ReadLine();

            Console.Write("Email: ");
            email = Console.ReadLine();

            Console.Write("Должность: ");
            position = Console.ReadLine();

            Console.Write("Обязанности: ");
            duties = Console.ReadLine();
        }

        public void Output() {
            Console.WriteLine("ФИО: " + fullName);
            Console.WriteLine("Дата рождения: " + birthDate);
            Console.WriteLine("Телефон: " + phone);
            Console.WriteLine("Email: " + email);
            Console.WriteLine("Должность: " + position);
            Console.WriteLine("Обязанности: " + duties);
        }
    }

    // Задание 6: Класс "Самолёт"
    class Airplane {
        private string model;
        private string manufacturer;
        private int year;
        private string type;

        public Airplane() { }

        public Airplane(string model, string manufacturer, int year, string type) {
            this.model = model;
            this.manufacturer = manufacturer;
            this.year = year;
            this.type = type;
        }

        public void Input() {
            Console.Write("Модель: ");
            model = Console.ReadLine();

            Console.Write("Производитель: ");
            manufacturer = Console.ReadLine();

            Console.Write("Год выпуска: ");
            year = int.Parse(Console.ReadLine());

            Console.Write("Тип: ");
            type = Console.ReadLine();
        }

        public void Output() {
            Console.WriteLine($"Модель: {model}, Производитель: {manufacturer}, Год: {year}, Тип: {type}");
        }
    }

    // Задание 7: Класс "Матрица"
    class Matrix {
        private int[,] data;
        private int rows;
        private int cols;

        public Matrix(int r, int c) {
            rows = r;
            cols = c;
            data = new int[r, c];
        }

        public void Input() {
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    Console.Write($"Элемент [{i},{j}]: ");
                    data[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        public void Output() {
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    Console.Write(data[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public int GetMax() {
            int max = data[0, 0];
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    if (data[i, j] > max) max = data[i, j];
                }
            }
            return max;
        }

        public int GetMin() {
            int min = data[0, 0];
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    if (data[i, j] < min) min = data[i, j];
                }
            }
            return min;
        }
    }

    static void Task1() {
        Console.Write("Введите начало диапазона: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Введите конец диапазона: ");
        int b = int.Parse(Console.ReadLine());

        Console.WriteLine("Произведение: " + MultiplyRange(a, b));
    }

    static void Task2() {
        Console.Write("Введите число для проверки на простоту: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(IsPrime(n) ? "Простое" : "Не простое");
    }

    static void Task3() {
        Console.Write("Сколько элементов в массиве? ");
        int size = int.Parse(Console.ReadLine());

        int[] arr = new int[size];
        for (int i = 0; i < size; i++) {
            Console.Write($"Элемент {i}: ");
            arr[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Сортировать по возрастанию (1) или убыванию (0)? ");
        bool asc = int.Parse(Console.ReadLine()) == 1;

        SortArray(arr, asc);

        Console.WriteLine("Отсортированный массив:");
        foreach (int x in arr) Console.Write(x + " ");
        Console.WriteLine();
    }

    static void Task4() {
        City city = new City();
        city.Input();
        city.Output();
    }

    static void Task5() {
        Employee emp = new Employee();
        emp.Input();
        emp.Output();
    }

    static void Task6() {
        Airplane plane = new Airplane();
        plane.Input();
        plane.Output();
    }

    static void Task7() {
        Console.Write("Количество строк матрицы: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Количество столбцов матрицы: ");
        int cols = int.Parse(Console.ReadLine());

        Matrix matrix = new Matrix(rows, cols);
        matrix.Input();
        matrix.Output();

        Console.WriteLine("Максимум: " + matrix.GetMax());
        Console.WriteLine("Минимум: " + matrix.GetMin());
    }

    static void Main() {
        int choice;
        do {
            Console.WriteLine("1. Произведение чисел в диапазоне");
            Console.WriteLine("2. Проверка числа на простоту");
            Console.WriteLine("3. Сортировка массива");
            Console.WriteLine("4. Класс \"Город\"");
            Console.WriteLine("5. Класс \"Сотрудник\"");
            Console.WriteLine("6. Класс \"Самолёт\"");
            Console.WriteLine("7. Класс \"Матрица\"");
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
                case 7:
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