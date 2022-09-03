using Entities.Report.Dto;
using Entities.Report.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.IService
{
    public interface IUserService 
    {
        List<UserDto> GetAllUser(Expression<Func<User, bool>> condition = null);
        void AddUser(UserDto userDto);
        void DeleteUser(int id);
        void UpdateUser(UserDto userDto);
        UserDto GetUser(int id);
    }
}
