namespace ExpenseClaimApi.Models
{
  public class ClaimItemDTO
  {
    public int Id { get; set; }
    public string GlCode { get; set; }
    public string Remarks { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public ICollection<ExpenseClaimLineDTO> ExpenseClaimLines { get; set; }
  }
}