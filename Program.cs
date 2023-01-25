using Exam.Enums;
using Exam.Models;
using Task = Exam.Models.Task;
using Exam.Interfaces;
using Exam.DataManagement;

public class Program
{
    public static Supermarket supermarket;
    public static IDataManager dataManager;

    public static void Main()
    {
        dataManager = new SaveData();
        supermarket = dataManager.Load();

        Run();

        supermarket.ShowEmployeesTasks();
    }

    public static void Run()
    {
        AddSupermarket();

        AdministratorMenu();

        string userInput = Console.ReadLine();

        while (userInput.ToLower() != "end" && userInput != "5")
        {
            try
            {
                int choice = int.Parse(userInput);
                if (choice == 1)
                {
                    Console.WriteLine("Add an employee!");
                    Console.WriteLine("To go to menu type down \"DONE\"");
                    string[] information = Console.ReadLine().Split(",").ToArray();

                    while (information[0].ToLower() != "done")
                    {
                        if (information.Length > 1)
                        {
                            string check = information[0] + information[1];

                            if (!check.Any(l => char.IsDigit(l)))
                            {
                                AddEmployee(information);
                                dataManager.Save(supermarket);
                            }
                            else
                            {
                                Console.WriteLine("Invalid parameters!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid command or parameters!");
                        }

                        information = Console.ReadLine().Split(",").ToArray();
                    }

                    AdministratorMenu();
                }
                else if (choice == 2)
                {
                    if (supermarket.Employees.Count != 0)
                    {
                        Console.WriteLine("Assign a task to employee!");
                        Console.WriteLine("To go to menu type down \"DONE\"");
                        string[] information = Console.ReadLine().Split(",").ToArray();

                        while (information[0].ToLower() != "done")
                        {
                            string check = information[0];

                            if (information.Length > 1 && !check.Any(l => char.IsDigit(l)))
                            {
                                AssignTask(information);
                                dataManager.Save(supermarket);
                            }
                            else
                            {
                                Console.WriteLine("Invalid command or parameters!");
                            }

                            information = Console.ReadLine().Split(",").ToArray();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Employees haven't been added yet!");
                    }

                    AdministratorMenu();
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Add a client!");
                    Console.WriteLine("To go to menu type down \"DONE\"");
                    string[] information = Console.ReadLine().Split(",").ToArray();

                    while (information[0].ToLower() != "done")
                    {
                        if (information.Length > 1)
                        {
                            string check = information[0] + information[1];

                            if (!check.Any(l => char.IsDigit(l)))
                            {
                                AddClient(information);
                                dataManager.Save(supermarket);
                            }
                            else
                            {
                                Console.WriteLine("Invalid parameters!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid command or parameters!");
                        }

                        information = Console.ReadLine().Split(",").ToArray();
                    }

                    AdministratorMenu();
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Add a product!");
                    Console.WriteLine("To go to menu type down \"DONE\"");
                    string[] information = Console.ReadLine().Split(",").ToArray();

                    while (information[0].ToLower() != "done")
                    {
                        string check = information[0];

                        if (information.Length > 1 && !check.Any(l => char.IsDigit(l)))
                        {
                            AddProduct(information);
                            dataManager.Save(supermarket);
                        }
                        else
                        {
                            Console.WriteLine("Invalid command or parameters!");
                        }

                        information = Console.ReadLine().Split(",").ToArray();
                    }

                    AdministratorMenu();
                }
                else
                {
                    Console.WriteLine($"Invalid command \"{userInput}\"!");
                }

                userInput = Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine($"Invalid command \"{userInput}\"!");
                userInput = Console.ReadLine();
            }
        }
    }

    private static void AddSupermarket()
    {
        if (supermarket != null)
        {
            Console.WriteLine($"WELCOME TO {supermarket.Name.ToUpper()}");
        }
        else
        {
            Console.WriteLine("Please enter supermarket name:");
            string name = Console.ReadLine();
            supermarket = new Supermarket(name);
        }
    }

    private static void AddEmployee(string[] information)
    {
        if (information.Length != 5)
        {
            Console.WriteLine("Adding an employee unseccessful!");
            Console.WriteLine("Input in format: \"Name\" \"Last name\" \"Working position\" \"Salary\" \"Years of experience\"");
        }
        else
        {
            Employee employee = new Employee(information[0], information[1], information[2], decimal.Parse(information[3]), int.Parse(information[4]));
            supermarket.Employees.Add(employee);

            Console.WriteLine($"{employee.Name} {employee.LastName} was successfully added as an employee!");
        }
    }

    private static void AssignTask(string[] information)
    {
        if (information.Length != 4)
        {
            Console.WriteLine("Assigning a task to an employee unseccessful!");
            Console.WriteLine("Input in format: \"Employee Name\" \"Task name\" \"Task Description\" \"Deadline\"");
        }
        else
        {
            string employeeName = information[0].Split(" ")[0];
            string employeeLastName = information[0].Split(" ")[1];
            Employee employee = supermarket.Employees.FirstOrDefault(e => e.Name == employeeName && e.LastName == employeeLastName);

            if (employee != null)
            {
                Task task = new Task(information[1], information[2], information[3]);
                employee.Tasks.Add(task);

                Console.WriteLine($"Task was successfully assigned to {employee}.");
            }
            else
            {
                Console.WriteLine($"Employee {employeeName} {employeeLastName} doesn't exists in the database!");
            }
        }
    }

    private static void AddClient(string[] information)
    {
        if (information.Length != 3)
        {
            Console.WriteLine("Adding a client unseccessful!");
            Console.WriteLine("Input in format: \"Name\" \"Last name\" \"Unique number\"!");
        }
        else if (supermarket.Clients.Exists(c => c.UniqueNumber == int.Parse(information[2])))
        {
            Console.WriteLine("Client with that number already exists!");
            Console.WriteLine("Input another serial number!");
            information[2] = Console.ReadLine();
            AddClient(information);
        }
        else
        {
            Client client = new Client(information[0], information[1], int.Parse(information[2]));
            client.Status = ClientStatus.Ordinary;
            supermarket.Clients.Add(client);

            Console.WriteLine($"{client.Name} {client.LastName} was successfully added as a client!");
            Console.WriteLine($"-- Generate a Loyal Card for {client.Name} {client.LastName}?");
            ChoiceMenu();

            string input = Console.ReadLine();
            while (true)
            {
                try
                {
                    int choice = int.Parse(input);
                    if (choice < 1 || choice > 2)
                    {
                        Console.WriteLine($"Invalid command \"{input}\"!");
                    }
                    else if (choice == 1)
                    {
                        GenerateLoyalCard(client);
                        break;
                    }
                    else
                    {
                        break;
                    }

                    input = Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine($"Invalid command \"{input}\"!");
                    input = Console.ReadLine();
                }
            }
        }
    }

    private static void GenerateLoyalCard(Client client)
    {
        LoyalCard loyalCard = new LoyalCard()
        {
            Info = $"{client.Name} {client.LastName}",
            CardNumber = client.UniqueNumber,
            Products = client.Products,
        };

        client.LoyalCard = loyalCard;
        client.Status = ClientStatus.Loyal;
        supermarket.LoyalCards.Add(loyalCard);

        Console.WriteLine($"Loyal card was successfully generated for {client}");
    }

    private static void AddProduct(string[] information)
    {
        if (information.Length != 5)
        {
            Console.WriteLine("Adding a product unseccessful!");
            Console.WriteLine("Input in format: \"Name\" \"Price\" \"Quantity\" \"Expire Date\" \"Category\"!");
        }
        else
        {
            Product product = new Product(information[0], decimal.Parse(information[1]), int.Parse(information[2]), information[3], information[4]);
            supermarket.Products.Add(product);

            Console.WriteLine($"{product.Name} was successfully added as product");
        }
    }

    private static void ChoiceMenu()
    {
        Console.WriteLine("1.Yes");
        Console.WriteLine("2.No");
    }

    private static void AdministratorMenu()
    {
        Console.WriteLine("1.Add Employee.");
        Console.WriteLine("2.Assing tasks.");
        Console.WriteLine("3.Add Client.");
        Console.WriteLine("4.Add Product.");
        Console.WriteLine("5.Exit.");
    }
}