using BakeryConsoleApp.Models;

namespace BakeryConsoleApp.Services;

public class ClientService
{
    private readonly List<Client> _clients = new();
    private int _nextId = 1;

    public Client AddClient(string name, string phoneNumber)
{
    if (!IsValidName(name))
    {
        throw new ArgumentException(
            "Client name must contain at least 2 characters and not be empty."
        );
    }

    if (!IsValidPhoneNumber(phoneNumber))
    {
        throw new ArgumentException(
            "Phone number must contain 8–15 digits and only numbers."
        );
    }

    var client = new Client
    {
        Id = _nextId++,
        Name = name.Trim(),
        PhoneNumber = phoneNumber
    };

    _clients.Add(client);
    return client;
}

private bool IsValidName(string name)
{
    if (string.IsNullOrWhiteSpace(name))
        return false;

    var trimmedName = name.Trim();

    return trimmedName.Length >= 2;
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
