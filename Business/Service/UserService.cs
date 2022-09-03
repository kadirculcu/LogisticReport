using Business.IService;
using DataAccess.IDataAccess;
using Entities.Report.Dto;
using Entities.Report.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Service
{
    public class UserService : IUserService
    {
        private IUserDal _userDal;
        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public void AddUser(UserDto userDto)
        {
            User user = new User()
            {
                Address=userDto.Address,
                CreateDate=userDto.CreateDate,
                CreatedBy=userDto.CreatedBy,
                FirstName=userDto.FirstName,
                IsDeleted=userDto.IsDeleted,
                LastName=userDto.LastName,
                ModifiedBy=userDto.ModifiedBy,
                ModifyDate=userDto.ModifyDate,
                PhoneNumber=userDto.PhoneNumber,
                ProfilePicture=userDto.ProfilePicture 
            };
            _userDal.Add(user);
        }

        public void DeleteUser(int id)
        {
            User user= _userDal.Get(p => p.Id == id);
            _userDal.Delete(user);
        }

        public List<UserDto> GetAllUser(Expression<Func<User, bool>> condition = null)
        {
            List<User> users = _userDal.GetList(condition);
            return users.Select(x => new UserDto() {
                Id=x.Id,
                Address = x.Address,
                CreateDate = x.CreateDate,
                CreatedBy = x.CreatedBy,
                FirstName = x.FirstName,
                IsDeleted = x.IsDeleted,
                LastName = x.LastName,
                ModifiedBy = x.ModifiedBy,
                ModifyDate = x.ModifyDate,
                PhoneNumber = x.PhoneNumber,
                ProfilePicture = x.ProfilePicture
            }).ToList();
        }

        public UserDto GetUser(int id)
        {
            User user =_userDal.Get(p => p.Id == id);
            UserDto userDto = new UserDto()
            {
                Address = user.Address,
                CreateDate = user.CreateDate,
                CreatedBy = user.CreatedBy,
                FirstName = user.FirstName,
                IsDeleted = user.IsDeleted,
                LastName = user.LastName,
                ModifiedBy = user.ModifiedBy,
                ModifyDate = user.ModifyDate,
                PhoneNumber = user.PhoneNumber,
                ProfilePicture = user.ProfilePicture
            };
            return userDto;
        }

        public void UpdateUser(UserDto userDto)
        {
            User user = _userDal.Get(x => x.Id == userDto.Id);
            user.Address = userDto.Address;
            user.CreateDate = userDto.CreateDate;
            user.CreatedBy = userDto.CreatedBy;
            user.FirstName = userDto.FirstName;
            user.IsDeleted = userDto.IsDeleted;
            user.LastName = userDto.LastName;
            user.ModifiedBy = userDto.ModifiedBy;
            user.ModifyDate = userDto.ModifyDate;
            user.PhoneNumber = userDto.PhoneNumber;
            user.ProfilePicture = userDto.ProfilePicture;
            _userDal.Update(user);
        }
    }
}
