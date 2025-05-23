using System;
using System.Collections.Generic;

enum Color {
    Red = 1,
    Green,
    Blue,
    Yellow,
    Cyan,
    Magenta,
    White
}

abstract class Shape {
    public Color Color { get; set; }
    public abstract string Name { get; }
    public Shape(Color color) {
        Color = color;
    }

    protected ConsoleColor GetConsoleColor() {
        switch (Color) {
            case Color.Red: return ConsoleColor.Red;
            case Color.Green: return ConsoleColor.Green;
            case Color.Blue: return ConsoleColor.Blue;
            case Color.Yellow: return ConsoleColor.Yellow;
            case Color.Cyan: return ConsoleColor.Cyan;
            case Color.Magenta: return ConsoleColor.Magenta;
            case Color.White: return ConsoleColor.White;
            default: return ConsoleColor.Gray;
        }
    }

    public abstract void Draw();
}

class Rectangle : Shape {
    public override string Name => "прямоугольник";
    public Rectangle(Color color) : base(color) { }

    public override void Draw() {
        Console.ForegroundColor = GetConsoleColor();
        for (int i = 0; i < 4; i++) {
            Console.WriteLine("********");
        }
        Console.ResetColor();
    }
}

class Rhombus : Shape {
    public override string Name => "ромб";
    public Rhombus(Color color) : base(color) { }

    public override void Draw() {
        Console.ForegroundColor = GetConsoleColor();
        Console.WriteLine("   *");
        Console.WriteLine("  ***");
        Console.WriteLine(" *****");
        Console.WriteLine("  ***");
        Console.WriteLine("   *");
        Console.ResetColor();
    }
}

class Triangle : Shape {
    public override string Name => "треугольник";
    public Triangle(Color color) : base(color) { }

    public override void Draw() {
        Console.ForegroundColor = GetConsoleColor();
        Console.WriteLine("   *");
        Console.WriteLine("  ***");
        Console.WriteLine(" *****");
        Console.WriteLine("*******");
        Console.ResetColor();
    }
}

class Trapezoid : Shape {
    public override string Name => "трапеция";
    public Trapezoid(Color color) : base(color) { }

    public override void Draw() {
        Console.ForegroundColor = GetConsoleColor();
        Console.WriteLine("   ****");
        Console.WriteLine("  ******");
        Console.WriteLine(" ********");
        Console.WriteLine("**********");
        Console.ResetColor();
    }
}

class Polygon : Shape {
    public override string Name => "многоугольник";
    public Polygon(Color color) : base(color) { }

    public override void Draw() {
        Console.ForegroundColor = GetConsoleColor();
        Console.WriteLine("   ***");
        Console.WriteLine("  *   *");
        Console.WriteLine(" *     *");
        Console.WriteLine("  *   *");
        Console.WriteLine("   ***");
        Console.ResetColor();
    }
}

class ShapeGroup {
    private List<Shape> shapes = new List<Shape>();

    public void AddShape(Shape shape) {
        shapes.Add(shape);
    }

    public void DrawAll() {
        foreach (var shape in shapes) {
            shape.Draw();
            Console.WriteLine();
        }
    }
}

class Program {
    static string ColorToRussian(Color color) {
        switch (color) {
            case Color.Red: return "красный";
            case Color.Green: return "зелёный";
            case Color.Blue: return "синий";
            case Color.Yellow: return "жёлтый";
            case Color.Cyan: return "голубой";
            case Color.Magenta: return "пурпурный";
            case Color.White: return "белый";
            default: return color.ToString().ToLower();
        }
    }

    static void Main() {
        ShapeGroup group = new ShapeGroup();

        while (true) {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Добавить прямоугольник");
            Console.WriteLine("2. Добавить ромб");
            Console.WriteLine("3. Добавить треугольник");
            Console.WriteLine("4. Добавить трапецию");
            Console.WriteLine("5. Добавить многоугольник");
            Console.WriteLine("6. Отобразить все фигуры");
            Console.WriteLine("0. Выход");
            Console.Write("> ");

            string choice = Console.ReadLine();
            if (choice == "0") break;

            if (choice == "6") {
                Console.WriteLine("");
                group.DrawAll();
                continue;
            }

            Console.WriteLine("Выберите цвет:");
            foreach (Color c in Enum.GetValues(typeof(Color))) {
                Console.WriteLine($"{(int)c}. {c}");
            }
            Console.Write("> ");

            int colorNum;
            while (!int.TryParse(Console.ReadLine(), out colorNum) || !Enum.IsDefined(typeof(Color), colorNum)) {
                Console.Write("Некорректный ввод. Повторите выбор цвета: ");
            }

            Color selectedColor = (Color)colorNum;
            Shape newShape = null;

            switch (choice) {
                case "1": newShape = new Rectangle(selectedColor); break;
                case "2": newShape = new Rhombus(selectedColor); break;
                case "3": newShape = new Triangle(selectedColor); break;
                case "4": newShape = new Trapezoid(selectedColor); break;
                case "5": newShape = new Polygon(selectedColor); break;
                default:
                    Console.WriteLine("Неверный выбор фигуры.");
                    continue;
            }

            group.AddShape(newShape);
            Console.WriteLine($"Создан: {ColorToRussian(selectedColor)} {newShape.Name}.\n");
        }
    }
}
