using BakeryConsoleApp.Services;

var clientService = new ClientService();
while (true)
{
    Console.WriteLine();
    Console.WriteLine("=== Bakery Console App ===");
    Console.WriteLine("1. Add client");
    Console.WriteLine("2. Show all clients");
    Console.WriteLine("0. Exit");
    Console.Write("Choose an option: ");

    var choice = Console.ReadLine();

    if (choice == "1")
{
    Console.Write("Enter client name: ");
    var name = Console.ReadLine();

    Console.Write("Enter phone number: ");
    var phone = Console.ReadLine();

    try
{
    var client = clientService.AddClient(name!, phone!);
    Console.WriteLine($"Client added with ID: {client.Id}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
    
}

if (choice == "2")
{
    var clients = clientService.GetAllClients();

    if (clients.Count == 0)
    {
        Console.WriteLine("No clients found.");
        continue;
    }

    foreach (var client in clients)
    {
        Console.WriteLine($"{client.Id}: {client.Name} ({client.PhoneNumber})");
    }
}

    if (choice == "0")
    {
        break;
    }
}

