namespace Domain.Entities;

public class Transfer
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Purpose { get; set; } = null!;
    public int FromAccountId { get; set; }
    public Account FromAccount { get; set; } = null!;
    public int ToAccountId { get; set; }
    public Account ToAccount { get; set; } = null!;
    public DateTime TransferDate { get; set; }
}