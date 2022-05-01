using ExpenseClaimApi.Context;
using ExpenseClaimApi.Models;
using ExpenseClaimApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseClaimApi.Controllers
{
  [Route("api/[controller]")]
  public class ClaimItemController: Controller
  {
    private ClaimItemService _claimItemService;

    public ClaimItemController(DatabaseContext context) {
      _claimItemService = new ClaimItemService(context);
    }

    [HttpGet]
    [Route("GetClaimItems")]
    public async Task<IEnumerable<ClaimItemDTO>> GetClaimItems() {
      return await _claimItemService.GetClaimItems();
    }
  }
}