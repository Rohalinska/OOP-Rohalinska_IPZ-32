
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Створюємо колекцію користувачів (поліморфізм!)
        List<User> users = new List<User>
        {
            new Admin("SuperAdmin"),
            new Guest("Guest123"),
            new User("RegularUser")
        };

        // Виконуємо кілька операцій
        users[0].DoOperation();
        users[1].DoOperation();
        users[1].DoOperation();
        users[2].DoOperation();

        Console.WriteLine("\n--- Інформація про всіх користувачів ---");
        foreach (var u in users)
        {
            u.ShowInfo();
        }

        // Знаходимо найактивнішого
        User mostActive = FindMostActive(users);
        Console.WriteLine($"\nНайактивніший користувач: {mostActive.Login}, операцій: {mostActive.OperationsCount}");
    }

    // Метод для знаходження користувача з найбільшою активністю
    static User FindMostActive(List<User> users)
    {
        User maxUser = users[0];
        foreach (var u in users)
        {
            if (u.OperationsCount > maxUser.OperationsCount)
                maxUser = u;
        }
        return maxUser;
    }
}
