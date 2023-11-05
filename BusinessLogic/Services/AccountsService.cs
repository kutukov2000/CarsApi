using Core.ApiModels.Account;
using Core.Exceptions;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace Core.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly IJwtService _jwtService;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountsService(IJwtService jwtService,
                               SignInManager<IdentityUser> signInManager,
                               UserManager<IdentityUser> userManager)
        {
            _jwtService = jwtService;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<LoginResponse> LoginAsync(LoginRequest model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                throw new HttpException("Invalid email or password.", HttpStatusCode.BadRequest);

            await _signInManager.SignInAsync(user, true);

            return new()
            {
                Token = _jwtService.CreateToken(_jwtService.GetClaims(user))
            };
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task RegisterAsync(RegisterRequest model)
        {
            IdentityUser user = new()
            {
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var message = string.Join(", ", result.Errors.Select(x => x.Description));
                throw new HttpException(message, HttpStatusCode.BadRequest);
            }
        }
    }
}
