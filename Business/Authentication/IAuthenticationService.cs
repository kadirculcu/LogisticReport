using Entities.Authentication.Dto;
using Entities.Authentication.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Authentication
{
    public interface IAuthenticationService
    {
        void Register(LoginDto loginDto);
        AuthenticationUserDto Login(LoginDto loginDto);
    }
}
