namespace ExpenseClaimApi.Models
{
  public class LoginResponse
  {
    public UserDTO User { get; set; }
    public string AccessToken { get; set; }
  }
}