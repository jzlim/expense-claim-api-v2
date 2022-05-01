namespace ExpenseClaimApi.Models
{
  public class LoginRequest: BaseRequest
  {
    public UserDTO User { get; set; }
  }
}