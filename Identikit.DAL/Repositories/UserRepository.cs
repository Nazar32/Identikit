using Identikit.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identikit.DAL.Repositories
{
    public class UserRepository: Repository<User>, IUserRepository 
    {
        public UserRepository()
        {

        }

        public User GetByCredentials(string login, string password)
        {
            using (var context = new IdentikitContext())
            {
                return context.Set<User>().FirstOrDefault(u => u.Login == login && u.Password == password);
            }
        }
    }
}
