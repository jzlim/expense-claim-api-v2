using ExpenseClaimApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseClaimApi.Context
{
  public class DatabaseContext: DbContext
  {
    public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<ClaimItem> ClaimItems { get; set; }
    public DbSet<ExpenseClaim> ExpenseClaims { get; set; }
    public DbSet<ExpenseClaimLine> ExpenseClaimLines { get; set; }
  }
}