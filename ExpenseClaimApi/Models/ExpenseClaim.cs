namespace ExpenseClaimApi.Models
{
  public class ExpenseClaim 
  {
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime ClaimDate { get; set; }
    public string BankAccountName { get; set; }
    public string BankAccountNumber { get; set; }
    public string BankCode { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public User User { get; set; }
    public ICollection<ExpenseClaimLine> ExpenseClaimLines { get; set; }
  }
}