using System;
using System.Collections.Generic;
using System.Linq;

public class Person {
    public string Name { get; set; }
    public int Age { get; set; }
}

class Program {
    static void Main() {
        List<Person> people = new List<Person> {
            new Person { Name = "Алексей", Age = 35 },
            new Person { Name = "Никита", Age = 22 },
            new Person { Name = "Анастасия", Age = 19 },
            new Person { Name = "Ирина", Age = 28 },
            new Person { Name = "Даниил", Age = 17 },
            new Person { Name = "Анна", Age = 31 },
            new Person { Name = "Ольга", Age = 24 },
            new Person { Name = "Станислав", Age = 16 },
        };

        Console.WriteLine("1. Люди старше 30:");
        var over30 = people.Where(p => p.Age > 30);
        foreach (var person in over30) {
            Console.WriteLine($"{person.Name}, {person.Age}");
        }

        Console.WriteLine("\n2. Кол-во людей младше 20:");
        int countUnder20 = people.Count(p => p.Age < 20);
        Console.WriteLine(countUnder20);

        Console.WriteLine("\n3. Имена в верхнем регистре:");
        var upperNames = people.Select(p => p.Name.ToUpper());
        foreach (var name in upperNames) {
            Console.WriteLine(name);
        }

        Console.WriteLine("\n4. Средний возраст:");
        double averageAge = people.Average(p => p.Age);
        Console.WriteLine(averageAge);

        Console.WriteLine("\n5. Первый человек, имя с 'А':");
        var startsWithA = people.FirstOrDefault(p => p.Name.StartsWith("А"));
        if (startsWithA != null) {
            Console.WriteLine($"{startsWithA.Name}, {startsWithA.Age}");
        } else {
            Console.WriteLine("Нет совпадений");
        }

        Console.WriteLine("\n6. Группировка по возрасту:");
        var groupedByAge = people.GroupBy(p => p.Age);
        foreach (var group in groupedByAge) {
            Console.WriteLine($"Возраст {group.Key}:");
            foreach (var person in group) {
                Console.WriteLine($"  {person.Name}");
            }
        }

        Console.WriteLine("\n7. Сортировка по имени (А-Я):");
        var sortedByName = people.OrderBy(p => p.Name);
        foreach (var person in sortedByName) {
            Console.WriteLine($"{person.Name}, {person.Age}");
        }

        Console.WriteLine("\n8. Люди с буквой 'н' в имени, по убыванию возраста:");
        var filteredSorted = people
            .Where(p => p.Name.ToLower().Contains('н'))
            .OrderByDescending(p => p.Age);
        foreach (var person in filteredSorted) {
            Console.WriteLine($"{person.Name}, {person.Age}");
        }
    }
}
