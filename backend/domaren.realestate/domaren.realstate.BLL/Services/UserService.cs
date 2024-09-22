using domaren.realstate.BLL.Contracts;
using domaren.realstate.BLL.DAL.Contarcts;
using domaren.realstate.BLL.DAL.Models;
using domaren.realstate.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domaren.realstate.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUser(int id)
        {
            var userRecord = _userRepository.GetUser(id);
            var user = ToUser(userRecord);
            return user;
        }

        public int SaveUser(User user)
        {
            var userRecord = ToUserRecord(user);
            return _userRepository.SaveUser(userRecord);

        }
        private UserRecord ToUserRecord(User record)
        {
            var userRecord = new UserRecord 
            {
                Id = record.Id,
                FirstName = record.FirstName,
                LastName = record.LastName,
                Login = record.Login,
                Password = record.Password,
                EMail = record.EMail
                
            };
            return userRecord;

        }
        private User ToUser(UserRecord record)
        {
            var userRecord = new User
            {
                Id = record.Id,
                FirstName = record.FirstName,
                LastName = record.LastName,
                Login = record.Login,
                Password = record.Password,
                EMail = record.EMail

            };
            return userRecord;

        }

    }
}
