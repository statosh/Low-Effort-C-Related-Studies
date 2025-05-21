using System;
using System.Collections.Generic;
using System.Linq;

abstract class GeometricFigure {
    public abstract double Area();
    public abstract double Perimeter();
}

class Triangle : GeometricFigure {
    private double sideA, sideB, sideC;

    public Triangle(double a, double b, double c) {
        sideA = a;
        sideB = b;
        sideC = c;
    }

    public override double Area() {
        double s = (sideA + sideB + sideC) / 2;
        return Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));
    }

    public override double Perimeter() {
        return sideA + sideB + sideC;
    }
}

class Square : GeometricFigure {
    private double side;

    public Square(double side) {
        this.side = side;
    }

    public override double Area() {
        return side * side;
    }

    public override double Perimeter() {
        return 4 * side;
    }
}

class Rhombus : GeometricFigure {
    private double diagonal1, diagonal2;

    public Rhombus(double d1, double d2) {
        diagonal1 = d1;
        diagonal2 = d2;
    }

    public override double Area() {
        return (diagonal1 * diagonal2) / 2;
    }

    public override double Perimeter() {
        double side = Math.Sqrt((diagonal1 * diagonal1 + diagonal2 * diagonal2) / 2);
        return 4 * side;
    }
}

class Rectangle : GeometricFigure {
    private double width, height;

    public Rectangle(double w, double h) {
        width = w;
        height = h;
    }

    public override double Area() {
        return width * height;
    }

    public override double Perimeter() {
        return 2 * (width + height);
    }
}

class Parallelogram : GeometricFigure {
    private double baseLength, height;

    public Parallelogram(double baseLength, double height) {
        this.baseLength = baseLength;
        this.height = height;
    }

    public override double Area() {
        return baseLength * height;
    }

    public override double Perimeter() {
        Console.WriteLine("Периметр параллелограмма не определен без длины сторон.");
        return 0;
    }
}

class Trapezoid : GeometricFigure {
    private double base1, base2, height;

    public Trapezoid(double b1, double b2, double h) {
        base1 = b1;
        base2 = b2;
        height = h;
    }

    public override double Area() {
        return ((base1 + base2) * height) / 2;
    }

    public override double Perimeter() {
        Console.WriteLine("Периметр трапеции не определен без длин боковых сторон.");
        return 0;
    }
}

class Circle : GeometricFigure {
    private double radius;

    public Circle(double radius) {
        this.radius = radius;
    }

    public override double Area() {
        return Math.PI * radius * radius;
    }

    public override double Perimeter() {
        return 2 * Math.PI * radius;
    }
}

class Ellipse : GeometricFigure {
    private double semiMajorAxis, semiMinorAxis;

    public Ellipse(double a, double b) {
        semiMajorAxis = a;
        semiMinorAxis = b;
    }

    public override double Area() {
        return Math.PI * semiMajorAxis * semiMinorAxis;
    }

    public override double Perimeter() {
        Console.WriteLine("Периметр эллипса не имеет простой формулы.");
        return 0;
    }
}

class CompositeFigure {
    private List<GeometricFigure> figures = new List<GeometricFigure>();

    public void AddFigure(GeometricFigure figure) {
        figures.Add(figure);
    }

    public double TotalArea() {
        double totalArea = 0;
        foreach (var figure in figures) {
            totalArea += figure.Area();
        }
        return totalArea;
    }
}

abstract class Product {
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Status { get; set; } = "Пришло";

    public virtual void ChangeStatus(string newStatus) {
        Status = newStatus;
    }
}

class HouseholdChemicals : Product {
    public string ChemicalType { get; set; }

    public HouseholdChemicals(string name, decimal price, string chemicalType) {
        Name = name;
        Price = price;
        ChemicalType = chemicalType;
    }
}

class FoodProducts : Product {
    public DateTime ExpiryDate { get; set; }

    public FoodProducts(string name, decimal price, DateTime expiryDate) {
        Name = name;
        Price = price;
        ExpiryDate = expiryDate;
    }
}

class ProductFlowManager {
    private List<Product> products = new List<Product>();

    public void AddProduct(Product product) {
        products.Add(product);
    }

    public void ChangeProductStatus(string productName, string newStatus) {
        var product = products.FirstOrDefault(p => p.Name == productName);
        if (product != null) {
            product.ChangeStatus(newStatus);
        } else {
            Console.WriteLine("Товар не найден.");
        }
    }

    public void PrintAllProducts() {
        foreach (var product in products) {
            Console.WriteLine($"Товар: {product.Name}, Статус: {product.Status}");
        }
    }
}

class Program {
    static void Main() {
        var compositeFigure = new CompositeFigure();
        compositeFigure.AddFigure(new Circle(5));
        compositeFigure.AddFigure(new Square(4));
        Console.WriteLine($"Общая площадь составной фигуры: {compositeFigure.TotalArea()}");

        var manager = new ProductFlowManager();
        var detergent = new HouseholdChemicals("Detergent", 100, "Cleaning Agent");
        var milk = new FoodProducts("Milk", 50, DateTime.Now.AddDays(7));

        manager.AddProduct(detergent);
        manager.AddProduct(milk);

        manager.ChangeProductStatus("Detergent", "Реализовано");
        manager.PrintAllProducts();
    }
}