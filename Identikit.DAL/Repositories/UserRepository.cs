using Identikit.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identikit.DAL.Repositories
{
    public class UserRepository: Repository<User>, IRepository<User>
    {
        public UserRepository()
        {

        }

        public bool CheckIsUserValid(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            using (var context = new IdentikitContext())
            {
                var result = context.Set<User>().FirstOrDefault(u => u.Login == login && 
                                                                u.Password == password);
                return result != null;
            }
        }

        public User GetByLogin(string login)
        {
            using (var context = new IdentikitContext())
            {
                return context.Set<User>().FirstOrDefault(u => u.Login == login);
            }
        }
    }
}
