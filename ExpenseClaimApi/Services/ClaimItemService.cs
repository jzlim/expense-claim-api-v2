using ExpenseClaimApi.Context;
using ExpenseClaimApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseClaimApi.Services
{
  public class ClaimItemService
  {
    private readonly DatabaseContext _context;
    
    public ClaimItemService(DatabaseContext context) {
      _context = context;
    }

    public async Task<IEnumerable<ClaimItemDTO>> GetClaimItems() {
      var claimItems = await _context.ClaimItems.Where(x => x.IsDeleted == false).ToListAsync();
      return claimItems.Select(x => ItemToDTO(x));
    }
    
    public static ClaimItemDTO ItemToDTO(ClaimItem item) {
      return new ClaimItemDTO
      {
          Id = item.Id,
          GlCode = item.GlCode,
          Remarks = item.Remarks,
          IsDeleted = item.IsDeleted,
          CreatedAt = item.CreatedAt,
          UpdatedAt = item.UpdatedAt
      };
    }
  }
}