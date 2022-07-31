using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace _01_Framework.Application
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void SignIn(AuthViewModel account)
        {
            var roles = JsonConvert.SerializeObject(account.RolesList);


            var claims = new List<Claim>
            {
                new Claim("UsedId", account.ID.ToString()),
                new Claim(ClaimTypes.Name, account.Fullname),
                new Claim(ClaimTypes.Email, account.Username),
                new Claim(ClaimTypes.Role, roles.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
            };

            _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
        }

        public void SignOut()
        {
            _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public bool IsAuthenticated()
        {
            return _contextAccessor.HttpContext.User.Identity.IsAuthenticated;

        }


        public string CurrentAccountRole()
        {
            if (IsAuthenticated())
            { 
            return _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
            }
            else
            {
                return null;
            }
        }

        public AuthViewModel CurrentAccountInfo()
        {
            var result = new AuthViewModel();
            if (!IsAuthenticated())
                return result;

            var claims = _contextAccessor.HttpContext.User.Claims.ToList();
            result.ID = long.Parse(claims.FirstOrDefault(x => x.Type == "UserId").Value);
            result.Username = claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
            result.Fullname = claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
            result.RolesList = JsonConvert.DeserializeObject<List<long>>(claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value);
            return result;
        }

    }
}
