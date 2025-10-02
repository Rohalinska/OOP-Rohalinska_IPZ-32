using System;

class Admin : User
{
    public Admin(string login) : base(login) { }

    // Перевизначення методу виконання операції
    public override void DoOperation()
    {
        OperationsCount += 2; // адмін виконує відразу дві операції
        Console.WriteLine($"[ADMIN] {Login} виконав адмін-операції. Загалом: {OperationsCount}");
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"[ADMIN] {Login}, операцій: {OperationsCount}");
    }
}
