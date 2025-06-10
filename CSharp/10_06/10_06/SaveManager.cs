using System;
using System.IO;
using System.Xml.Serialization;

static class SaveManager {
    private static string savePath = "savegame.xml";

    public static Player Load() {
        if (!File.Exists(savePath)) {
            Console.WriteLine("Сохранений не найдено.");
            return null;
        }

        try {
            using (var reader = new StreamReader(savePath)) {
                if (reader.Peek() < 0) {
                    Console.WriteLine("Файл сохранения повреждён или пуст.");
                    return null;
                }

                var serializer = new XmlSerializer(typeof(Player));
                return (Player)serializer.Deserialize(reader);
            }
        } catch (Exception ex) {
            Console.WriteLine($"Ошибка загрузки сохранения: {ex.Message}");
            return null;
        }
    }

    public static void Save(Player player) {
        try {
            using (var writer = new StreamWriter(savePath)) {
                var serializer = new XmlSerializer(typeof(Player));
                serializer.Serialize(writer, player);
            }
            Console.WriteLine("Прогресс успешно сохранён в файл savegame.xml");
        } catch (Exception ex) {
            Console.WriteLine($"Ошибка сохранения: {ex.Message}");
        }
    }
}