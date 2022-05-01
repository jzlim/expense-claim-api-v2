namespace ExpenseClaimApi.Models
{
  public class ExpenseClaimDTO
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
    public float TotalAmount { get; set; }
    public UserDTO User { get; set; }
    public ICollection<ExpenseClaimLineDTO> ExpenseClaimLines { get; set; }
  }
}