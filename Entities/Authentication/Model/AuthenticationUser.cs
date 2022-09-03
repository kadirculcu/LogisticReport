using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Authentication.Model
{
    public class AuthenticationUser: IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
