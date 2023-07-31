using Microsoft.IdentityModel.Tokens;
using Server.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Server.Service
{
    public class AccountService
    {
        private readonly UsersService m_Service;

        public AccountService(UsersService service)
        {
            m_Service = service;
        }

        private async Task<ClaimsIdentity> GetIdentity(string email, string password)
        {
            //UserEntity user = await m_Service.GetByEmail(email);
            //if (user == null) return null;
            //if (!user.Pwd.Equals(password)) return null;
            //var claims = new List<Claim> {
            //new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
            //new Claim(ClaimsIdentity.DefaultRoleClaimType, "User")};
            //ClaimsIdentity claimsIdentity = new ClaimsIdentity(
            //claims,
            //"Token",
            //ClaimsIdentity.DefaultNameClaimType,
            //ClaimsIdentity.DefaultRoleClaimType
            //);
            //return claimsIdentity;
            return null;
        }
    }
}
