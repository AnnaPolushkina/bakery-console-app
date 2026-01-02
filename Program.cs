using BakeryConsoleApp.Services;

var clientService = new ClientService();
var orderService = new OrderService();

while (true)
{
    Console.WriteLine();
    Console.WriteLine("=== Bakery Console App ===");
    Console.WriteLine("1. Add client");
    Console.WriteLine("2. Show all clients");
    Console.WriteLine("3. Add order");
    Console.WriteLine("4. Show orders by client");
    Console.WriteLine("0. Exit");
    Console.Write("Choose an option: ");


    var choice = Console.ReadLine();

    if (choice == "0")
    {
        break;
    }

    if (choice == "1")
    {
        bool clientAdded = false;

        while (!clientAdded)
        {
            Console.Write("Enter client name: ");
            var name = Console.ReadLine();

            Console.Write("Enter phone number: ");
            var phone = Console.ReadLine();

            try
            {
                var client = clientService.AddClient(name!, phone!);
                Console.WriteLine($"Client added with ID: {client.Id}");
                clientAdded = true;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("Please try again.\n");
            }
        }

        continue;
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

        continue;
    }

    if (choice == "3")
{
    Console.Write("Enter client ID: ");
    var clientIdInput = Console.ReadLine();

    if (!int.TryParse(clientIdInput, out int clientId))
    {
        Console.WriteLine("Invalid client ID.");
        continue;
    }

    var clients = clientService.GetAllClients();
    if (!clients.Any(c => c.Id == clientId))
    {
        Console.WriteLine("Client not found.");
        continue;
    }

    Console.Write("Enter order total price: ");
    var priceInput = Console.ReadLine();

    if (!decimal.TryParse(priceInput, out decimal totalPrice))
    {
        Console.WriteLine("Invalid price.");
        continue;
    }

    try
    {
        var order = orderService.AddOrder(clientId, totalPrice);
        Console.WriteLine($"Order added with ID: {order.Id}");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    continue;
}

if (choice == "4")
{
    Console.Write("Enter client ID: ");
    var clientIdInput = Console.ReadLine();

    if (!int.TryParse(clientIdInput, out int clientId))
    {
        Console.WriteLine("Invalid client ID.");
        continue;
    }

    var orders = orderService.GetOrdersByClient(clientId);

    if (orders.Count == 0)
    {
        Console.WriteLine("No orders found for this client.");
        continue;
    }

    foreach (var order in orders)
    {
        Console.WriteLine(
            $"Order {order.Id}: Date: {order.OrderDate}, Total={order.TotalPrice}"
        );
    }

    continue;
}

    Console.WriteLine("Unknown option. Please try again.");
}


