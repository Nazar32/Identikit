using Identikit.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identikit.DAL.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        User GetByCredentials(string login, string password);
    }
}
