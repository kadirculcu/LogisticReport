using DataAccess.Authentication;
using Entities.Authentication.Dto;
using Entities.Authentication.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Authentication
{
    public class AuthenticationService  : IAuthenticationService
    {
        private IAuthenticationUserDal _authenticationUserDal;
        private IConfiguration _configuration;

        public AuthenticationService(IAuthenticationUserDal authenticationUserDal, IConfiguration configuration)
        {
            _authenticationUserDal = authenticationUserDal;
            _configuration = configuration;
        }

        public AuthenticationUserDto Login(LoginDto loginDto)
        {
            AuthenticationUser authenticationUser = _authenticationUserDal.Get(x => x.UserName == loginDto.UserName && x.Password == loginDto.Password);
            AuthenticationUserDto authenticationUserDto = new AuthenticationUserDto();
            if (authenticationUser == null)
            {
                authenticationUserDto.Token = "Kullanıcı Bulunamadı";
                return authenticationUserDto;
            }
            else
            {
                string token=CreateToken(authenticationUser);
                authenticationUserDto.UserName = authenticationUser.UserName;
                authenticationUserDto.Token = token;
                return authenticationUserDto;
            }           
        }
        private string CreateToken(AuthenticationUser authentication)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, authentication.Id.ToString()),
                    new Claim(ClaimTypes.Name, authentication.UserName)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key)
                    , SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
       
        public void Register(LoginDto loginDto)
        {
            AuthenticationUser authenticationUser = _authenticationUserDal.Get(x => x.UserName == loginDto.UserName);
            if (authenticationUser == null)
            {
                AuthenticationUser authentication = new AuthenticationUser()
                {
                    Password = loginDto.Password,
                    UserName = loginDto.UserName
                };
                _authenticationUserDal.Add(authentication);
            }
        }
    }
}
