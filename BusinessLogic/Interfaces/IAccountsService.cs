using Core.ApiModels.Account;

namespace Core.Interfaces
{
    public interface IAccountsService
    {
        Task RegisterAsync(RegisterRequest model);
        Task LoginAsync(LoginRequest model);
        Task LogoutAsync();
    }
}