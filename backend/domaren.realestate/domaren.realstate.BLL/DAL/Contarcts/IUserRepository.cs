using domaren.realstate.BLL.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domaren.realstate.BLL.DAL.Contarcts
{
    public interface IUserRepository
    {
        public UserRecord GetUser(int id);
        public int SaveUser(UserRecord user);
    }
}
