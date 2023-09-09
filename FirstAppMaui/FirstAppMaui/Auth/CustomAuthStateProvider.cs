using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppMaui.Auth
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        public async Task Login(string token)
        {
            await SecureStorage.SetAsync("accounttoken", token);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public void Logout()
        {
            SecureStorage.Remove("accounttoken");
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            try
            {
                var userId = await SecureStorage.GetAsync("accounttoken");
                if (userId != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, userId)
                    };

                    //If user hase Id of 1 then he is an admin
                    if (userId == "1")
                        claims.Add(new Claim("role", "admin"));
                    else
                        claims.Add(new Claim("role", "user"));


                    var identity = new ClaimsIdentity(claims, "Server Auth");

                    return new AuthenticationState(new ClaimsPrincipal(identity));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Request Failed: " + ex.ToString());
            }

            return new AuthenticationState(new ClaimsPrincipal());
        }
    }
}
