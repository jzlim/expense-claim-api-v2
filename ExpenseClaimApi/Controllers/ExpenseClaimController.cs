using ExpenseClaimApi.Context;
using ExpenseClaimApi.Models;
using ExpenseClaimApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseClaimApi.Controllers
{
  [Route("api/[controller]")]
  public class ExpenseClaimController: Controller
  {
    private ExpenseClaimService _expenseClaimService;

    public ExpenseClaimController(DatabaseContext context) {
      _expenseClaimService = new ExpenseClaimService(context);
    }

    [HttpPost]
    [Route("GetAllExpenseClaims")]
    public async Task<IEnumerable<ExpenseClaimDTO>> GetAllExpenseClaims([FromBody] BaseRequest request) {
      return await _expenseClaimService.GetAllExpenseClaims(request.Id);
    }

    [HttpPost]
    [Route("GetExpenseClaimById")]
    public async Task<ExpenseClaimDTO> GetExpenseClaimById([FromBody] BaseRequest request) {
      return await _expenseClaimService.GetExpenseClaimById(request.Id);
    }

    [HttpPost]
    [Route("DeleteExpenseClaim")]
    public async Task<ExpenseClaimDTO> DeleteExpenseClaim([FromBody] BaseRequest request) {
      return await _expenseClaimService.DeleteExpenseClaim(request.Id);
    }

    [HttpPost]
    [Route("SaveExpenseClaim")]
    public async Task<ExpenseClaimDTO> SaveExpenseClaim([FromBody] SaveExpenseClaimRequest request) {
      return await _expenseClaimService.SaveExpenseClaim(request.ExpenseClaim);
    }
  }
}