using domaren.realstate.BLL.DAL.Contarcts;
using domaren.realstate.BLL.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domaren.realstate.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {  
        private readonly List<UserRecord> _records;
        private int _id;
        public UserRepository() 
        { 
            _records = new List<UserRecord>();
            _id = 0;
        }
        public UserRecord GetUser(int id)
        {
            return _records.FirstOrDefault(x => x.Id == id);

        }

        public int SaveUser(UserRecord user)
        {
            _id++;
            user.Id = _id;
            _records.Add(user);
            return _id;
        }
    }
}
