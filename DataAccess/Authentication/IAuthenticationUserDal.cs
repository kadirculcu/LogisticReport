using Core.DataAccess;
using Entities.Authentication.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Authentication
{
    public interface IAuthenticationUserDal :  IEntityRepository<AuthenticationUser>
    {
    }
}
