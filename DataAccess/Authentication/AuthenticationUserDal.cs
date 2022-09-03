using Core.DataAccess.EntityFrameworkRepository;
using Entities.Authentication.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Authentication
{
    public class AuthenticationUserDal : EntityFrameworkRepository<AuthenticationUser>, IAuthenticationUserDal
    {
        public AuthenticationUserDal(DbContext dbContext) : base(dbContext)
        {

        }

    }
}
