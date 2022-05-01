namespace ExpenseClaimApi.Helpers
{
  public class JwtMiddleware
  {
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
      var token = context.Request.Headers["x-auth-token"].FirstOrDefault()?.Split(" ").Last();
      if (token == null) {
        context.Response.StatusCode = 400; //Bad Request   
        await context.Response.WriteAsync("Unauthorized");
        return;
      }
      await _next(context);
    }
  }
}
