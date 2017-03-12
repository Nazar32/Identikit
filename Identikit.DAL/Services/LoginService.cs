using Identikit.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identikit.DAL.Services
{
    public class LoginService: ILoginService
    {
        IUserRepository _userRepo;

        public LoginService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public bool CheckIsUserValid(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            var result = _userRepo.GetByCredentials(login, password);
            return result != null;
        }
    }
}
