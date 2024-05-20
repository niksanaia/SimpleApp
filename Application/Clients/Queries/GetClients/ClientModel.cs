namespace Application.Clients.Queries.GetClients;

public class ClientModel
{
    public string IdentificationNumber { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Email { get; set; }
}