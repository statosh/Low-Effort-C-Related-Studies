using System;
using System.Collections.Generic;

class Program {

    // === Класс Employee ===
    class Employee {
        private string fullName;
        private string birthDate;
        private string phone;
        private string email;
        private string position;
        private string duties;
        private decimal salary;

        public string FullName {
            get => fullName;
            set => fullName = value;
        }
        public string BirthDate {
            get => birthDate;
            set => birthDate = value;
        }
        public string Phone {
            get => phone;
            set => phone = value;
        }
        public string Email {
            get => email;
            set => email = value;
        }
        public string Position {
            get => position;
            set => position = value;
        }
        public string Duties {
            get => duties;
            set => duties = value;
        }
        public decimal Salary {
            get => salary;
            set => salary = value;
        }

        public Employee(string fullName, string birthDate, string phone, string email,
                        string position, string duties, decimal salary) {
            this.fullName = fullName;
            this.birthDate = birthDate;
            this.phone = phone;
            this.email = email;
            this.position = position;
            this.duties = duties;
            this.salary = salary;
        }

        public static Employee operator +(Employee e, decimal amount) {
            e.salary += amount;
            return e;
        }

        public static Employee operator -(Employee e, decimal amount) {
            if (e.salary - amount < 0)
                throw new InvalidOperationException("Зарплата не может быть отрицательной.");
            e.salary -= amount;
            return e;
        }

        public static bool operator ==(Employee a, Employee b) {
            return a.salary == b.salary;
        }

        public static bool operator !=(Employee a, Employee b) {
            return a.salary != b.salary;
        }

        public static bool operator <(Employee a, Employee b) {
            return a.salary < b.salary;
        }

        public static bool operator >(Employee a, Employee b) {
            return a.salary > b.salary;
        }

        public override bool Equals(object obj) {
            if (!(obj is Employee)) return false;
            return this.salary == ((Employee)obj).salary;
        }

        public override int GetHashCode() {
            return salary.GetHashCode();
        }

        public void Print() {
            Console.WriteLine($"ФИО: {fullName}, Зарплата: {salary}");
        }
    }

    // === Класс City ===
    class City {
        private string name;
        private string country;
        private int population;
        private string phoneCode;
        private string[] districts;

        public string Name {
            get => name;
            set => name = value;
        }
        public string Country {
            get => country;
            set => country = value;
        }
        public int Population {
            get => population;
            set => population = value;
        }
        public string PhoneCode {
            get => phoneCode;
            set => phoneCode = value;
        }
        public string[] Districts {
            get => districts;
            set => districts = value;
        }

        public City(string name, string country, int population, string phoneCode, string[] districts) {
            this.name = name;
            this.country = country;
            this.population = population;
            this.phoneCode = phoneCode;
            this.districts = districts;
        }

        public static City operator +(City c, int add) {
            c.population += add;
            return c;
        }

        public static City operator -(City c, int sub) {
            if (c.population - sub < 0)
                throw new InvalidOperationException("Число жителей не может быть отрицательным.");
            c.population -= sub;
            return c;
        }

        public static bool operator ==(City a, City b) {
            return a.population == b.population;
        }

        public static bool operator !=(City a, City b) {
            return a.population != b.population;
        }

        public static bool operator <(City a, City b) {
            return a.population < b.population;
        }

        public static bool operator >(City a, City b) {
            return a.population > b.population;
        }

        public override bool Equals(object obj) {
            if (!(obj is City)) return false;
            return this.population == ((City)obj).population;
        }

        public override int GetHashCode() {
            return population.GetHashCode();
        }

        public void Print() {
            Console.WriteLine($"Город: {name}, Жители: {population}");
        }
    }

    // === Класс Matrix ===
    class Matrix {
        private int[,] data;
        private int rows;
        private int cols;

        public int Rows => rows;
        public int Cols => cols;

        public Matrix(int r, int c) {
            rows = r;
            cols = c;
            data = new int[r, c];
        }

        public int this[int i, int j] {
            get {
                if (i >= 0 && i < rows && j >= 0 && j < cols)
                    return data[i, j];
                else
                    throw new IndexOutOfRangeException();
            }
            set {
                if (i >= 0 && i < rows && j >= 0 && j < cols)
                    data[i, j] = value;
                else
                    throw new IndexOutOfRangeException();
            }
        }

