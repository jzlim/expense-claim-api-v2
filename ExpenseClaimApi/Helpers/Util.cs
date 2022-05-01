namespace ExpenseClaimApi.Helpers
{
  public static class Util
  {
    public static string CreateHash(string input) {
      return BCrypt.Net.BCrypt.HashPassword(input);
    }
    
    public static bool IsHashMatch(string input, string passwordHash) {
      return BCrypt.Net.BCrypt.Verify(input, passwordHash);
    }
  }
}