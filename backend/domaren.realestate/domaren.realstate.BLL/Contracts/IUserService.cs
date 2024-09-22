using domaren.realstate.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domaren.realstate.BLL.Contracts
{
    public interface IUserService
    {
        public User GetUser(int id);
        public int SaveUser(User user);

    }
}
