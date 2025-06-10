using System;
using System.IO;

class Program {
    static void Main() {
        while (true) {
            Console.Clear();
            Console.WriteLine("1. Базовые операции с файлами");
            Console.WriteLine("2. Работа с директориями");
            Console.WriteLine("3. Чтение/запись через потоки (Streams)");
            Console.WriteLine("0. Выход");
            Console.WriteLine("Выберите задание: ");
            Console.Write("> ");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 3) {
                Console.WriteLine("Неверный выбор. Повторите: ");
                Console.Write("> ");
            }

            Console.Clear();

            switch (choice) {
                case 1:
                    Task1_FileOperations();
                    break;

                case 2:
                    Task2_DirectoryOperations();
                    break;

                case 3:
                    Task3_StreamOperations();
                    break;

                case 0:
                    Console.WriteLine("Выход...");
                    return;
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }

    static void Task1_FileOperations() {
        string filePath = "data.txt";
        string[] lines = {
            "Первая строка",
            "Вторая строка",
            "Третья строка",
            "Четвёртая строка",
            "Пятая строка"
        };

        try {
            File.WriteAllLines(filePath, lines);
            Console.WriteLine("Файл data.txt создан и записан.");
        } catch (Exception ex) {
            Console.WriteLine("Ошибка при записи файла: " + ex.Message);
        }

        try {
            string[] readLines = File.ReadAllLines(filePath);
            Console.WriteLine("Содержимое файла data.txt:");
            foreach (string line in readLines) {
                Console.WriteLine(line);
            }
        } catch (FileNotFoundException) {
            Console.WriteLine("Файл data.txt не найден.");
        } catch (Exception ex) {
            Console.WriteLine("Ошибка при чтении файла: " + ex.Message);
        }

        try {
            File.AppendAllText(filePath, "\nШестая строка");
            Console.WriteLine("Новая строка добавлена в файл data.txt.");
        } catch (Exception ex) {
            Console.WriteLine("Ошибка при добавлении строки в файл: " + ex.Message);
        }

        try {
            if (File.Exists(filePath)) {
                File.Delete(filePath);
                Console.WriteLine("Файл data.txt удален.");
            } else {
                Console.WriteLine("Файл data.txt не существует.");
            }
        } catch (Exception ex) {
            Console.WriteLine("Ошибка при удалении файла: " + ex.Message);
        }
    }

    static void Task2_DirectoryOperations() {
        string labFolderPath = "LabFolder";
        string docsPath = Path.Combine(labFolderPath, "Docs");
        string imagesPath = Path.Combine(labFolderPath, "Images");
        string tempPath = Path.Combine(labFolderPath, "Temp");
        string sourceFilePath = "data.txt";
        string destinationFilePath = Path.Combine(docsPath, "data_renamed.txt");

        try {
            Directory.CreateDirectory(labFolderPath);
            Console.WriteLine("Директория LabFolder создана.");
        } catch (Exception ex) {
            Console.WriteLine("Ошибка при создании директории LabFolder: " + ex.Message);
        }

        try {
            Directory.CreateDirectory(docsPath);
            Directory.CreateDirectory(imagesPath);
            Directory.CreateDirectory(tempPath);
            Console.WriteLine("Поддиректории Docs, Images, Temp созданы.");
        } catch (Exception ex) {
            Console.WriteLine("Ошибка при создании поддиректорий: " + ex.Message);
        }

        try {
            if (File.Exists(sourceFilePath)) {
                File.Copy(sourceFilePath, Path.Combine(docsPath, Path.GetFileName(sourceFilePath)), true);
                Console.WriteLine("Файл data.txt скопирован в папку Docs.");
            } else {
                Console.WriteLine("Файл data.txt не существует.");
            }
        } catch (Exception ex) {
            Console.WriteLine("Ошибка при копировании файла: " + ex.Message);
        }

        try {
            if (File.Exists(Path.Combine(docsPath, Path.GetFileName(sourceFilePath)))) {
                File.Move(Path.Combine(docsPath, Path.GetFileName(sourceFilePath)), destinationFilePath);
                Console.WriteLine("Файл переименован в data_renamed.txt.");
            } else {
                Console.WriteLine("Файл data.txt не найден в папке Docs.");
            }
        } catch (Exception ex) {
            Console.WriteLine("Ошибка при переименовании файла: " + ex.Message);
        }

        try {
            if (Directory.Exists(tempPath)) {
                Directory.Delete(tempPath, true);
                Console.WriteLine("Папка Temp удалена.");
            } else {
                Console.WriteLine("Папка Temp не существует.");
            }
        } catch (Exception ex) {
            Console.WriteLine("Ошибка при удалении папки Temp: " + ex.Message);
        }
    }

    static void Task3_StreamOperations() {
        string filePath = "binary.dat";
        int[] numbers = { 1, 2, 3, 4, 5 };

        try {
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write)) {
                using (BinaryWriter writer = new BinaryWriter(fs)) {
                    foreach (int number in numbers) {
                        writer.Write(number);
                    }
                }
            }
            Console.WriteLine("Массив чисел записан в файл binary.dat.");
        } catch (IOException ex) {
            Console.WriteLine("Ошибка при записи в файл binary.dat: " + ex.Message);
        } catch (Exception ex) {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }

        try {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read)) {
                using (BinaryReader reader = new BinaryReader(fs)) {
                    Console.WriteLine("Содержимое файла binary.dat:");
                    while (reader.BaseStream.Position != reader.BaseStream.Length) {
                        int number = reader.ReadInt32();
                        Console.WriteLine(number);
                    }
                }
            }
        } catch (FileNotFoundException) {
            Console.WriteLine("Файл binary.dat не найден.");
        } catch (IOException ex) {
            Console.WriteLine("Ошибка при чтении файла binary.dat: " + ex.Message);
        } catch (Exception ex) {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }

        try {
            if (File.Exists(filePath)) {
                File.Delete(filePath);
                Console.WriteLine("Файл binary.dat удален.");
            } else {
                Console.WriteLine("Файл binary.dat не существует.");
            }
        } catch (Exception ex) {
            Console.WriteLine("Ошибка при удалении файла binary.dat: " + ex.Message);
        }
    }
}