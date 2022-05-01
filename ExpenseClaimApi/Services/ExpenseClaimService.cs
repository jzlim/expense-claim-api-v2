using ExpenseClaimApi.Context;
using ExpenseClaimApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseClaimApi.Services
{
  public class ExpenseClaimService
  {
    private readonly DatabaseContext _context;
    
    public ExpenseClaimService(DatabaseContext context) {
      _context = context;
    }

    public async Task<IEnumerable<ExpenseClaimDTO>> GetAllExpenseClaims(int userId) {
      var expenseClaims = await _context.ExpenseClaims.Include(x => x.ExpenseClaimLines).ThenInclude(l => l.ClaimItem)
                                                      .Where(x => x.UserId == userId && x.IsDeleted == false)
                                                      .OrderByDescending(x => x.CreatedAt).ToListAsync();
      return expenseClaims.Select(x => ExpenseClaimToDTO(x)).ToList();
    }

    public async Task<ExpenseClaimDTO> GetExpenseClaimById(int id) {
      var expenseClaim = await _context.ExpenseClaims.Include(x => x.ExpenseClaimLines).FirstOrDefaultAsync(x => x.Id == id);
      return ExpenseClaimToDTO(expenseClaim);
    }

    public async Task<ExpenseClaimDTO> DeleteExpenseClaim(int id) {
      var expenseClaim = await _context.ExpenseClaims.FindAsync(id);
      if (expenseClaim == null) {
        return null; // need not found handler
      }
      expenseClaim.IsDeleted = true;
      await _context.SaveChangesAsync();
      return ExpenseClaimToDTO(expenseClaim);
    }

    public async Task<ExpenseClaimDTO> SaveExpenseClaim(ExpenseClaimDTO expenseClaimDTO) {
      DateTime now = DateTime.Now;
      var expenseClaim = new ExpenseClaim {
        UserId = expenseClaimDTO.UserId,
        ClaimDate = expenseClaimDTO.ClaimDate,
        BankAccountName = expenseClaimDTO.BankAccountName,
        BankAccountNumber = expenseClaimDTO.BankAccountNumber,
        BankCode = expenseClaimDTO.BankCode,
        CreatedAt = now,
        UpdatedAt = now
      };
      if (expenseClaimDTO.ExpenseClaimLines.Any()) {
        expenseClaim.ExpenseClaimLines = new List<ExpenseClaimLine>();
        foreach (var item in expenseClaimDTO.ExpenseClaimLines)
        {
          var expenseClaimLine = new ExpenseClaimLine {
            TransactionDate = item.TransactionDate,
            CostCenter = item.CostCenter,
            ClaimItemId = item.ClaimItemId,
            Description = item.Description,
            CurrencyCode = item.CurrencyCode,
            Amount = item.Amount,
            Gst = item.Gst,
            ExchangeRate = item.ExchangeRate,
            TotalAmount = item.TotalAmount,
            CreatedAt = now,
            UpdatedAt = now
          };
          expenseClaim.ExpenseClaimLines.Add(expenseClaimLine);
        }
      }
      _context.ExpenseClaims.Add(expenseClaim);
      await _context.SaveChangesAsync();
      return ExpenseClaimToDTO(expenseClaim);
    }
    
    private static ExpenseClaimDTO ExpenseClaimToDTO(ExpenseClaim item) {
      var entity = new ExpenseClaimDTO
      {
          Id = item.Id,
          UserId = item.UserId,
          ClaimDate = item.ClaimDate,
          BankAccountName = item.BankAccountName,
          BankAccountNumber = item.BankAccountNumber,
          BankCode = item.BankCode,
          IsDeleted = item.IsDeleted,
          CreatedAt = item.CreatedAt,
          UpdatedAt = item.UpdatedAt
      };

      if (item.ExpenseClaimLines != null && item.ExpenseClaimLines.Any(x => x.IsDeleted == false)) {
        entity.ExpenseClaimLines = new List<ExpenseClaimLineDTO>();
        foreach (var line in item.ExpenseClaimLines)
        {
          var lineEntity = ExpenseClaimLineToDTO(line);
          entity.TotalAmount += lineEntity.TotalAmount;
          entity.ExpenseClaimLines.Add(lineEntity);
        }
      }

      return entity;
    }
    
    private static ExpenseClaimLineDTO ExpenseClaimLineToDTO(ExpenseClaimLine item) {
      var entity = new ExpenseClaimLineDTO
      {
          Id = item.Id,
          ExpenseClaimId = item.ExpenseClaimId,
          TransactionDate = item.TransactionDate,
          CostCenter = item.CostCenter,
          ClaimItemId = item.ClaimItemId,
          Description = item.Description,
          CurrencyCode = item.CurrencyCode,
          Amount = item.Amount,
          Gst = item.Gst,
          ExchangeRate = item.ExchangeRate,
          TotalAmount = item.TotalAmount,
          IsDeleted = item.IsDeleted,
          CreatedAt = item.CreatedAt,
          UpdatedAt = item.UpdatedAt
      };

      if (item.ClaimItem != null) {
        entity.ClaimItem = ClaimItemService.ItemToDTO(item.ClaimItem);
      }

      return entity;
    }
  }
}