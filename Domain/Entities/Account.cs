namespace Domain.Entities;

public class Account
{
    public int AccountId { get; set; }
    public string AccountNumber { get; set; } = null!;
    public decimal Balance { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; } = null!;
    public ICollection<Transfer>? TransfersFrom { get; set; }
    public ICollection<Transfer>? TransfersTo { get; set; }
}