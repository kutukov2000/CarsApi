using Core.ApiModels.Account;
using Core.Exceptions;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace Core.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        public AccountsService(SignInManager<IdentityUser> signInManager,
                               UserManager<IdentityUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public async Task LoginAsync(LoginRequest model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null || !await userManager.CheckPasswordAsync(user, model.Password))
                throw new HttpException("Invalid email or password.", HttpStatusCode.BadRequest);

            await signInManager.SignInAsync(user, true);
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }

        public async Task RegisterAsync(RegisterRequest model)
        {
            IdentityUser user = new()
            {
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var message = string.Join(", ", result.Errors.Select(x => x.Description));
                throw new HttpException(message, HttpStatusCode.BadRequest);
            }
        }
    }
}
