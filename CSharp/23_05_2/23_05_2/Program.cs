using System;
using System.Collections.Generic;

abstract class Storage {
    private string name;
    private string model;

    public string Name {
        get { return name; }
        set { name = value; }
    }

    public string Model {
        get { return model; }
        set { model = value; }
    }

    public Storage(string name, string model) {
        this.name = name;
        this.model = model;
    }

    public abstract double GetMemory();
    public abstract void CopyData(double dataSize);
    public abstract double GetFreeMemory();
    public abstract string GetInfo();
    public abstract double GetCopyTime(double dataSize);
}

class Flash : Storage {
    public double UsbSpeed { get; set; }
    public double Capacity { get; set; }
    private double used;

    public Flash(string name, string model, double usbSpeed, double capacity)
        : base(name, model) {
        UsbSpeed = usbSpeed;
        Capacity = capacity;
        used = 0;
    }

    public override double GetMemory() {
        return Capacity;
    }

    public override void CopyData(double dataSize) {
        used = Math.Min(used + dataSize, Capacity);
    }

    public override double GetFreeMemory() {
        return Capacity - used;
    }

    public override string GetInfo() {
        return $"Flash: {Name}, {Model}, USB: {UsbSpeed} MB/s, Capacity: {Capacity} MB";
    }

    public override double GetCopyTime(double dataSize) {
        return dataSize / UsbSpeed;
    }
}

class DVD : Storage {
    public double Speed { get; set; }
    public bool DoubleSided { get; set; }
    private double capacity;
    private double used;

    public DVD(string name, string model, double speed, bool doubleSided)
        : base(name, model) {
        Speed = speed;
        DoubleSided = doubleSided;
        capacity = doubleSided ? 9000 : 4700;
        used = 0;
    }

    public override double GetMemory() {
        return capacity;
    }

    public override void CopyData(double dataSize) {
        used = Math.Min(used + dataSize, capacity);
    }

    public override double GetFreeMemory() {
        return capacity - used;
    }

    public override string GetInfo() {
        return $"DVD: {Name}, {Model}, Speed: {Speed} MB/s, Capacity: {capacity} MB";
    }

    public override double GetCopyTime(double dataSize) {
        return dataSize / Speed;
    }
}

class HDD : Storage {
    public double UsbSpeed { get; set; }
    public int Partitions { get; set; }
    public double PartitionSize { get; set; }
    private double used;

    public HDD(string name, string model, double usbSpeed, int partitions, double partitionSize)
        : base(name, model) {
        UsbSpeed = usbSpeed;
        Partitions = partitions;
        PartitionSize = partitionSize;
        used = 0;
    }

    public override double GetMemory() {
        return Partitions * PartitionSize;
    }

    public override void CopyData(double dataSize) {
        used = Math.Min(used + dataSize, GetMemory());
    }

    public override double GetFreeMemory() {
        return GetMemory() - used;
    }

    public override string GetInfo() {
        return $"HDD: {Name}, {Model}, USB: {UsbSpeed} MB/s, Total: {GetMemory()} MB";
    }

    public override double GetCopyTime(double dataSize) {
        return dataSize / UsbSpeed;
    }
}

class Program {
    static List<Storage> devices = new List<Storage>() {
        new Flash("Kingston", "DataTraveler", 150, 32000),
        new DVD("Sony", "DVD-R", 10, false),
        new HDD("WD", "Elements", 60, 4, 50000)
    };

    static double totalData = 565000;
    static double fileSize = 780;

    static void Main() {
        while (true) {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Расчет общего объема памяти всех устройств");
            Console.WriteLine("2. Копирование информации на устройства");
            Console.WriteLine("3. Расчет времени необходимого для копирования");
            Console.WriteLine("4. Расчет необходимого количества носителей");
            Console.WriteLine("0. Выход");
            Console.Write("> ");

            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input) {
                case "1":
                    CalculateTotalMemory();
                    break;
                case "2":
                    CopyDataToDevices();
                    break;
                case "3":
                    CalculateCopyTime();
                    break;
                case "4":
                    CalculateNeededDevices();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Неверный ввод. Повторите попытку.");
                    break;
            }
        }
    }

    static void CalculateTotalMemory() {
        double total = 0;
        foreach (var device in devices) {
            total += device.GetMemory();
        }
        Console.WriteLine($"Общий объем памяти всех устройств: {total} МБ");
    }

    static void CopyDataToDevices() {
        double remainingData = totalData;
        foreach (var device in devices) {
            while (remainingData > 0 && device.GetFreeMemory() >= fileSize) {
                device.CopyData(fileSize);
                remainingData -= fileSize;
            }
        }

        Console.WriteLine($"Осталось не перенесенных данных: {remainingData} МБ");
        foreach (var device in devices) {
            Console.WriteLine(device.GetInfo());
            Console.WriteLine($"Свободно: {device.GetFreeMemory()} МБ\n");
        }
    }

    static void CalculateCopyTime() {
        double remainingData = totalData;
        double time = 0;

        foreach (var device in devices) {
            while (remainingData > 0 && device.GetFreeMemory() >= fileSize) {
                device.CopyData(fileSize);
                remainingData -= fileSize;
                time += device.GetCopyTime(fileSize);
            }
        }

        Console.WriteLine($"Общее время копирования: {time:F2} секунд");
    }

    static void CalculateNeededDevices() {
        foreach (var device in devices) {
            int count = (int)Math.Ceiling(totalData / device.GetMemory());
            Console.WriteLine($"{device.GetType().Name}: необходимо {count} устройств для переноса 565 ГБ");
        }
    }
}
