using ExpenseClaimApi.Context;
using ExpenseClaimApi.Models;
using ExpenseClaimApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseClaimApi.Controllers
{
  [Route("api/[controller]")]
  public class UserController: Controller
  {
    private UserService _userService;

    public UserController(DatabaseContext context) {
      _userService = new UserService(context);
    }

    [HttpPost]
    [Route("GetUserInformation")]
    public async Task<UserDTO> GetUserInformation([FromBody] BaseRequest request) {
      return await _userService.GetUserInformation(request.Id);
    }

    [HttpPost]
    [Route("Login")]
    public async Task<LoginResponse> Login([FromBody] LoginRequest request) {
      var user = await _userService.GetUserByEmail(request.User.Email);
      if (user == null) {
        NotFound();
      } else if (!Helpers.Util.IsHashMatch(request.User.Password, user.Password)) {
        BadRequest("Incorrect email or password");
      }
      var accessToken = Helpers.JwtHelper.GenerateJwtToken(user);
      return new LoginResponse {
        AccessToken = accessToken,
        User = new UserDTO {
          Id = user.Id,
          Email = user.Email,
          FullName = user.FullName
        }
      };
    }

    [HttpPost]
    [Route("Register")]
    public async Task<UserDTO> Register([FromBody] RegisterRequest request) {
      bool isEmailTaken = await _userService.VerifyIsEmailTaken(request.User.Email);
      if (isEmailTaken) {
        BadRequest("Email already taken");
      }
      string passwordHash = Helpers.Util.CreateHash(request.User.Password);
      var user = await _userService.CreateUser(new UserDTO {
        Email = request.User.Email,
        Password = passwordHash,
        FullName = request.User.FullName,
        BranchCode = request.User.BranchCode,
        BankAccountName = request.User.BankAccountName,
        BankAccountNumber = request.User.BankAccountNumber,
        BankCode = request.User.BankCode
      });
      return user;
    }
  }
}