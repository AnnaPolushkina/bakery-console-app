using BakeryConsoleApp.Models;
using System.Text.Json;


namespace BakeryConsoleApp.Services;

public class OrderService
{
    private const string FilePath = "orders.json";
    private readonly List<Order> _orders = new();
    private int _nextId = 1;

    public OrderService()
{
    LoadFromFile();
}

private void LoadFromFile()
{
    if (!File.Exists(FilePath))
        return;

    var json = File.ReadAllText(FilePath);
    var loadedOrders = JsonSerializer.Deserialize<List<Order>>(json);

    if (loadedOrders is null)
        return;

    _orders.AddRange(loadedOrders);

    if (_orders.Count > 0)
    {
        _nextId = _orders.Max(o => o.Id) + 1;
    }
}

    public Order AddOrder(int clientId, decimal totalPrice)
    {
        if (clientId <= 0)
        {
            throw new ArgumentException("Invalid client ID.");
        }

        if (totalPrice <= 0)
        {
            throw new ArgumentException("Order total price must be greater than zero.");
        }

        var order = new Order
        {
            Id = _nextId++,
            ClientId = clientId,
            OrderDate = DateTime.Now,
            TotalPrice = totalPrice
        };

        _orders.Add(order);
        SaveToFile();
        return order;
    }

private void SaveToFile()
{
    var json = JsonSerializer.Serialize(_orders, new JsonSerializerOptions
    {
        WriteIndented = true
    });

    File.WriteAllText(FilePath, json);
}

    public IReadOnlyList<Order> GetOrdersByClient(int clientId)
    {
        return _orders.Where(o => o.ClientId == clientId).ToList();
    }
}
