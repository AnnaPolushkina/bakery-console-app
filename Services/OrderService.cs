using BakeryConsoleApp.Models;

namespace BakeryConsoleApp.Services;

public class OrderService
{
    private readonly List<Order> _orders = new();
    private int _nextId = 1;

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
        return order;
    }

    public IReadOnlyList<Order> GetOrdersByClient(int clientId)
    {
        return _orders.Where(o => o.ClientId == clientId).ToList();
    }
}
