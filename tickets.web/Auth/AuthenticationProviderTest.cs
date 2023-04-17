using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace tickets.web.Auth
{
    public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var anonymous = new ClaimsIdentity();
            var superUser = new ClaimsIdentity(new List<Claim>
            {
                new Claim("FirstName", "Dangiro"),
                new Claim("LastName", "Polanco"),
                new Claim(ClaimTypes.Name, "dangiro@yopmail.com"),
                new Claim(ClaimTypes.Role, "Admin")


            }, authenticationType: "test");
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(superUser)));
        }
    }
}

