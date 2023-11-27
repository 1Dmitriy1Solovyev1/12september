using System;

// Базовый класс для сотрудника
class Employee
{
    public string Name { get; set; }

    // Виртуальный метод приветствия, который может быть переопределен в подклассах
    public virtual void Greet()
    {
        Console.WriteLine($"Привет, {Name}!");
    }
}

// Подкласс Worker, наследующий от Employee
class Worker : Employee
{
    // Переопределенный метод приветствия для рабочего
    public override void Greet()
    {
        Console.WriteLine($"Привет, друг {Name}!");
    }
}

// Подкласс Manager, наследующий от Worker
class Manager : Worker
{
    // Дополнительное свойство, указывающее на количество подчиненных
    public int NumberOfSubordinates { get; set; }

    // Переопределенный метод приветствия для менеджера
    public override void Greet()
    {
        Console.WriteLine($"Здравствуйте, {Name}, у вас {NumberOfSubordinates} работников.");
    }
}

// Подкласс Boss, наследующий от Manager
class Boss : Manager
{
    // Метод увольнения всех сотрудников
    public void FireEveryone()
    {
        Console.WriteLine("Слава нашему боссу!");
        // Дополнительные действия для Boss
    }
}

// Основной класс программы
class Program
{
    // Точка входа в программу
    static void Main()
    {
        // Создание объектов различных типов сотрудников
        Employee employee = new Employee { Name = "Иван" };
        Worker worker = new Worker { Name = "Петр" };
        Manager manager = new Manager { Name = "Анна", NumberOfSubordinates = 10 };
        Boss boss = new Boss { Name = "Владимир", NumberOfSubordinates = 100 };

        // Вызов метода приветствия для каждого сотрудника с использованием оператора switch
        GreetEmployee(employee);
        GreetEmployee(worker);
        GreetEmployee(manager);
        GreetEmployee(boss);
    }

    // Метод, использующий оператор switch для вызова соответствующего метода приветствия
    static void GreetEmployee(Employee emp)
    {
        switch (emp)
        {
            case Worker worker when worker != null:
                worker.Greet();
                break;
            case Manager manager when manager != null:
                manager.Greet();
                break;
            case Boss boss when boss != null:
                boss.Greet();
                boss.FireEveryone();
                break;
            default:
                Console.WriteLine("А вы, вообще, КТО???");
                break;
        }
    }
}