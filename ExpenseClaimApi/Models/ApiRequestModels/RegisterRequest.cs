namespace ExpenseClaimApi.Models
{
  public class RegisterRequest: BaseRequest
  {
    public UserDTO User { get; set; }
  }
}