using System;

class Program {

    // Задание 1: Сжать массив, удалив все 0 и заполнив освободившиеся элементы -1
    static void Task1() {
        Console.Write("Введите размер массива: ");
        int size = int.Parse(Console.ReadLine());

        int[] arr = new int[size];
        Console.WriteLine("Введите элементы массива:");
        for (int i = 0; i < size; i++) {
            Console.Write($"Элемент {i}: ");
            arr[i] = int.Parse(Console.ReadLine());
        }

        int writeIndex = 0;
        for (int i = 0; i < size; i++) {
            if (arr[i] != 0) {
                arr[writeIndex++] = arr[i];
            }
        }

        while (writeIndex < size) {
            arr[writeIndex++] = -1;
        }

        Console.WriteLine("Результат:");
        foreach (int num in arr) {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }

    // Задание 2: Преобразовать массив так, чтобы сначала шли отрицательные элементы, а потом положительные
    static void Task2() {
        Console.Write("Введите размер массива: ");
        int size = int.Parse(Console.ReadLine());

        int[] arr = new int[size];
        Console.WriteLine("Введите элементы массива:");
        for (int i = 0; i < size; i++) {
            Console.Write($"Элемент {i}: ");
            arr[i] = int.Parse(Console.ReadLine());
        }

        int left = 0;
        int right = size - 1;

        while (left < right) {
            while (arr[left] < 0 && left < right) {
                left++;
            }
            while (arr[right] >= 0 && left < right) {
                right--;
            }
            if (left < right) {
                int temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;
                left++;
                right--;
            }
        }

        Console.WriteLine("Результат:");
        foreach (int num in arr) {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }

    // Задание 3: Найти количество вхождений числа в массив
    static void Task3() {
        Console.Write("Введите размер массива: ");
        int size = int.Parse(Console.ReadLine());

        int[] arr = new int[size];
        Console.WriteLine("Введите элементы массива:");
        for (int i = 0; i < size; i++) {
            Console.Write($"Элемент {i}: ");
            arr[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Введите число для поиска: ");
        int target = int.Parse(Console.ReadLine());

        int count = 0;
        for (int i = 0; i < size; i++) {
            if (arr[i] == target) {
                count++;
            }
        }

        Console.WriteLine($"Число {target} встречается {count} раз(а).");
    }

    // Задание 4: Поменять местами столбцы в двумерном массиве
    static void Task4() {
        Console.Write("Введите количество строк матрицы: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Введите количество столбцов матрицы: ");
        int cols = int.Parse(Console.ReadLine());

        int[,] matrix = new int[rows, cols];

        Console.WriteLine("Введите элементы матрицы:");
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                Console.Write($"Элемент [{i},{j}]: ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        Console.Write("Введите номер первого столбца для обмена: ");
        int col1 = int.Parse(Console.ReadLine());

        Console.Write("Введите номер второго столбца для обмена: ");
        int col2 = int.Parse(Console.ReadLine());

        if (col1 < 0 || col1 >= cols || col2 < 0 || col2 >= cols) {
            Console.WriteLine("Неверные номера столбцов!");
            return;
        }

        for (int i = 0; i < rows; i++) {
            int temp = matrix[i, col1];
            matrix[i, col1] = matrix[i, col2];
            matrix[i, col2] = temp;
        }

        Console.WriteLine("Результат после обмена столбцов:");
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void Main() {
        int choice;
        do {
            Console.WriteLine("1. Сжать массив, удалив все 0 и заполнив освободившиеся элементы -1");
            Console.WriteLine("2. Преобразовать массив так, чтобы сначала шли отрицательные элементы, а потом положительные");
            Console.WriteLine("3. Найти количество вхождений числа в массив");
            Console.WriteLine("4. Поменять местами столбцы в двумерном массиве");
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