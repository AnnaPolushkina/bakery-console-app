using BakeryConsoleApp.Models;

namespace BakeryConsoleApp.Services;

public class ClientService
{
    private readonly List<Client> _clients = new();
    private int _nextId = 1;

    public Client AddClient(string name, string phoneNumber)
    {
        var client = new Client
        {
            Id = _nextId++,
            Name = name,
            PhoneNumber = phoneNumber
        };

        _clients.Add(client);
        return client;
    }

    public IReadOnlyList<Client> GetAllClients()
    {
        return _clients;
    }
}
