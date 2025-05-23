using System;

public class RangeOfArray<T> {
    private T[] array;
    private int lowerBound;
    private int upperBound;

    public RangeOfArray(T[] data, int lowerIndex, int upperIndex) {
        if (data == null) throw new ArgumentNullException(nameof(data), "Массив не может быть null.");
        if (lowerIndex >= upperIndex) throw new ArgumentException("Нижняя граница должна быть меньше верхней границы.");
        if (upperIndex - lowerIndex + 1 != data.Length)
            throw new ArgumentException("Размер диапазона должен соответствовать размеру исходного массива.");

        array = new T[upperIndex - lowerIndex + 1];
        Array.Copy(data, 0, array, 0, array.Length);
        lowerBound = lowerIndex;
        upperBound = upperIndex;
    }

    public T this[int index] {
        get {
            if (index < lowerBound || index > upperBound) throw new IndexOutOfRangeException($"Индекс должен быть в диапазоне [{lowerBound}, {upperBound}]");
            return array[index - lowerBound];
        }
    }

    public void Print() {
        Console.Write("[");
        for (int i = lowerBound; i <= upperBound; i++) {
            Console.Write(this[i]);
            if (i < upperBound) Console.Write(", ");
        }
        Console.WriteLine("]");
    }
}

class Program {
    static void Main(string[] args) {
        int[] data = { 10, 20, 30, 40, 50 };

        Console.WriteLine("Исходный массив:");
        Console.WriteLine("[10, 20, 30, 40, 50]");

        int lowerIndex = 0;
        int upperIndex = 0;

        while (true) {
            Console.WriteLine("Введите нижнюю границу диапазона:");
            Console.Write("> ");
            if (!int.TryParse(Console.ReadLine(), out lowerIndex)) {
                Console.WriteLine("Ошибка: Нижняя граница должна быть целым числом.");
                continue;
            }

            Console.WriteLine("Введите верхнюю границу диапазона:");
            Console.Write("> ");
            if (!int.TryParse(Console.ReadLine(), out upperIndex)) {
                Console.WriteLine("Ошибка: Верхняя граница должна быть целым числом.");
                continue;
            }

            if (lowerIndex >= upperIndex) {
                Console.WriteLine("Ошибка: Нижняя граница должна быть меньше верхней границы.");
                continue;
            }

            if (upperIndex - lowerIndex + 1 != data.Length) {
                Console.WriteLine("Ошибка: Разница между границами должна соответствовать размеру исходного массива.");
                continue;
            }

            break;
        }

        var rangeArray = new RangeOfArray<int>(data, lowerIndex, upperIndex);

        Console.WriteLine("\nМассив с пользовательским диапазоном:");
        rangeArray.Print();

        while (true) {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Получить элемент по индексу");
            Console.WriteLine("0. Выйти");
            Console.Write("> ");

            string choice = Console.ReadLine();
            switch (choice) {
                case "1":
                    while (true) {
                        Console.WriteLine("Введите индекс:");
                        Console.Write("> ");
                        if (!int.TryParse(Console.ReadLine(), out int indexGet)) {
                            Console.WriteLine("Ошибка: Индекс должен быть целым числом.");
                            continue;
                        }

                        try {
                            Console.WriteLine($"Элемент с индексом {indexGet}: {rangeArray[indexGet]}");
                            break;
                        } catch (Exception ex) {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    break;

                case "0":
                    Console.WriteLine("Программа завершена.");
                    return;

                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
}