<Query Kind="Statements" />

using System.Text;

Console.OutputEncoding = Encoding.UTF8;

DateTime today = DateTime.Today;

var firms = new List<Firm>
{
    new Firm("Green Food", today.AddYears(-5), "Marketing", "Brown Alex Peter", 120, "London, Oxford St 10")
    {
        Employees =
        {
            new Employee("Messi Lionel Andres", "Manager", "2301112", "dimitri@greenfood.com", 3200),
            new Employee("Ivanov Ivan Petrovich", "Designer", "5551234", "ivan@greenfood.com", 1800),
        }
    },
    new Firm("White Marketing Group", today.AddYears(-1), "Marketing", "Black Michael John", 250, "Manchester, Main St 5")
    {
        Employees =
        {
            new Employee("Smith Anna Maria", "Manager", "2345678", "anna@wmg.com", 2900),
            new Employee("Stone Peter Paul", "Analyst", "4449876", "diana@wmg.com", 2100),
        }
    },
    new Firm("TechNova", today.AddYears(-8), "IT", "White Helen Rose", 500, "London, Fleet St 7")
    {
        Employees =
        {
            new Employee("Johnson Mark Leo", "Developer", "2398765", "mark@technova.com", 4500),
            new Employee("Taylor Emma Jane", "Manager", "7771122", "dina@technova.com", 3800),
            new Employee("Costa Lionel Pedro", "Tester", "3334455", "lionel@technova.com", 2200),
        }
    },
    new Firm("Food Planet", today.AddDays(-123), "Food", "Green Peter Paul", 80, "Leeds, Park Rd 3")
    {
        Employees =
        {
            new Employee("Miller Oleg Ivanovich", "Manager", "2200011", "oleg@foodplanet.com", 1900),
        }
    },
    new Firm("SoftWave", today.AddYears(-3), "IT", "Black Anna Maria", 300, "Bristol, River St 12")
    {
        Employees =
        {
            new Employee("Brown Kate Sophie", "Developer", "2310099", "kate@softwave.com", 4200),
            new Employee("Davis Dmitry Igorevich", "Manager", "9998877", "dimon@softwave.com", 3100),
        }
    },
    new Firm("Quick Food Service", today.AddYears(-10), "Marketing", "White David Alan", 150, "London, Strand 22")
    {
        Employees =
        {
            new Employee("Wilson Lionel Dave", "Manager", "2350000", "diego@quickfood.com", 3500),
        }
    },
    new Firm("DataLine", today.AddMonths(-6), "IT", "Taylor Emma Jane", 45, "Oxford, High St 8")
    {
        Employees =
        {
            new Employee("Clark John Alan", "Developer", "6667788", "john@dataline.com", 3000),
        }
    },
    new Firm("BuildPro", today.AddYears(-2).AddDays(-10), "Construction", "Evans Tom Robert", 700, "London, Bridge St 1")
    {
        Employees =
        {
            new Employee("Hughes Sam Victor", "Foreman", "8885544", "sam@buildpro.com", 2600),
        }
    },
};

Header("ЗАВДАННЯ 1 (синтаксис запитів)");

var q1 = from f in firms select f;
Show("Усі фірми", q1);

var q2 = from f in firms where f.Name.Contains("Food") select f;
Show("Назва містить Food", q2);

var q3 = from f in firms where f.Business == "Marketing" select f;
Show("Маркетинг", q3);

var q4 = from f in firms where f.Business == "Marketing" || f.Business == "IT" select f;
Show("Маркетинг або IT", q4);

var q5 = from f in firms where f.EmployeeCount > 100 select f;
Show("Більше 100 співробітників", q5);

var q6 = from f in firms where f.EmployeeCount >= 100 && f.EmployeeCount <= 300 select f;
Show("Від 100 до 300 співробітників", q6);

var q7 = from f in firms where f.Address.Contains("London") select f;
Show("Знаходяться в Лондоні", q7);

var q8 = from f in firms where f.DirectorSurname == "White" select f;
Show("Прізвище директора White", q8);

var q9 = from f in firms where f.Founded < today.AddYears(-2) select f;
Show("Засновані більше двох років тому", q9);

var q10 = from f in firms where (today - f.Founded.Date).Days == 123 select f;
Show("Минуло рівно 123 дні з дня заснування", q10);

var q11 = from f in firms
          where f.DirectorSurname == "Black" && f.Name.Contains("White")
          select f;
Show("Директор Black і в назві White", q11);

Header("ЗАВДАННЯ 2 (методи розширення)");

