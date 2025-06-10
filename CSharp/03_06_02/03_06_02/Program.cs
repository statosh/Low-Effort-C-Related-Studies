using System;
using System.IO;
using System.Linq;

class Program {
    static string currentDirectory = Directory.GetCurrentDirectory();
    static string logFile = "log.txt";

    static void Main() {
        while (true) {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nТекущая директория: {currentDirectory}");
            Console.ResetColor();

            Console.WriteLine("");
            Console.WriteLine("1. Перейти в поддиректорию");
            Console.WriteLine("2. Вернуться в родительскую директорию");
            Console.WriteLine("3. Просмотр содержимого директории");
            Console.WriteLine("4. Создать файл");
            Console.WriteLine("5. Удалить файл");
            Console.WriteLine("6. Копировать файл");
            Console.WriteLine("7. Прочитать файл");
            Console.WriteLine("8. Поиск файлов по маске");
            Console.WriteLine("9. Подсчитать размер директории");
            Console.WriteLine("0. Выход");
            Console.WriteLine("Выберите задание: ");
            Console.Write("> ");
            string choice = Console.ReadLine();

            try {
                switch (choice) {
                    case "1": {
                            Console.WriteLine("Введите имя поддиректории: ");
                            Console.Write("> ");
                            string dir = Console.ReadLine();
                            ChangeDirectory(dir);
                            break;
                        }
                    case "2": {
                            ChangeDirectory("..");
                            break;
                        }
                    case "3": {
                            ShowDirectoryContents();
                            break;
                        }
                    case "4": {
                            Console.WriteLine("Введите имя файла: ");
                            Console.Write("> ");
                            string name = Console.ReadLine();
                            CreateFile(name);
                            break;
                        }
                    case "5": {
                            Console.WriteLine("Введите имя файла для удаления: ");
                            Console.Write("> ");
                            string name = Console.ReadLine();
                            DeleteFile(name);
                            break;
                        }
                    case "6": {
                            Console.WriteLine("Введите имя исходного файла: ");
                            Console.Write("> ");
                            string source = Console.ReadLine();
                            Console.WriteLine("Введите путь назначения: ");
                            Console.Write("> ");
                            string dest = Console.ReadLine();
                            CopyFile(source, dest);
                            break;
                        }
                    case "7": {
                            Console.WriteLine("Введите имя файла: ");
                            Console.Write("> ");
                            string name = Console.ReadLine();
                            ReadFile(name);
                            break;
                        }
                    case "8": {
                            Console.WriteLine("Введите маску поиска (например, *.txt): ");
                            Console.Write("> ");
                            string pattern = Console.ReadLine();
                            FindFiles(pattern);
                            break;
                        }
                    case "9": {
                            ShowDirectorySize();
                            break;
                        }
                    case "0": {
                            return;
                        }
                    default: {
                            Console.WriteLine("Неверный выбор.");
                            break;
                        }
                }
            } catch (FileNotFoundException ex) {
                Log($"Ошибка: Файл не найден ({ex.Message})");
                Console.WriteLine("Файл не найден.");
            } catch (UnauthorizedAccessException ex) {
                Log($"Ошибка: Нет доступа ({ex.Message})");
                Console.WriteLine("Нет доступа.");
            } catch (Exception ex) {
                Log($"Ошибка: {ex.Message}");
                Console.WriteLine("Произошла ошибка.");
            }
        }
    }

    static void ChangeDirectory(string dir) {
        if (dir == "..") {
            currentDirectory = Directory.GetParent(currentDirectory)?.FullName ?? currentDirectory;
        } else {
            string target = Path.Combine(currentDirectory, dir);
            if (Directory.Exists(target)) {
                currentDirectory = target;
            } else {
                Console.WriteLine("Папка не найдена.");
                Log($"Ошибка: Папка \"{dir}\" не найдена.");
            }
        }
    }

    static void ShowDirectoryContents() {
        Console.WriteLine("\nСодержимое директории:");
        foreach (string dir in Directory.GetDirectories(currentDirectory)) {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("[Папка]  " + Path.GetFileName(dir));
        }

        foreach (string file in Directory.GetFiles(currentDirectory)) {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("[Файл]   " + Path.GetFileName(file));
        }

        Console.ResetColor();
    }

    static void CreateFile(string name) {
        string path = Path.Combine(currentDirectory, name);
        File.WriteAllText(path, "");
        Log($"Создан файл \"{name}\".");
        Console.WriteLine("Файл создан.");
    }

    static void DeleteFile(string name) {
        string path = Path.Combine(currentDirectory, name);
        if (File.Exists(path)) {
            File.Delete(path);
            Log($"Удалён файл \"{name}\".");
            Console.WriteLine("Файл удалён.");
        } else {
            Console.WriteLine("Файл не найден.");
            Log($"Ошибка: Файл \"{name}\" не найден.");
        }
    }

    static void CopyFile(string sourceName, string destPath) {
        string sourcePath = Path.Combine(currentDirectory, sourceName);
        if (!File.Exists(sourcePath)) {
            Console.WriteLine("Исходный файл не найден.");
            Log($"Ошибка: Исходный файл \"{sourceName}\" не найден.");
            return;
        }

        string destination = Path.IsPathRooted(destPath) ? destPath : Path.Combine(currentDirectory, destPath);
        File.Copy(sourcePath, destination, true);
        Log($"Скопирован файл \"{sourceName}\" в \"{destPath}\".");
        Console.WriteLine("Файл скопирован.");
    }

    static void ReadFile(string name) {
        string path = Path.Combine(currentDirectory, name);
        if (File.Exists(path)) {
            Console.WriteLine(File.ReadAllText(path));
            Log($"Прочитан файл \"{name}\".");
        } else {
            Console.WriteLine("Файл не найден.");
            Log($"Ошибка: Файл \"{name}\" не найден.");
        }
    }

    static void FindFiles(string pattern) {
        string[] files = Directory.GetFiles(currentDirectory, pattern);
        if (files.Length == 0) {
            Console.WriteLine("Файлы не найдены.");
        } else {
            Console.WriteLine("Найдено:");
            foreach (string file in files) {
                Console.WriteLine("- " + Path.GetFileName(file));
            }
        }
        Log($"Поиск по маске \"{pattern}\" завершён.");
    }

    static void ShowDirectorySize() {
        long size = Directory.GetFiles(currentDirectory, "*", SearchOption.AllDirectories)
            .Select(file => new FileInfo(file).Length)
            .Sum();
        Console.WriteLine($"Размер директории: {size} байт");
        Log($"Подсчитан размер директории: {size} байт.");
    }

    static void Log(string message) {
        string entry = $"[{DateTime.Now:yyyy-MM-dd HH:mm}] {message}";
        File.AppendAllText(logFile, entry + Environment.NewLine);
    }
}
