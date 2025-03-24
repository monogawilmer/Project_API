namespace Project_API.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<string?> AuthenticateAsync(string email, string password);
        string GenerateJwtToken(string userId, string userEmail, string role);
    }
}
