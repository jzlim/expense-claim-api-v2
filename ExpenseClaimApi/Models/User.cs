namespace ExpenseClaimApi.Models 
{
  public class User
  {
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
    public string BranchCode { get; set; }
    public string BankAccountName { get; set; }
    public string BankAccountNumber { get; set; }
    public string BankCode { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public ICollection<ExpenseClaim> ExpenseClaims { get; set; }
  }
}