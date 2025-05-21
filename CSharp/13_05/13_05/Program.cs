using System;
using System.Collections.Generic;

class Program {

    class InsufficientFundsException : Exception {
        public InsufficientFundsException(string message) : base(message) { }
    }

    class AccountNotFoundException : Exception {
        public AccountNotFoundException(string message) : base(message) { }
    }

    class BankAccount {
        public string AccountNumber { get; private set; }
        public string OwnerName { get; private set; }
        public decimal Balance { get; private set; }

        public BankAccount() : this("", "", 0) { }

        public BankAccount(string accountNumber, string ownerName, decimal balance) {
            AccountNumber = accountNumber;
            OwnerName = ownerName;
            Balance = balance;
        }

        public void Deposit(decimal amount) {
            if (amount <= 0) throw new ArgumentException("Сумма пополнения должна быть больше нуля.");
            Balance += amount;
        }

        public void Withdraw(decimal amount) {
            if (amount <= 0) throw new ArgumentException("Сумма снятия должна быть больше нуля.");
            if (amount > Balance) throw new InsufficientFundsException("Недостаточно средств на счете.");
            Balance -= amount;
        }

        public void PrintAccountInfo() {
            Console.WriteLine($"Номер: {AccountNumber}, Владелец: {OwnerName}, Баланс: {Balance}");
        }
    }

    class Bank {
        private List<BankAccount> accounts = new List<BankAccount>();

        public void AddAccount(BankAccount account) {
            foreach (var acc in accounts) {
                if (acc.AccountNumber == account.AccountNumber) {
                    throw new ArgumentException("Счет с таким номером уже существует.");
                }
            }
            accounts.Add(account);
        }

        public BankAccount GetAccount(string accountNumber) {
            foreach (var acc in accounts) {
                if (acc.AccountNumber == accountNumber) {
                    return acc;
                }
            }
            throw new AccountNotFoundException("Счет не найден.");
        }

        public void Transfer(string fromAccount, string toAccount, decimal amount) {
            if (amount <= 0) throw new ArgumentException("Сумма перевода должна быть больше нуля.");

            var fromAcc = GetAccount(fromAccount);
            var toAcc = GetAccount(toAccount);

            fromAcc.Withdraw(amount);
            toAcc.Deposit(amount);
        }

        public void PrintAllAccounts() {
            if (accounts.Count == 0) {
                Console.WriteLine("Нет ни одного созданного счёта.");
                return;
            }

            foreach (var acc in accounts) {
                acc.PrintAccountInfo();
            }
        }
    }

    static void RunBankApp() {
        Bank bank = new Bank();

        while (true) {
            Console.WriteLine("1. Создать новый счёт");
            Console.WriteLine("2. Пополнить счёт");
            Console.WriteLine("3. Снять деньги со счёта");
            Console.WriteLine("4. Перевести между счётами");
            Console.WriteLine("5. Вывести все счета");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice)) {
                Console.Write("Некорректный ввод. Повторите: ");
            }

            switch (choice) {
                case 1:
                    string accNum = "";
                    while (string.IsNullOrWhiteSpace(accNum)) {
                        Console.Write("Введите номер счёта: ");
                        accNum = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(accNum)) {
                            Console.WriteLine("Номер счёта не может быть пустым.");
                        }
                    }

                    string owner = "";
                    while (string.IsNullOrWhiteSpace(owner)) {
                        Console.Write("Введите имя владельца: ");
                        owner = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(owner)) {
                            Console.WriteLine("Имя владельца не может быть пустым.");
                        }
                    }

                    decimal balance = 0;
                    bool validBalance = false;
                    while (!validBalance) {
                        Console.Write("Введите начальный баланс: ");
                        validBalance = decimal.TryParse(Console.ReadLine(), out balance);
                        if (!validBalance || balance < 0) {
                            Console.WriteLine("Введите корректное значение баланса (неотрицательное число).");
                            validBalance = false;
                        }
                    }

                    try {
                        bank.AddAccount(new BankAccount(accNum, owner, balance));
                        Console.WriteLine("Счёт успешно создан.");
                    } catch (ArgumentException ex) {
                        Console.WriteLine("Ошибка: " + ex.Message);
                    }
                    break;

                case 2:
                    string accDep = "";
                    while (string.IsNullOrWhiteSpace(accDep)) {
                        Console.Write("Введите номер счёта для пополнения: ");
                        accDep = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(accDep)) {
                            Console.WriteLine("Номер счёта не может быть пустым.");
                        }
                    }

                    decimal sumDep = 0;
                    bool validSumDep = false;
                    while (!validSumDep) {
                        Console.Write("Введите сумму: ");
                        validSumDep = decimal.TryParse(Console.ReadLine(), out sumDep);
                        if (!validSumDep || sumDep <= 0) {
                            Console.WriteLine("Введите положительное число.");
                            validSumDep = false;
                        }
                    }

                    try {
                        var account = bank.GetAccount(accDep);
                        account.Deposit(sumDep);
                        Console.WriteLine("Счёт успешно пополнен.");
                    } catch (Exception ex) {
                        Console.WriteLine("Ошибка: " + ex.Message);
                    }
                    break;

                case 3:
                    string accWith = "";
                    while (string.IsNullOrWhiteSpace(accWith)) {
                        Console.Write("Введите номер счёта для снятия: ");
                        accWith = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(accWith)) {
                            Console.WriteLine("Номер счёта не может быть пустым.");
                        }
                    }

                    decimal sumWith = 0;
                    bool validSumWith = false;
                    while (!validSumWith) {
                        Console.Write("Введите сумму: ");
                        validSumWith = decimal.TryParse(Console.ReadLine(), out sumWith);
                        if (!validSumWith || sumWith <= 0) {
                            Console.WriteLine("Введите положительное число.");
                            validSumWith = false;
                        }
                    }

                    try {
                        var account = bank.GetAccount(accWith);
                        account.Withdraw(sumWith);
                        Console.WriteLine("Деньги успешно сняты.");
                    } catch (Exception ex) {
                        Console.WriteLine("Ошибка: " + ex.Message);
                    }
                    break;

                case 4:
                    string fromAcc = "";
                    while (string.IsNullOrWhiteSpace(fromAcc)) {
                        Console.Write("Введите номер исходящего счёта: ");
                        fromAcc = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(fromAcc)) {
                            Console.WriteLine("Номер счёта не может быть пустым.");
                        }
                    }

                    string toAcc = "";
                    while (string.IsNullOrWhiteSpace(toAcc)) {
                        Console.Write("Введите номер целевого счёта: ");
                        toAcc = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(toAcc)) {
                            Console.WriteLine("Номер счёта не может быть пустым.");
                        }
                    }

                    decimal transferSum = 0;
                    bool validTransferSum = false;
                    while (!validTransferSum) {
                        Console.Write("Введите сумму перевода: ");
                        validTransferSum = decimal.TryParse(Console.ReadLine(), out transferSum);
                        if (!validTransferSum || transferSum <= 0) {
                            Console.WriteLine("Введите положительное число.");
                            validTransferSum = false;
                        }
                    }

                    try {
                        bank.Transfer(fromAcc, toAcc, transferSum);
                        Console.WriteLine("Перевод выполнен успешно.");
                    } catch (Exception ex) {
                        Console.WriteLine("Ошибка: " + ex.Message);
                    }
                    break;

                case 5:
                    bank.PrintAllAccounts();
                    break;

                case 0:
                    Console.WriteLine("Выход из программы.");
                    return;

                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
    }

    static void Main() {
        RunBankApp();
    }
}