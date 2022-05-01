using ExpenseClaimApi.Context;
using ExpenseClaimApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseClaimApi.Services
{
  public class UserService
  {
    private readonly DatabaseContext _context;
    
    public UserService(DatabaseContext context) {
      _context = context;
    }

    public async Task<UserDTO> GetUserByEmail(string email) {
      var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email && x.IsDeleted == false);
      var entity = ItemToDTO(user);
      entity.Password = user.Password;
      return entity;
    }

    public async Task<UserDTO> GetUserInformation(int id) {
      var user = await _context.Users.FindAsync(id);
      return ItemToDTO(user);
    }

    public async Task<bool> VerifyIsEmailTaken(string email, int? id = null) {
      var result = await _context.Users.AnyAsync(x => x.IsDeleted == false && x.Email == email && (id != null ? x.Id != id : true));
      return result;
    }

    public async Task<UserDTO> CreateUser(UserDTO userDTO) {
      var user = new User {
        Email = userDTO.Email,
        Password = userDTO.Password,
        FullName = userDTO.FullName,
        BranchCode = userDTO.BranchCode,
        BankAccountName = userDTO.BankAccountName,
        BankAccountNumber = userDTO.BankAccountNumber,
        BankCode = userDTO.BankCode,
        CreatedAt = DateTime.Now,
        UpdatedAt = DateTime.Now
      };
      _context.Users.Add(user);
      await _context.SaveChangesAsync();

      return ItemToDTO(user);
    }

    public static UserDTO ItemToDTO(User item) {
      return new UserDTO
      {
          Id = item.Id,
          Email = item.Email,
          // Password = item.Password,
          FullName = item.FullName,
          BranchCode = item.BranchCode,
          BankAccountName = item.BankAccountName,
          BankAccountNumber = item.BankAccountNumber,
          BankCode = item.BankCode,
          IsDeleted = item.IsDeleted,
          CreatedAt = item.CreatedAt,
          UpdatedAt = item.UpdatedAt
      };
    }
  }
}