namespace tickets.shared.DTOs
{
    public class TokenDTO
	{
        public string Token { get; set; } = null!;

        public DateTime Expiration { get; set; }

        public List<RolesDTO>? Roles { get; set; }
    }
}

