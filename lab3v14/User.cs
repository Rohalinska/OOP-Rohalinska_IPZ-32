using System;

class User
{
    public string Login { get; set; }
    public int OperationsCount { get; protected set; }  // кількість виконаних операцій

    public User(string login)
    {
        Login = login;
        OperationsCount = 0;
    }

    // Віртуальний метод для виконання операції
    public virtual void DoOperation()
    {
        OperationsCount++;
        Console.WriteLine($"{Login} виконав операцію. Загалом: {OperationsCount}");
    }

    // Метод для відображення інформації про користувача
    public virtual void ShowInfo()
    {
        Console.WriteLine($"Користувач {Login}, операцій: {OperationsCount}");
    }
}