Show("Усі фірми", firms.Select(f => f));
Show("Назва містить Food", firms.Where(f => f.Name.Contains("Food")));
Show("Маркетинг", firms.Where(f => f.Business == "Marketing"));
Show("Маркетинг або IT", firms.Where(f => f.Business == "Marketing" || f.Business == "IT"));
Show("Більше 100 співробітників", firms.Where(f => f.EmployeeCount > 100));
Show("Від 100 до 300 співробітників", firms.Where(f => f.EmployeeCount >= 100 && f.EmployeeCount <= 300));
Show("Знаходяться в Лондоні", firms.Where(f => f.Address.Contains("London")));
Show("Прізвище директора White", firms.Where(f => f.DirectorSurname == "White"));
Show("Засновані більше двох років тому", firms.Where(f => f.Founded < today.AddYears(-2)));
Show("Минуло рівно 123 дні з дня заснування", firms.Where(f => (today - f.Founded.Date).Days == 123));
Show("Директор Black і в назві White", firms.Where(f => f.DirectorSurname == "Black" && f.Name.Contains("White")));

Header("ЗАВДАННЯ 3 (співробітники)");

string firmName = "TechNova";
decimal minSalary = 3000;

var e1 = from f in firms
         where f.Name == firmName
         from e in f.Employees
         select e;
Show($"Усі співробітники фірми {firmName}", e1);

var e2 = from f in firms
         where f.Name == firmName
         from e in f.Employees
         where e.Salary > minSalary
         select e;
Show($"Співробітники {firmName} із зарплатою більше {minSalary}", e2);

var e3 = from f in firms
         from e in f.Employees
         where e.Position == "Manager"
         select e;
Show("Менеджери всіх фірм", e3);

var e4 = from f in firms
         from e in f.Employees
         where e.Phone.StartsWith("23")
         select e;
Show("Телефон починається з 23", e4);

var e5 = from f in firms
         from e in f.Employees
         where e.Email.StartsWith("di")
         select e;
Show("Email починається з di", e5);

var e6 = from f in firms
         from e in f.Employees
         where e.FirstName == "Lionel"
         select e;
Show("Ім'я Lionel", e6);

Header("ЗАВДАННЯ 4 (сортування за сумою цифр)");

int[] numbers = { 121, 75, 81, 456, 9, 100, 39, 1999 };
Console.WriteLine("Вихідний масив: " + string.Join(", ", numbers));

var ascending = from n in numbers
                orderby Helpers.DigitSum(n)
                select n;
var descending = from n in numbers
                 orderby Helpers.DigitSum(n) descending
                 select n;

Console.WriteLine("За зростанням суми цифр: " +
    string.Join(", ", ascending.Select(n => $"{n}({Helpers.DigitSum(n)})")));
Console.WriteLine("За спаданням суми цифр:  " +
    string.Join(", ", descending.Select(n => $"{n}({Helpers.DigitSum(n)})")));

static void Header(string text)
{
    Console.WriteLine();
    Console.WriteLine(new string('=', 60));
    Console.WriteLine(text);
    Console.WriteLine(new string('=', 60));
}

static void Show<T>(string title, IEnumerable<T> items)
{
    Console.WriteLine();
    Console.WriteLine($"--- {title} ---");
    var list = items.ToList();
    if (list.Count == 0)
    {
        Console.WriteLine("(нічого не знайдено)");
        return;
    }
    foreach (var item in list)
        Console.WriteLine(item);
}

class Employee
{
    public string FullName { get; }  
    public string Position { get; }
    public string Phone { get; }
    public string Email { get; }
    public decimal Salary { get; }

    public string FirstName => FullName.Split(' ', StringSplitOptions.RemoveEmptyEntries).ElementAtOrDefault(1) ?? "";

    public Employee(string fullName, string position, string phone, string email, decimal salary)
    {
        FullName = fullName;
        Position = position;
        Phone = phone;
        Email = email;
        Salary = salary;
    }

    public override string ToString() =>
        $"{FullName}, {Position}, тел. {Phone}, {Email}, зарплата {Salary}";
}

class Firm
{
    public string Name { get; }
    public DateTime Founded { get; }
    public string Business { get; }     
    public string Director { get; }       
    public int EmployeeCount { get; }
    public string Address { get; }
    public List<Employee> Employees { get; } = new();

    public string DirectorSurname => Director.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];

    public Firm(string name, DateTime founded, string business, string director, int employeeCount, string address)
    {
        Name = name;
        Founded = founded;
        Business = business;
        Director = director;
        EmployeeCount = employeeCount;
        Address = address;
    }

    public override string ToString() =>
        $"{Name} | заснована {Founded:dd.MM.yyyy} | {Business} | директор {Director} | " +
        $"співробітників: {EmployeeCount} | {Address}";
}

static class Helpers
{
    public static int DigitSum(int n)
    {
        n = Math.Abs(n);
        int sum = 0;
        while (n > 0)
        {
            sum += n % 10;
            n /= 10;
        }
        return sum;
    }
}