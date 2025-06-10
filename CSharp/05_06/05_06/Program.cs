using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace FileSystemExplorer {
    class Program {
        static void Main() {
            Console.WriteLine("Введите путь к директории:");
            Console.Write("> ");
            string path = Console.ReadLine();

            if (!Directory.Exists(path)) {
                Console.WriteLine("Ошибка: Директория не существует.");
                return;
            }

            var explorer = new FileSystemExplorer(path);

            explorer.DisplaySortedFilesAndFolders();

            Console.WriteLine("\nВыберите фильтр:");
            Console.WriteLine("1. По расширению");
            Console.WriteLine("2. По дате изменения");
            Console.WriteLine("3. По размеру");
            Console.Write("> ");
            string choice = Console.ReadLine();

            IEnumerable<FileInfo> filteredFiles = Enumerable.Empty<FileInfo>();

            switch (choice) {
                case "1": {
                        Console.Write("Введите расширение (например, .txt): ");
                        string ext = Console.ReadLine();
                        filteredFiles = explorer.FilterByExtension(ext);
                        break;
                    }
                case "2": {
                        Console.Write("Введите дату в формате гггг-мм-дд: ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime date)) {
                            filteredFiles = explorer.FilterByDate(date);
                        } else {
                            Console.WriteLine("Неверный формат даты.");
                        }
                        break;
                    }
                case "3": {
                        Console.Write("Введите минимальный размер в байтах: ");
                        if (long.TryParse(Console.ReadLine(), out long size)) {
                            filteredFiles = explorer.FilterBySize(size);
                        } else {
                            Console.WriteLine("Неверный ввод размера.");
                        }
                        break;
                    }
                default: {
                        Console.WriteLine("Неизвестный выбор.");
                        break;
                    }
            }

            Console.WriteLine("\nФайлы после фильтрации:");
            foreach (var file in filteredFiles) {
                Console.WriteLine($"{file.Name} ({file.Length} байт)");
            }

            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Удалить файлы");
            Console.WriteLine("2. Переименовать директорию");
            Console.WriteLine("0. Выход");
            Console.Write("> ");
            string action = Console.ReadLine();

            switch (action) {
                case "1": {
                        explorer.DeleteFiles(filteredFiles);
                        break;
                    }
                case "2": {
                        Console.Write("Введите новое имя директории: ");
                        string newName = Console.ReadLine();
                        explorer.RenameDirectory(newName);
                        break;
                    }
                case "0": {
                        return;
                    }
                default: {
                        Console.WriteLine("Неизвестная команда.");
                        break;
                    }
            }
        }
    }

    class FileSystemExplorer {
        private string _directoryPath;

        public FileSystemExplorer(string path) {
            _directoryPath = path;
        }

        public void DisplaySortedFilesAndFolders() {
            try {
                Console.WriteLine("\nСодержимое директории (отсортировано по размеру):");

                var files = new DirectoryInfo(_directoryPath).GetFiles()
                    .OrderByDescending(f => f.Length)
                    .ToList();

                var dirs = new DirectoryInfo(_directoryPath).GetDirectories();

                foreach (var dir in dirs) {
                    Console.WriteLine("[Папка] " + dir.Name);
                }

                foreach (var file in files) {
                    Console.WriteLine($"{file.Name} ({file.Length} байт)");
                }
            } catch (UnauthorizedAccessException) {
                Console.WriteLine("Ошибка доступа к содержимому директории.");
            } catch (Exception ex) {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        public IEnumerable<FileInfo> FilterByExtension(string extension) {
            return new DirectoryInfo(_directoryPath).GetFiles()
                .Where(f => f.Extension.Equals(extension, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<FileInfo> FilterByDate(DateTime date) {
            return new DirectoryInfo(_directoryPath).GetFiles()
                .Where(f => f.LastWriteTime.Date == date.Date);
        }

        public IEnumerable<FileInfo> FilterBySize(long minSize) {
            return new DirectoryInfo(_directoryPath).GetFiles()
                .Where(f => f.Length >= minSize);
        }

        public void DeleteFiles(IEnumerable<FileInfo> files) {
            foreach (var file in files) {
                try {
                    file.Delete();
                    Console.WriteLine($"Удалён: {file.Name}");
                } catch (Exception ex) {
                    Console.WriteLine($"Ошибка при удалении {file.Name}: {ex.Message}");
                }
            }
        }

        public void RenameDirectory(string newName) {
            try {
                string parent = Directory.GetParent(_directoryPath).FullName;
                string newPath = Path.Combine(parent, newName);

                Directory.Move(_directoryPath, newPath);
                _directoryPath = newPath;

                Console.WriteLine($"Директория переименована в: {newName}");
            } catch (Exception ex) {
                Console.WriteLine($"Ошибка при переименовании: {ex.Message}");
            }
        }
    }
}
