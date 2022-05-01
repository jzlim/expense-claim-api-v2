namespace ExpenseClaimApi.Models
{
  public class SaveExpenseClaimRequest: BaseRequest
  {
    public ExpenseClaimDTO ExpenseClaim { get; set; }
  }
}