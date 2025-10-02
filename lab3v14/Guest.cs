using System;

class Guest : User
{
    public Guest(string login) : base(login) { }

    public override void DoOperation()
    {
        OperationsCount++;
        Console.WriteLine($"[GUEST] {Login} виконав гостьову операцію. Загалом: {OperationsCount}");
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"[GUEST] {Login}, операцій: {OperationsCount}");
    }
}
