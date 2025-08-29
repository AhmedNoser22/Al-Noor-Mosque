namespace Al_Noor.Application.IServices
{
    public interface IAuthServices
    {
        Task<bool> LoginAsync(LoginDto login);
        Task LogoutAsync();
        Task<bool> RegisterAsync(RegisterDto register);
    }
}
