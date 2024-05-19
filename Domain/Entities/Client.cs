using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Client
{
    public int Id { get; set; }
    public string IdentificationNumber { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    
    [EmailAddress]
    public string? Email { get; set; }

    public ICollection<Account>? Accounts { get; set; }
}