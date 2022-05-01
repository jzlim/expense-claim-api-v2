namespace ExpenseClaimApi.Models
{
  public class ExpenseClaimLine
  {
    public int Id { get; set; }
    public int ExpenseClaimId { get; set; }
    public DateTime TransactionDate { get; set; }
    public string CostCenter { get; set; }
    public int ClaimItemId { get; set; }
    public string Description { get; set; }
    public string CurrencyCode { get; set; }
    public float Amount { get; set; }
    public float Gst { get; set; }
    public float ExchangeRate { get; set; }
    public float TotalAmount { get; set;}
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ExpenseClaim ExpenseClaim { get; set; }
    public ClaimItem ClaimItem { get; set; }
  }
}