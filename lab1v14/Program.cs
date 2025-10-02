using System;

class Figure
{
    // Поля
    private string name;
    private int sides;

    // Властивості
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Sides
    {
        get { return sides; }
        set { sides = value; }
    }

    // Конструктор
    public Figure(string name, int sides)
    {
        this.name = name;
        this.sides = sides;
        Console.WriteLine($"Створено фігуру {name} з {sides} сторонами.");
    }

    // Метод
    public void ShowInfo()
    {
        Console.WriteLine($"Фігура: {name}, Кількість сторін: {sides}");
    }

    // Деструктор
    ~Figure()
    {
        Console.WriteLine($"Об'єкт {name} знищено.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення об’єктів
        Figure triangle = new Figure("Трикутник", 3);
        Figure square = new Figure("Квадрат", 4);
        Figure pentagon = new Figure("П’ятикутник", 5);

        // Виклик методів
        triangle.ShowInfo();
        square.ShowInfo();
        pentagon.ShowInfo();

        Console.WriteLine("Програма завершила роботу.");
    }
}