        public static Matrix operator +(Matrix a, Matrix b) {
            if (a.rows != b.rows || a.cols != b.cols)
                throw new InvalidOperationException("Матрицы разного размера.");

            Matrix result = new Matrix(a.rows, a.cols);
            for (int i = 0; i < a.rows; i++) {
                for (int j = 0; j < a.cols; j++) {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }
            return result;
        }

        public static Matrix operator -(Matrix a, Matrix b) {
            if (a.rows != b.rows || a.cols != b.cols)
                throw new InvalidOperationException("Матрицы разного размера.");

            Matrix result = new Matrix(a.rows, a.cols);
            for (int i = 0; i < a.rows; i++) {
                for (int j = 0; j < a.cols; j++) {
                    result[i, j] = a[i, j] - b[i, j];
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix a, Matrix b) {
            if (a.cols != b.rows)
                throw new InvalidOperationException("Несовместимые размеры матриц для умножения.");

            Matrix result = new Matrix(a.rows, b.cols);
            for (int i = 0; i < a.rows; i++) {
                for (int j = 0; j < b.cols; j++) {
                    int sum = 0;
                    for (int k = 0; k < a.cols; k++) {
                        sum += a[i, k] * b[k, j];
                    }
                    result[i, j] = sum;
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix a, int scalar) {
            Matrix result = new Matrix(a.rows, a.cols);
            for (int i = 0; i < a.rows; i++) {
                for (int j = 0; j < a.cols; j++) {
                    result[i, j] = a[i, j] * scalar;
                }
            }
            return result;
        }

        public static bool operator ==(Matrix a, Matrix b) {
            if (a.rows != b.rows || a.cols != b.cols) return false;
            for (int i = 0; i < a.rows; i++) {
                for (int j = 0; j < a.cols; j++) {
                    if (a[i, j] != b[i, j]) return false;
                }
            }
            return true;
        }

        public static bool operator !=(Matrix a, Matrix b) {
            return !(a == b);
        }

        public override bool Equals(object obj) {
            if (!(obj is Matrix)) return false;
            return this == (Matrix)obj;
        }

        public override int GetHashCode() {
            unchecked {
                int hash = 17;
                for (int i = 0; i < rows; i++) {
                    for (int j = 0; j < Cols; j++) {
                        hash = hash * 23 + data[i, j].GetHashCode();
                    }
                }
                return hash;
            }
        }

        public void Print() {
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    Console.Write(data[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }

    // === Класс CreditCard ===
    class CreditCard {
        private string cardNumber;
        private string ownerName;
        private string cvc;
        private decimal balance;

        public string CardNumber {
            get => cardNumber;
            set => cardNumber = value;
        }
        public string OwnerName {
            get => ownerName;
            set => ownerName = value;
        }
        public string CVC {
            get => cvc;
            set => cvc = value;
        }
        public decimal Balance {
            get => balance;
            set => balance = value;
        }

        public CreditCard(string cardNumber, string ownerName, string cvc, decimal balance) {
            this.cardNumber = cardNumber;
            this.ownerName = ownerName;
            this.cvc = cvc;
            this.balance = balance;
        }

        public static CreditCard operator +(CreditCard c, decimal amount) {
            c.balance += amount;
            return c;
        }

        public static CreditCard operator -(CreditCard c, decimal amount) {
            if (c.balance - amount < 0)
                throw new InvalidOperationException("Баланс не может быть отрицательным.");
            c.balance -= amount;
            return c;
        }

        public static bool operator ==(CreditCard a, CreditCard b) {
            return a.cvc == b.cvc;
        }

        public static bool operator !=(CreditCard a, CreditCard b) {
            return a.cvc != b.cvc;
        }

        public static bool operator <(CreditCard a, CreditCard b) {
            return a.balance < b.balance;
        }

        public static bool operator >(CreditCard a, CreditCard b) {
            return a.balance > b.balance;
        }

        public override bool Equals(object obj) {
            if (!(obj is CreditCard)) return false;
            return ((CreditCard)obj).cvc == this.cvc;
        }

        public override int GetHashCode() {
            return cvc.GetHashCode();
        }

        public void Print() {
            Console.WriteLine($"Карта: {cardNumber}, Баланс: {balance}, CVC: {cvc}");
        }
    }

    // === Main ===
    static void Main() {
        List<Employee> employees = new List<Employee>() {
            new Employee("Иван Петров", "01.01.1980", "123", "ivan@example.com", "Разработчик", "Пишет код", 1000),
            new Employee("Алексей Смирнов", "05.05.1985", "456", "alex@example.com", "Тестировщик", "Тестирует", 1200)
        };

        List<City> cities = new List<City>() {
            new City("Москва", "Россия", 12000000, "+7", new string[] { "ЦАО", "САО" }),
            new City("СПб", "Россия", 5000000, "+7", new string[] { "Адмиралтейский", "Петроградский" })
        };

        List<Matrix> matrices = new List<Matrix>() {
            CreateDefaultMatrix1(),
            CreateDefaultMatrix2()
        };

        List<CreditCard> cards = new List<CreditCard>() {
            new CreditCard("1234", "Иван", "123", 1000),
            new CreditCard("5678", "Петр", "456", 2000)
        };

        while (true) {
            Console.WriteLine();
            Console.WriteLine("1. Создать объект");
            Console.WriteLine("2. Тестировать операторы");
            Console.WriteLine("3. Выйти");
            Console.Write("Выберите действие: ");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3) {
                Console.Write("Некорректный ввод. Повторите (1-3): ");
            }

            Console.WriteLine();

            switch (choice) {
                case 1:
                    CreateObjectMenu(employees, cities, matrices, cards);
                    break;

                case 2:
                    TestOperatorsMenu(employees, cities, matrices, cards);
                    break;

                case 3:
                    Console.WriteLine("Выход из программы.");
                    return;
            }
        }
    }

    // === Вспомогательные методы ===
    static Matrix CreateDefaultMatrix1() {
        Matrix m = new Matrix(2, 2);
        m[0, 0] = 1; m[0, 1] = 2;
        m[1, 0] = 3; m[1, 1] = 4;
        return m;
    }

    static Matrix CreateDefaultMatrix2() {
        Matrix m = new Matrix(2, 2);
        m[0, 0] = 5; m[0, 1] = 6;
        m[1, 0] = 7; m[1, 1] = 8;
        return m;
    }

    static string ReadNonEmpty(string prompt) {
        string input;
        do {
            Console.Write(prompt);
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) {
                Console.WriteLine("Поле не может быть пустым. Повторите ввод.");
            }
        } while (string.IsNullOrWhiteSpace(input));
        return input;
    }

    static int ReadInt(string prompt, Func<int, bool> isValid) {
        int value;
        do {
            Console.Write(prompt);
        } while (!int.TryParse(Console.ReadLine(), out value) || !isValid(value));
        return value;
    }

    static decimal ReadDecimal(string prompt, Func<decimal, bool> isValid) {
        decimal value;
        do {
            Console.Write(prompt);
        } while (!decimal.TryParse(Console.ReadLine(), out value) || !isValid(value));
        return value;
    }

    static void PrintList<T>(List<T> list, string title, Func<T, string> toString) {
        Console.WriteLine(title + ":");
        for (int i = 0; i < list.Count; i++) {
            Console.WriteLine($"{i}. {toString(list[i])}");
        }
    }

    static int GetIndex(int count, string prompt) {
        int index;
        do {
            Console.Write(prompt);
        } while (!int.TryParse(Console.ReadLine(), out index) || index < 0 || index >= count);
        return index;
    }

    // === Формат вывода объектов ===
    static string FormatEmployee(Employee e) => $"{e.FullName}, Зарплата: {e.Salary}";

    static string FormatCity(City c) => $"{c.Name}, Население: {c.Population}";

    static string FormatMatrix(Matrix m) {
        string str = $"Матрица {m.Rows}x{m.Cols}:\n";
        for (int i = 0; i < m.Rows; i++) {
            for (int j = 0; j < m.Cols; j++) {
                str += m[i, j] + " ";
            }
            str += "\n";
        }
        return str;
    }

    static string FormatCard(CreditCard c) => $"Карта {c.CardNumber}, Баланс: {c.Balance}, CVC: {c.CVC}";

    // === Создание объектов ===
    static void CreateObjectMenu(List<Employee> employees, List<City> cities,
                                List<Matrix> matrices, List<CreditCard> cards) {
        Console.WriteLine("Создание объекта:");
        Console.WriteLine("1. Сотрудник");
        Console.WriteLine("2. Город");
        Console.WriteLine("3. Матрица");
        Console.WriteLine("4. Кредитная карта");
        Console.Write("Выберите тип объекта: ");

        int type;
        while (!int.TryParse(Console.ReadLine(), out type) || type < 1 || type > 4) {
            Console.Write("Некорректный ввод. Повторите (1-4): ");
        }

        Console.WriteLine();

        switch (type) {
            case 1:
                string name = ReadNonEmpty("ФИО: ");
                string birth = ReadNonEmpty("Дата рождения: ");
                string phone = ReadNonEmpty("Телефон: ");
                string email = ReadNonEmpty("Email: ");
                string position = ReadNonEmpty("Должность: ");
                string duties = ReadNonEmpty("Обязанности: ");
                decimal salary = ReadDecimal("Зарплата: ", x => x >= 0);

                employees.Add(new Employee(name, birth, phone, email, position, duties, salary));
                Console.WriteLine("Сотрудник создан.");
                break;

            case 2:
                string cityName = ReadNonEmpty("Название города: ");
                string country = ReadNonEmpty("Страна: ");
                int population = ReadInt("Количество жителей: ", x => x >= 0);
                string code = ReadNonEmpty("Телефонный код: ");
                int districtCount = ReadInt("Число районов: ", x => x >= 0);
                string[] districts = new string[districtCount];
                for (int i = 0; i < districtCount; i++) {
                    districts[i] = ReadNonEmpty($"Район {i + 1}: ");
                }

                cities.Add(new City(cityName, country, population, code, districts));
                Console.WriteLine("Город создан.");
                break;

            case 3:
                int rows = ReadInt("Число строк матрицы: ", x => x > 0);
                int cols = ReadInt("Число столбцов матрицы: ", x => x > 0);
                Matrix matrix = new Matrix(rows, cols);
                for (int i = 0; i < rows; i++) {
                    for (int j = 0; j < cols; j++) {
                        matrix[i, j] = ReadInt($"Элемент [{i},{j}]: ", x => true);
                    }
                }

                matrices.Add(matrix);
                Console.WriteLine("Матрица создана.");
                break;

            case 4:
                string cardNumber = ReadNonEmpty("Номер карты: ");
                string owner = ReadNonEmpty("Имя владельца: ");
                string cvc = ReadNonEmpty("CVC: ");
                decimal balance = ReadDecimal("Баланс: ", x => x >= 0);

                cards.Add(new CreditCard(cardNumber, owner, cvc, balance));
                Console.WriteLine("Карта создана.");
                break;
        }
    }

    // === Тестирование операторов ===
    static void TestOperatorsMenu(List<Employee> employees, List<City> cities,
                                 List<Matrix> matrices, List<CreditCard> cards) {
        Console.WriteLine("Тестирование операторов:");
        Console.WriteLine("1. Сотрудник");
        Console.WriteLine("2. Город");
        Console.WriteLine("3. Матрица");
        Console.WriteLine("4. Кредитная карта");
        Console.Write("Выберите тип: ");

        int type;
        while (!int.TryParse(Console.ReadLine(), out type) || type < 1 || type > 4) {
            Console.Write("Некорректный ввод. Повторите (1-4): ");
        }

        Console.WriteLine();

        switch (type) {
            case 1 when employees.Count >= 2:
                TestEmployeeOperators(employees);
                break;

            case 2 when cities.Count >= 2:
                TestCityOperators(cities);
                break;

            case 3 when matrices.Count >= 2:
                TestMatrixOperators(matrices);
                break;

            case 4 when cards.Count >= 2:
                TestCardOperators(cards);
                break;

            default:
                Console.WriteLine("Недостаточно объектов для тестирования.");
                break;
        }
    }

    // === Тестирование сотрудников ===
    static void TestEmployeeOperators(List<Employee> employees) {
        PrintList(employees, "Сотрудники", FormatEmployee);
        int a = GetIndex(employees.Count, "Индекс первого сотрудника: ");
        int b = GetIndex(employees.Count, "Индекс второго сотрудника: ");

        var empA = employees[a];
        var empB = employees[b];

        Console.WriteLine();
        Console.WriteLine("Доступные операции:");
        Console.WriteLine("1. Увеличить зарплату");
        Console.WriteLine("2. Уменьшить зарплату");
        Console.WriteLine("3. Проверить == (по зарплате)");
        Console.WriteLine("4. Проверить != (по зарплате)");
        Console.WriteLine("5. Проверить > (по зарплате)");
        Console.WriteLine("6. Проверить < (по зарплате)");

        Console.Write("Выберите операцию: ");
        int op;
        while (!int.TryParse(Console.ReadLine(), out op) || op < 1 || op > 6) {
            Console.Write("Некорректный ввод. Повторите (1-6): ");
        }

        Console.WriteLine();

        Console.Write("Какой объект редактировать? (1 - первый, 2 - второй): ");
        int target;
        while (!int.TryParse(Console.ReadLine(), out target) || target < 1 || target > 2) {
            Console.Write("Некорректный ввод. Выберите 1 или 2: ");
        }

        var selected = target == 1 ? empA : empB;
        var other = target == 1 ? empB : empA;

        switch (op) {
            case 1:
                decimal amountUp = ReadDecimal("Введите сумму для увеличения зарплаты: ", x => x > 0);
                selected += amountUp;
                Console.WriteLine("Новая зарплата: " + selected.Salary);
                break;

            case 2:
                decimal amountDown = ReadDecimal("Введите сумму для уменьшения зарплаты: ", x => x > 0 && x <= selected.Salary);
                selected -= amountDown;
                Console.WriteLine("Новая зарплата: " + selected.Salary);
                break;

            case 3:
                Console.WriteLine(selected == other ? "Зарплаты равны" : "Зарплаты не равны");
                break;

            case 4:
                Console.WriteLine(selected != other ? "Зарплаты не равны" : "Зарплаты равны");
                break;

            case 5:
                Console.WriteLine(selected > other ? "empA > empB" : "empA <= empB");
                break;

            case 6:
                Console.WriteLine(selected < other ? "empA < empB" : "empA >= empB");
                break;
        }
    }

    // === Тестирование городов ===
    static void TestCityOperators(List<City> cities) {
        PrintList(cities, "Города", FormatCity);
        int a = GetIndex(cities.Count, "Индекс первого города: ");
        int b = GetIndex(cities.Count, "Индекс второго города: ");

        var cityA = cities[a];
        var cityB = cities[b];

        Console.WriteLine();
        Console.WriteLine("Доступные операции:");
        Console.WriteLine("1. Увеличить население");
        Console.WriteLine("2. Уменьшить население");
        Console.WriteLine("3. Проверить == (по населению)");
        Console.WriteLine("4. Проверить != (по населению)");
        Console.WriteLine("5. Проверить > (по населению)");
        Console.WriteLine("6. Проверить < (по населению)");

        Console.Write("Выберите операцию: ");
        int op;
        while (!int.TryParse(Console.ReadLine(), out op) || op < 1 || op > 6) {
            Console.Write("Некорректный ввод. Повторите (1-6): ");
        }

        Console.WriteLine();

        Console.Write("Какой объект редактировать? (1 - первый, 2 - второй): ");
        int target;
        while (!int.TryParse(Console.ReadLine(), out target) || target < 1 || target > 2) {
            Console.Write("Некорректный ввод. Выберите 1 или 2: ");
        }

        var selected = target == 1 ? cityA : cityB;
        var other = target == 1 ? cityB : cityA;

        switch (op) {
            case 1:
                int add = ReadInt("Введите число жителей для добавления: ", x => x > 0);
                selected += add;
                Console.WriteLine("Новое население: " + selected.Population);
                break;

            case 2:
                int sub = ReadInt("Введите число жителей для удаления: ", x => x > 0 && x <= selected.Population);
                selected -= sub;
                Console.WriteLine("Новое население: " + selected.Population);
                break;

            case 3:
                Console.WriteLine(selected == other ? "Население равно" : "Население не равно");
                break;

            case 4:
                Console.WriteLine(selected != other ? "Население не равно" : "Население равно");
                break;

            case 5:
                Console.WriteLine(selected > other ? "selected > other" : "selected <= other");
                break;

            case 6:
                Console.WriteLine(selected < other ? "selected < other" : "selected >= other");
                break;
        }
    }

    // === Тестирование матриц ===
    static void TestMatrixOperators(List<Matrix> matrices) {
        PrintList(matrices, "Матрицы", FormatMatrix);
        int a = GetIndex(matrices.Count, "Индекс первой матрицы: ");
        int b = GetIndex(matrices.Count, "Индекс второй матрицы: ");

        var matA = matrices[a];
        var matB = matrices[b];

        Console.WriteLine();
        Console.WriteLine("Доступные операции:");
        Console.WriteLine("1. Сложить матрицы");
        Console.WriteLine("2. Вычесть матрицы");
        Console.WriteLine("3. Умножить матрицы");
        Console.WriteLine("4. Умножить на число");

        Console.Write("Выберите операцию: ");
        int op;
        while (!int.TryParse(Console.ReadLine(), out op) || op < 1 || op > 4) {
            Console.Write("Некорректный ввод. Повторите (1-4): ");
        }

        Console.WriteLine();

        try {
            switch (op) {
                case 1:
                    var sum = matA + matB;
                    Console.WriteLine("Результат сложения:");
                    sum.Print();
                    break;

                case 2:
                    var diff = matA - matB;
                    Console.WriteLine("Результат вычитания:");
                    diff.Print();
                    break;

                case 3:
                    var prod = matA * matB;
                    Console.WriteLine("Результат умножения:");
                    prod.Print();
                    break;

                case 4:
                    decimal scalar = ReadDecimal("Введите множитель: ", x => x != 0);
                    var scaled = matA * (int)scalar;
                    Console.WriteLine("Результат умножения на число:");
                    scaled.Print();
                    break;
            }
        } catch (Exception ex) {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }

    // === Тестирование карт ===
    static void TestCardOperators(List<CreditCard> cards) {
        PrintList(cards, "Карты", FormatCard);
        int a = GetIndex(cards.Count, "Индекс первой карты: ");
        int b = GetIndex(cards.Count, "Индекс второй карты: ");

        var cardA = cards[a];
        var cardB = cards[b];

        Console.WriteLine();
        Console.WriteLine("Доступные операции:");
        Console.WriteLine("1. Пополнить баланс");
        Console.WriteLine("2. Снять деньги");
        Console.WriteLine("3. Проверить == (по CVC)");
        Console.WriteLine("4. Проверить != (по CVC)");
        Console.WriteLine("5. Проверить > (по балансу)");
        Console.WriteLine("6. Проверить < (по балансу)");

        Console.Write("Выберите операцию: ");
        int op;
        while (!int.TryParse(Console.ReadLine(), out op) || op < 1 || op > 6) {
            Console.Write("Некорректный ввод. Повторите (1-6): ");
        }

        Console.WriteLine();

        Console.Write("Какой объект редактировать? (1 - первая карта, 2 - вторая): ");
        int target;
        while (!int.TryParse(Console.ReadLine(), out target) || target < 1 || target > 2) {
            Console.Write("Некорректный ввод. Выберите 1 или 2: ");
        }

        var selected = target == 1 ? cardA : cardB;
        var other = target == 1 ? cardB : cardA;

        switch (op) {
            case 1:
                decimal add = ReadDecimal("Введите сумму для пополнения: ", x => x > 0);
                selected += add;
                selected.Print();
                break;

            case 2:
                decimal sub = ReadDecimal("Введите сумму для снятия: ", x => x > 0 && x <= selected.Balance);
                selected -= sub;
                selected.Print();
                break;

            case 3:
                Console.WriteLine(selected == other ? "CVC совпадает" : "CVC не совпадает");
                break;

            case 4:
                Console.WriteLine(selected != other ? "CVC не совпадает" : "CVC совпадает");
                break;

            case 5:
                Console.WriteLine(selected > other ? "Баланс больше" : "Баланс меньше или равен");
                break;

            case 6:
                Console.WriteLine(selected < other ? "Баланс меньше" : "Баланс больше или равен");
                break;
        }
    }
}