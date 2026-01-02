using BakeryConsoleApp.Models;

namespace BakeryConsoleApp.Services;

public class ClientService
{
    private readonly List<Client> _clients = new();
    private int _nextId = 1;

    public Client AddClient(string name, string phoneNumber)
{
    if (string.IsNullOrWhiteSpace(name))
    {
        throw new ArgumentException("Client name cannot be empty.");
    }

    if (!IsValidPhoneNumber(phoneNumber))
    {
        throw new ArgumentException("Invalid phone number format.");
    }

    var client = new Client
    {
        Id = _nextId++,
        Name = name,
        PhoneNumber = phoneNumber
    };

    _clients.Add(client);
    return client;
}
private bool IsValidPhoneNumber(string phoneNumber)
{
    if (string.IsNullOrWhiteSpace(phoneNumber))
        return false;

    var digitsOnly = phoneNumber.All(char.IsDigit);

    return digitsOnly && phoneNumber.Length >= 8 && phoneNumber.Length <= 15;
}

    public IReadOnlyList<Client> GetAllClients()
    {
        return _clients;
    }
}
