namespace tickets.web.Auth
{
	public interface ILoginService
	{
        Task LoginAsync(string token);

        Task LogoutAsync();
    }
}

